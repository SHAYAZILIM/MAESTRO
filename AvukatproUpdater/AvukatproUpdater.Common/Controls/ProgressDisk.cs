using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AvukatproUpdater.Common.Controls
{
    #region Enumerations

    public enum BlockSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        XXLarge
    }

    #endregion Enumerations

    public partial class ProgressDisk : UserControl
    {
        #region Fields

        private Color activeforeColor1 = Color.Blue;
        private Color activeforeColor2 = Color.LightBlue;
        private Color backGrndColor = Color.Transparent;
        private GraphicsPath bkGroundPath1 = new GraphicsPath();
        private GraphicsPath bkGroundPath2 = new GraphicsPath();
        private float blockRatio = 0.4f;
        private BlockSize bs = BlockSize.Small;
        private GraphicsPath freGroundPath = new GraphicsPath();
        private Color inactiveforeColor1 = Color.Green;
        private Color inactiveforeColor2 = Color.LightGreen;
        private Region region = new Region();
        private int size = 12;
        private int sliceCount;
        private Timer timer = new Timer();
        private int value;
        private GraphicsPath valuePath = new GraphicsPath();

        #endregion Fields

        #region Constructors

        public ProgressDisk()
        {
            this.InitializeComponent();
            this.timer.Tick += new EventHandler(this.timer_Tick);
            this.Render();
        }

        #endregion Constructors

        #region Properties

        [DefaultValue(typeof(Color), "Blue")]
        public Color ActiveForeColor1
        {
            get
            {
                return this.activeforeColor1;
            }
            set
            {
                this.activeforeColor1 = value;
                this.Render();
            }
        }

        [DefaultValue(typeof(Color), "LightBlue")]
        public Color ActiveForeColor2
        {
            get
            {
                return this.activeforeColor2;
            }
            set
            {
                this.activeforeColor2 = value;
                this.Render();
            }
        }

        [DefaultValue(typeof(Color), "White")]
        public Color BackGroundColor
        {
            get
            {
                return this.backGrndColor;
            }
            set
            {
                this.backGrndColor = value;
                this.Render();
            }
        }

        [DefaultValue(typeof(BlockSize), "Small")]
        public BlockSize BlockSize
        {
            get
            {
                return this.bs;
            }
            set
            {
                this.bs = value;
                switch (this.bs)
                {
                    case BlockSize.XSmall:
                        this.blockRatio = 0.49f;
                        return;

                    case BlockSize.Small:
                        this.blockRatio = 0.4f;
                        return;

                    case BlockSize.Medium:
                        this.blockRatio = 0.3f;
                        return;

                    case BlockSize.Large:
                        this.blockRatio = 0.2f;
                        return;

                    case BlockSize.XLarge:
                        this.blockRatio = 0.1f;
                        return;

                    case BlockSize.XXLarge:
                        this.blockRatio = 0.01f;
                        return;
                }
            }
        }

        [DefaultValue(typeof(Color), "Green")]
        public Color InactiveForeColor1
        {
            get
            {
                return this.inactiveforeColor1;
            }
            set
            {
                this.inactiveforeColor1 = value;
                this.Render();
            }
        }

        [DefaultValue(typeof(Color), "LightGreen")]
        public Color InactiveForeColor2
        {
            get
            {
                return this.inactiveforeColor2;
            }
            set
            {
                this.inactiveforeColor2 = value;
                this.Render();
            }
        }

        [DefaultValue(12)]
        public int SliceCount
        {
            get
            {
                return this.sliceCount;
            }
            set
            {
                this.sliceCount = value;
            }
        }

        [DefaultValue(12)]
        public int SquareSize
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
                base.Size = new Size(this.size, this.size);
            }
        }

        [DefaultValue(0)]
        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                this.Render();
            }
        }

        #endregion Properties

        #region Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.region = new Region(base.ClientRectangle);
            if (this.backGrndColor == Color.Transparent)
            {
                this.region.Exclude(this.bkGroundPath2);
                base.Region = this.region;
            }
            e.Graphics.FillPath(new SolidBrush(this.backGrndColor), this.bkGroundPath1);
            e.Graphics.FillPath(new LinearGradientBrush(new Rectangle(0, 0, this.size, this.size), this.inactiveforeColor1, this.inactiveforeColor2, (float)((this.value * 360) / 12), true), this.valuePath);
            e.Graphics.FillPath(new LinearGradientBrush(new Rectangle(0, 0, this.size, this.size), this.activeforeColor1, this.activeforeColor2, (float)((this.value * 360) / 12), true), this.freGroundPath);
            e.Graphics.FillPath(new SolidBrush(this.backGrndColor), this.bkGroundPath2);
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            this.size = Math.Max(base.Width, base.Height);
            base.Size = new Size(this.size, this.size);
            this.Render();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.size = Math.Max(base.Width, base.Height);
            base.Size = new Size(this.size, this.size);
            this.Render();
            base.OnSizeChanged(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (base.Visible)
            {
                this.timer.Enabled = true;
            }
            else
            {
                this.timer.Enabled = false;
            }
            base.OnVisibleChanged(e);
        }

        private void Render()
        {
            this.bkGroundPath1.Reset();
            this.bkGroundPath2.Reset();
            this.valuePath.Reset();
            this.freGroundPath.Reset();
            this.bkGroundPath1.AddPie(new Rectangle(0, 0, this.size, this.size), 0f, 360f);
            if (this.sliceCount == 0)
            {
                this.sliceCount = 12;
            }
            float num = 360 / this.sliceCount;
            float sweepAngle = num - 5f;
            for (int i = 0; i < this.sliceCount; i++)
            {
                if (this.value != i)
                {
                    this.valuePath.AddPie(0, 0, this.size, this.size, i * num, sweepAngle);
                }
            }
            this.bkGroundPath2.AddPie((float)((this.size / 2) - (this.size * this.blockRatio)), (float)((this.size / 2) - (this.size * this.blockRatio)), (float)((this.blockRatio * 2f) * this.size), (float)((this.blockRatio * 2f) * this.size), 0f, 360f);
            this.freGroundPath.AddPie(new Rectangle(0, 0, this.size, this.size), this.value * num, sweepAngle);
            base.Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Value = (this.Value + 1) % 12;
        }

        #endregion Methods
    }
}