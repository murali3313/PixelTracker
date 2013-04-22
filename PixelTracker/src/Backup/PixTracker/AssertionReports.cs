using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RecordAndPlayBack;

namespace PixTracker
{
    public partial class AssertionReports : Form
    {
        public AssertionReports()
        {
            InitializeComponent();
        }

        private AssertionAction assertionAction;
        public AssertionAction AssertionAction
        {
            get { return assertionAction; }
            set { assertionAction = value;
                dgReports.DataSource = value;
                
            }
        }
    }
}
