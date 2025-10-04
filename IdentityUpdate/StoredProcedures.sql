IF EXISTS(SELECT * FROM sys.procedures WHERE NAME = 'ID_UPDATE_Table_GET_LIST')
	DROP PROC ID_UPDATE_Table_GET_LIST

IF EXISTS(SELECT * FROM sys.procedures WHERE NAME = 'ID_UPDATE_TABLE_GET_RELATIONS')
	DROP PROC ID_UPDATE_TABLE_GET_RELATIONS

IF EXISTS(SELECT * FROM sys.procedures WHERE NAME = 'ID_UPDATE_TABLE_INDEXES_ON_OFF')
	DROP PROC ID_UPDATE_TABLE_INDEXES_ON_OFF
	
GOGO
CREATE PROC ID_UPDATE_Table_GET_LIST
AS
CREATE TABLE #tempTable (TableNameVar NVARCHAR(128),MaxID INT, MinID INT)

DECLARE AllTables CURSOR FOR
SELECT tab.name 
FROM sys.columns as col
INNER JOIN (SELECT object_id , name FROM sys.Tables WHERE NAME LIKE 'T%KOD%' )as tab ON tab.object_id = col.object_id
WHERE col.Name = 'ID'
ORDER BY tab.name 
OPEN AllTables

DECLARE @TableNameVar NVARCHAR(128)
DECLARE @Statement NVARCHAR(300)

FETCH NEXT FROM AllTables INTO @TableNameVar
WHILE (@@FETCH_STATUS = 0)
BEGIN

   SET @Statement = N'INSERT INTO #tempTable (TableNameVar,MaxID, MinID) (SELECT NAME = ''' 
   +@TableNameVar+''', (SELECT MaxID = MAX(ID) FROM ' + @TableNameVar + ' WHERE ID > 10000),
   (SELECT MinID = MAX(ID) FROM ' + @TableNameVar + ' WHERE ID < 10000))'
   print @TableNameVar
   EXEC sp_executesql @Statement
   FETCH NEXT FROM AllTables INTO @TableNameVar
END

CLOSE AllTables
DEALLOCATE AllTables


SELECT TableNameVar AS TableName, MaxID, MinID  FROM #tempTable WHERE MaxID > 10000 and TableNameVar <> 'TDIE_KOD_SOZLUK'

GOGO

CREATE PROC ID_UPDATE_TABLE_GET_RELATIONS
(
	@TableName  NVARCHAR(128)
)
AS
SELECT object_name(fkeyid) as RelatedTable, object_name(rkeyid) AS MainTable, col_name(fkeyid,fkey) AS RelatedColumn, col_name(rkeyid,rkey) AS MainColumn 
FROM sysforeignkeys
WHERE rkeyid = object_id(@TableName)

GOGO
CREATE PROC ID_UPDATE_TABLE_INDEXES_ON_OFF
(
	@TableName NVARCHAR(128),
	@Operation NVARCHAR(3)
)
AS

DECLARE @IndexName NVARCHAR(128),
		@StrQuery NVARCHAR(4000),
		@IndexID INT,
		@ConstraintName NVARCHAR(128),
		@Constid INT

SET @IndexName = ''


SELECT TOP 1 @IndexName = name , @IndexID = index_id
FROM sys.indexes 
WHERE  object_id = object_id(@TableName) AND is_primary_key = 0 and name <> ''
ORDER BY index_id ASC


WHILE @IndexName <> ''
BEGIN
	IF @Operation = 'OFF'
	BEGIN 
		--ALTER INDEX indexName ON tableName DISABLE
		SET @strQuery = 'ALTER INDEX ' + @IndexName +' ON ' + @TableName +' DISABLE'
		EXEC sp_executesql  @strQuery
	END
	IF @Operation = 'ON'
	BEGIN 
		DBCC DBREINDEX (@TableName, @IndexName , 70);
	END

	SELECT @IndexName = ''
		
	SELECT TOP 1 @IndexName = name , @IndexID = index_id
	FROM sys.indexes 
	WHERE  object_id = object_id(@TableName) AND is_primary_key = 0 and name <> '' 
	and index_id > @IndexID
	ORDER BY index_id ASC
END

IF @Operation = 'ON'
BEGIN

	SET @ConstraintName = ''
	
	--All constraints
	SELECT  TOP 1 @ConstraintName = object_name(constid), @Constid = constid
	FROM sys.sysconstraints 
	WHERE ID = object_id(@TableName)
	ORDER BY constid asc
	
	WHILE @ConstraintName <> ''
	BEGIN
	
		SET @strQuery =  'ALTER TABLE ' + @TableName + ' CHECK CONSTRAINT ' + @ConstraintName
		EXEC sp_executesql  @strQuery
		SELECT @ConstraintName = ''
		
		SELECT  TOP 1 @ConstraintName = object_name(constid), @Constid = constid
		FROM sys.sysconstraints 
		WHERE ID = object_id(@TableName) AND   constid > @Constid
		ORDER BY constid ASC
	END
END

GOGO

IF NOT  EXISTS(SELECT * FROM sys.tables WHERE NAME ='IU_ID_BACKUP')
BEGIN
	CREATE TABLE IU_ID_BACKUP
	(
		ID INT IDENTITY(1,1),
		TableName NVARCHAR(128),
		OldID INT,
		NewID INT,
		OperationTime DATETIME DEFAULT(GETDATE()) NOT NULL
		CONSTRAINT PK_IU_ID_BACKUP PRIMARY KEY (ID)
	)
END