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
    public partial class ReasonBox : Form
    {
        private readonly AssertionData assertionDatum;

        public ReasonBox(AssertionData assertionDatum)
        {
            this.assertionDatum = assertionDatum;
            InitializeComponent();
            lblFailureNum.Text = assertionDatum.AssertionIndex.ToString();
        }


        private void btnSaveReason_Click(object sender, EventArgs e)
        {
            assertionDatum.FailureReason = txtFailureReason.Text;
            this.Close();
        }
    }
}
