using AVPSchemaGenerator.Types;
using System;
using System.Collections.Generic;

namespace AVPSchemaGenerator.Common
{
    public class SQLParser
    {
        #region Fields

        private readonly string _blockCommentEnd;
        private readonly string _blockCommentStart;
        private readonly string _lineComment;
        private readonly string _lineComment2;
        private readonly string _paramToken;
        private readonly string _tempObjectToken;
        private readonly string _tokenDelimiters;

        private bool _ignoreSchema;
        private List<string> _notAllowedKeywordsInSelectStatement = new List<string>();

        #endregion Fields

        #region Constructors

        public SQLParser()
        {
            this._notAllowedKeywordsInSelectStatement.Add("update");
            this._notAllowedKeywordsInSelectStatement.Add("insert");
            this._notAllowedKeywordsInSelectStatement.Add("delete");
            this._notAllowedKeywordsInSelectStatement.Add("create");
            this._notAllowedKeywordsInSelectStatement.Add("alter");
            this._notAllowedKeywordsInSelectStatement.Add("show");
            this._notAllowedKeywordsInSelectStatement.Add("commit");
            this._notAllowedKeywordsInSelectStatement.Add("rollback");
            this._notAllowedKeywordsInSelectStatement.Add("explain");
            this._notAllowedKeywordsInSelectStatement.Add("optimize");
            this._notAllowedKeywordsInSelectStatement.Add("describe");
            this._notAllowedKeywordsInSelectStatement.Add("shutdown");
            this._notAllowedKeywordsInSelectStatement.Add("set");
            this._notAllowedKeywordsInSelectStatement.Add("use");
            this._notAllowedKeywordsInSelectStatement.Add("while");
            this._notAllowedKeywordsInSelectStatement.Add("for");
            this._notAllowedKeywordsInSelectStatement.Add("foreach");
            this._notAllowedKeywordsInSelectStatement.Add("lock");
            this._notAllowedKeywordsInSelectStatement.Add("using");
            this._notAllowedKeywordsInSelectStatement.Add("return");
            this._notAllowedKeywordsInSelectStatement.Add("exec");
            this._notAllowedKeywordsInSelectStatement.Add("execute");

            this._lineComment = "--";
            this._blockCommentStart = "/*";
            this._blockCommentEnd = "*/";
            this._ignoreSchema = false;
            this._paramToken = "@";
            this._tokenDelimiters = " ,;.\n";
            this._tempObjectToken = "#";
        }

        #endregion Constructors

        #region Methods

        public bool Exists(string def, View v)
        {
            string str = v.Name.ToLower().Replace("[", "").Replace("]", "");
            string str2 = v.Schema.ToLower().Replace("[", "").Replace("]", "");
            def = def.ToLower();
            def = this.CleanUp(def);
            if (!this._ignoreSchema && (str2 == "dbo"))
            {
                this._ignoreSchema = true;
            }
            int index = def.IndexOf(str);
            if (index == -1)
            {
                return false;
            }
            bool flag = true;
            if (!this._ignoreSchema && (this.GetTableAlias(def, index) != str2))
            {
                flag = false;
            }
            return flag;
        }

        private bool CheckAdditionalValidity(string def, int idxStart, int idxEnd, bool bSelect)
        {
            if (bSelect)
            {
                foreach (string str in this._notAllowedKeywordsInSelectStatement)
                {
                    int index = def.IndexOf(String.Format("{0} ", str), idxStart);
                    if ((index > -1) && (index < idxEnd))
                    {
                        return false;
                    }
                }
            }
            else
            {
                int num2 = def.IndexOf("insert ", idxStart);
                if ((num2 > -1) && (num2 < idxEnd))
                {
                    return false;
                }
                int num3 = def.IndexOf("update ", idxStart);
                if ((num3 > -1) && (num3 < idxEnd))
                {
                    return false;
                }
                int num4 = def.IndexOf("delete ", idxStart);
                if ((num4 > -1) && (num4 < idxEnd))
                {
                    return false;
                }
            }
            return true;
        }

        private string CleanUp(string sp)
        {
            if (this._lineComment2 == null)
            {
                if (sp.Contains(this._lineComment) || (sp.Contains(this._blockCommentStart) && sp.Contains(this._blockCommentEnd)))
                {
                    sp = this.RemoveComments(sp);
                }
            }
            else if ((sp.Contains(this._lineComment) || sp.Contains(this._lineComment2)) || (sp.Contains(this._blockCommentStart) && sp.Contains(this._blockCommentEnd)))
            {
                sp = this.RemoveComments(sp);
            }
            if (this._paramToken != null)
            {
                sp = this.RemoveParameters(sp);
            }
            if (this._tempObjectToken != null)
            {
                sp = this.RemoveTempObjects(sp);
            }
            sp = this.RemoveStrings(sp, "\"");
            sp = this.RemoveStrings(sp, "'");
            sp = this.RemoveStrings(sp, "[");
            sp = this.RemoveStrings(sp, "]");
            sp = this.RemoveStrings(sp, "`");
            return sp;
        }

        private string GetNextToken(string def, int pos)
        {
            int num = def.IndexOfAny(this._tokenDelimiters.ToCharArray(), pos);
            if (num > -1)
                return def.Substring(pos, num - pos);
            else
                return null;
        }

        private string GetPreviousToken(string def, int pos)
        {
            string str2 = def.Substring(0, pos);
            int num = str2.LastIndexOfAny(this._tokenDelimiters.ToCharArray());
            if (num > -1)
            {
                return str2.Substring(num + 1, pos - (num + 1));
            }
            return null;
        }

