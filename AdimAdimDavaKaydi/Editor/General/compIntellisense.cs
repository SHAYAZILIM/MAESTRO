using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.Editor.General
{
    public class compIntellisense : ListBox
    {
        public compIntellisense()
        {
            if (DesignMode)
            {
                return;
            }
            this.Visible = false;
            this.Height = 150;
            this.Width = 150;
        }

        private bool activate;

        private List<AvukatProLib.Arama.per_TDIE_KOD_SOZLUK> datasource;

        private TextControl myEditor;

        private bool sozcukDenetimi;

        private ToolTip toolTip1 = new ToolTip();

        public bool Activate
        {
            get { return activate; }
            set
            {
                activate = value;
                if (!value)
                {
                    this.Visible = false;
                    toolTip1.Hide(this);
                }
            }
        }

        public List<AvukatProLib.Arama.per_TDIE_KOD_SOZLUK> MyDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return new List<AvukatProLib.Arama.per_TDIE_KOD_SOZLUK>();
                }
                return datasource;
            }
            set
            {
                if (!DesignMode && value != null)
                {
                    datasource = value;
                }
            }
        }

        public TextControl MyEditor
        {
            get { return myEditor; }
            set
            {
                myEditor = value;
                if (!DesignMode && value != null)
                {
                    myEditor.KeyDown += myEditor_KeyDown;
                    myEditor.Controls.Add(this);

                    myEditor.MouseMove += myEditor_MouseMove;
                }
            }
        }

        public bool SozcukDenetle
        {
            get { return sozcukDenetimi; }
            set
            {
                sozcukDenetimi = value;
                string[] kelimeler = myEditor.Text.Split(' ');
                if (!value)
                {
                    if (myEditor.Selection != null)
                    {
                        for (int i = 0; i < kelimeler.Length; i++)
                        {
                            int startind = myEditor.Find(kelimeler[i], 0, FindOptions.MatchCase);
                            myEditor.Selection.Start = startind;
                            myEditor.Selection.Length = kelimeler[i].Length;
                            myEditor.Selection.Underline = FontUnderlineStyle.None;
                        }
                    }
                }
                else
                {
                    if (!activate)
                    {
                        Activate = true;
                    }
                    for (int i = 0; i < kelimeler.Length; i++)
                    {
                        bool finded = false;
                        for (int y = 0; y < datasource.Count; y++)
                        {
                            if (kelimeler[i].ToLower() == datasource[y].KELIME.ToLower())
                            {
                                finded = true;
                            }
                        }
                        if (finded)
                        {
                            int startind = myEditor.Find(kelimeler[i], 0, FindOptions.MatchCase);
                            myEditor.Selection.Start = startind;
                            myEditor.Selection.Length = kelimeler[i].Length;
                            myEditor.Selection.Underline = FontUnderlineStyle.None;
                        }
                        else
                        {
                            int startind = myEditor.Find(kelimeler[i], 0, FindOptions.MatchCase);
                            myEditor.Selection.Start = startind;
                            myEditor.Selection.Length = kelimeler[i].Length;
                            myEditor.Selection.Underline = FontUnderlineStyle.Doubled;
                        }
                    }
                }
            }
        }

        public void Find(string text)
        {
            if (!activate)
            {
                return;
            }
            this.FindString(text);
        }

        private string GetWordFromIndex(int Index)
        {
            if (!activate)
            {
                return "";
            }
            string CompleteText = myEditor.Text.Replace("\r\n", "\n");
            Char[] chars = new[] { ',', ';', ':', '!', '?', '.', ' ', (char)9, (char)10 };

            int lastChar = CompleteText.IndexOfAny(chars, Index);

            if (lastChar != -1)
                CompleteText = CompleteText.Substring(0, lastChar);

            int firstChar = CompleteText.LastIndexOfAny(chars);

            return CompleteText.Substring(firstChar + 1);
        }

        private void myEditor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!activate)
            {
                return;
            }
            this.Height = 150;
            this.Width = 150;

            if (this.myEditor.Selection.Start == 0)
            {
                return;
            }
            this.Location = new System.Drawing.Point(myEditor.InputPosition.Location.X / 15,
                                                     ((myEditor.InputPosition.Location.Y +
                                                       myEditor.TextChars[myEditor.InputPosition.TextPosition].Bounds.
                                                           Height - myEditor.ScrollLocation.Y) / 15));
            InputPosition ip = new InputPosition(myEditor.Selection.Start);
            this.BringToFront();
            string veri = myEditor.Selection.Text;

            // myEditor.Selection.Start = myEditor.Selection.Start - (myEditor.Selection.Start - 1);
            int nekadar = (myEditor.Selection.Start - 1);
            int bosluk = myEditor.Text.IndexOf(' ', 0, nekadar);
            if (myEditor.Text.Length > bosluk)
            {
                string kelime = myEditor.Text.Substring(bosluk + 1, myEditor.Text.Length - (bosluk + 1));
                this.Find(kelime);
            }
        }

        private void myEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (!activate)
            {
                return;
            }
            TextChar chr = myEditor.TextChars.GetItem(e.Location, true);
            if (chr == null)
            {
                return;
            }
            int charIndex = chr.Number;
            string currentWord = GetWordFromIndex(charIndex);
            if (datasource == null)
            {
                return;
            }
            if (currentWord != "")
            {
                toolTip1.ToolTipTitle = currentWord;
                string anlami = "kelime tanýtýlmamýþ";
                for (int y = 0; y < datasource.Count; y++)
                {
                    if (currentWord.ToLower() == datasource[y].KELIME.ToLower())
                    {
                        anlami = datasource[y].ANLAMI;
                    }
                }

                if (anlami.Contains(","))
                {
                    anlami = anlami.Replace(",", "," + Environment.NewLine);
                }
                if (anlami.Contains("."))
                {
                    anlami = anlami.Replace(".", "." + Environment.NewLine);
                }

                //toolTip1.Container = myEditor.Container;
                toolTip1.Show("Index: " + charIndex + " : " + anlami, this, e.X - 220, e.Y - 200);
            }
            else
                toolTip1.Hide(this);
        }
    }
}