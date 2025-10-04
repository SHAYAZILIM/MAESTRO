using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using System;
using System.Drawing;

namespace AvukatProLib.Controls.Grid.CustomFiltering
{
    public class ExtendedFilterColumn : FilterColumn
    {
        private FilterColumnClauseClass clauseClass = FilterColumnClauseClass.Lookup;
        private string columnCaption = "dasda";
        private RepositoryItem columnEditor = new RepositoryItem();
        private Type columnType = typeof(string);
        private string fieldName = "aaaaa";
        private System.Drawing.Image image;

        public override FilterColumnClauseClass ClauseClass
        {
            get { return clauseClass; }
        }

        public override string ColumnCaption
        {
            get { return columnCaption; }
        }

        public override RepositoryItem ColumnEditor
        {
            get { return columnEditor; }
        }

        public override Type ColumnType
        {
            get { return columnType; }
        }

        public override string FieldName
        {
            get { return fieldName; }
        }

        public override System.Drawing.Image Image
        {
            get { return image; }
        }

        public void FillFields(string caption, string field)
        {
            columnCaption = caption;
            fieldName = field;
        }

        public void FillFields(string caption, string field, RepositoryItem columnEdit, Type colType)
        {
            columnCaption = caption;
            fieldName = field;
            columnEditor = columnEdit;
            columnType = colType;
        }

        public void FillFields(string caption, string field, RepositoryItem columnEdit, Type colType, Image colImage)
        {
            columnCaption = caption;
            fieldName = field;
            columnEditor = columnEdit;
            columnType = colType;
            image = colImage;
        }
    }
}