        private string GetTableAlias(string def, int idxColumn)
        {
            if (def.Substring(idxColumn - 1, 1) == ".")
                return this.GetPreviousToken(def, idxColumn - 1);
            else
                return null;
        }

        private string GetTableAlias(string def, Table t, int idxTable)
        {
            string str = def.Substring(idxTable + t.Name.Length).Trim();
            string nextToken = this.GetNextToken(str, 0);
            if (nextToken != null)
            {
                nextToken = nextToken.Trim();
                if (nextToken == "as")
                {
                    int index = str.IndexOf("as");
                    str = str.Substring(index + 2);
                    return this.GetNextToken(str, 0);
                }
                if (((!(nextToken == "left") && !(nextToken == "right")) && (!(nextToken == "inner") && !(nextToken == "full"))) && (!(nextToken == "outer") && !(nextToken == "join")))
                {
                    return nextToken;
                }
            }
            return null;
        }

        private bool IsSyntaxValidStatement(string def, int idx1, int idx2)
        {
            int num;
            int num2;
            if (idx1 > idx2)
            {
                num = idx2;
                num2 = idx1;
            }
            else
            {
                num = idx1;
                num2 = idx2;
            }
            int num3 = def.Substring(0, num).LastIndexOf("select");
            int num4 = def.Substring(0, num).LastIndexOf("update");
            int num5 = def.Substring(0, num).LastIndexOf("insert");
            int num6 = def.Substring(0, num).LastIndexOf("delete");
            if (((((num3 > num4) && (num3 > num5)) && (num3 > num6)) ? 1 : 0) != 0)
            {
                return this.CheckAdditionalValidity(def, num, num2, true);
            }
            int index = def.IndexOf("from ", num);
            if ((index > -1) && (index < num2))
            {
                return this.CheckAdditionalValidity(def, num, num2, false);
            }
            int num8 = def.IndexOf("set ", num);
            if ((num8 > -1) && (num8 < num2))
            {
                return this.CheckAdditionalValidity(def, num, num2, false);
            }
            int num9 = def.IndexOf("where ", num);
            return (((num9 > -1) && (num9 < num2)) && this.CheckAdditionalValidity(def, num, num2, false));
        }

        private string RemoveComments(string def)
        {
            int index = def.IndexOf(this._blockCommentStart);
            for (int i = def.IndexOf(this._blockCommentEnd); (index > -1) && (i > index); i = def.IndexOf(this._blockCommentEnd))
            {
                def = def.Remove(index, (i + 2) - index);
                index = def.IndexOf(this._blockCommentStart);
            }
            if (this._lineComment2 == null)
            {
                if (!def.Contains(this._lineComment))
                {
                    return def;
                }
            }
            else if (!def.Contains(this._lineComment) && !def.Contains(this._lineComment2))
            {
                return def;
            }
            string[] strArray = def.Split("\n".ToCharArray());
            for (int j = 0; j < strArray.Length; j++)
            {
                string str = strArray[j];
                index = str.IndexOf(this._lineComment);
                if (index > -1)
                {
                    str = str.Remove(index, str.Length - index);
                }
                if (this._lineComment2 != null)
                {
                    index = str.IndexOf(this._lineComment2);
                    if (index > -1)
                    {
                        str = str.Remove(index, str.Length - index);
                    }
                }
            }
            def = string.Join("\n", strArray);
            return def;
        }

        private string RemoveParameters(string def)
        {
            return this.RemoveWords(def, this._paramToken);
        }

        private string RemoveStrings(string def, string token)
        {
            def = def.Replace(token, string.Empty);
            return def;
        }

        private string RemoveTempObjects(string def)
        {
            return this.RemoveWords(def, this._tempObjectToken);
        }

        private string RemoveWords(string def, string token)
        {
            int index = def.IndexOf(token);
            if (index > -1)
            {
                int num2 = def.IndexOfAny(this._tokenDelimiters.ToCharArray(), index);
                while ((num2 > -1) && (num2 > index))
                {
                    def = def.Remove(index, num2 - index);
                    index = def.IndexOf(token);
                    if (index > -1)
                    {
                        num2 = def.IndexOfAny(this._tokenDelimiters.ToCharArray(), index);
                    }
                    else
                    {
                        num2 = -1;
                    }
                }
            }
            return def;
        }

        private bool SemanticValidStatement(string def, Table t, Column col, int idxTable, int idxCol)
        {
            string str = this.GetTableAlias(def, t, idxTable);
            string tableAlias = this.GetTableAlias(def, idxCol);
            string str3 = this.GetTableAlias(def, idxTable);
            bool flag = false;
            if (str == null)
            {
                if (tableAlias == null)
                {
                    if (this._ignoreSchema)
                    {
                        return true;
                    }
                    if (str3 == t.Schema.ToLower())
                    {
                        flag = true;
                    }
                    return flag;
                }
                if (tableAlias.Trim() == string.Empty)
                {
                    if (this._ignoreSchema)
                    {
                        return true;
                    }
                    if (str3 == t.Schema)
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            if (str.Trim() != string.Empty)
            {
                if (tableAlias == null)
                {
                    if (this._ignoreSchema)
                    {
                        return true;
                    }
                    if (str3 == t.Schema.ToLower())
                    {
                        flag = true;
                    }
                    return flag;
                }
                if ((tableAlias.Trim() != string.Empty) && (str == tableAlias))
                {
                    if (this._ignoreSchema)
                    {
                        return true;
                    }
                    if (str3 == t.Schema.ToLower())
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        #endregion Methods
    }
}