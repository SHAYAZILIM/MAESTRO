using AvukatproUpdater.Common.Events;
using System.Windows.Forms;

namespace AvukatproUpdater.Common.Controls
{
    public partial class UpdateFormBase : Form
    {
        #region Fields

        private OperationType operationType;

        #endregion Fields

        #region Constructors

        public UpdateFormBase()
        {
            InitializeComponent();
            UpdateOperationChanged += new UpdateEventHandler(SwitchToOperation);
        }

        #endregion Constructors

        #region Delegates

        public delegate void UpdateEventHandler(object sender, UpdateEventArgs e);

        #endregion Delegates

        #region Events

        public event UpdateEventHandler UpdateOperationChanged;

        #endregion Events

        #region Properties

        public OperationType OperationType
        {
            get { return operationType; }
            set
            {
                operationType = value;
                if (UpdateOperationChanged != null)
                    UpdateOperationChanged(this, new UpdateEventArgs(operationType));
            }
        }

        #endregion Properties

        #region Methods

        public virtual void SwitchToOperation(object sender, UpdateEventArgs e)
        {
        }

        #endregion Methods
    }
}