using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.CustomControls
{
    public class DoubleButton : SimpleButton
    {
        public DoubleButton()
        {
            if (DesignMode) return;

            FirstButton.Left = this.Left;
            FirstButton.Top = this.Top;
            FirstButton.Width = this.Width;
            FirstButton.Height = this.Height;
            FirstButton.Visible = true;
            this.Visible = false;
            SecondButton = FirstButton;
        }

        private SimpleButton firstButton;

        private SimpleButton secondButton;

        private SimpleButton selectedButton;

        public SimpleButton FirstButton
        {
            get
            {
                if (firstButton == null) firstButton = new SimpleButton();
                return firstButton;
            }
            set { firstButton = value; }
        }

        public string FirstButtonText { get; set; }

        public SimpleButton SecondButton
        {
            get
            {
                if (secondButton == null) secondButton = new SimpleButton();
                return secondButton;
            }
            set { secondButton = value; }
        }

        public string SecondButtonText { get; set; }

        public SimpleButton SelectedButton
        {
            get
            {
                if (selectedButton == null) selectedButton = new SimpleButton();
                return selectedButton;
            }
            set { selectedButton = value; }
        }

        public void ShowFirstButton()
        {
            FirstButton.Left = this.Left;
            FirstButton.Top = this.Top;
            FirstButton.Width = this.Width;
            FirstButton.Height = this.Height;
            FirstButton.Visible = true;
            this.Visible = false;
            SecondButton = FirstButton;
        }

        public void ShowSelectSecond()
        {
            SecondButton.Left = this.Left;
            SecondButton.Top = this.Top;
            SecondButton.Width = this.Width;
            SecondButton.Height = this.Height;
            SecondButton.Visible = true;
            this.Visible = false;
            SecondButton = secondButton;
        }
    }
}