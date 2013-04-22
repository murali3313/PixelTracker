using System;
using System.Drawing;
using System.Windows.Forms;

namespace PixTracker
{
    public partial class PixTracker : Form
    {
        public PixTracker()
        {
            InitializeComponent();
            ViewEditScenario(null,null);

        }

        private void ViewEditScenario(object sender, EventArgs e)
        {
            ClearPanel();
            var viewEditScenario = new ViewEditScenario();
            pnlContainer.Controls.Add(viewEditScenario);
        }

        private void ClearPanel()
        {
            pnlContainer.Controls.Clear();
        }

        private void CreateNewScenario(object sender, EventArgs e)
        {
            ClearPanel();
            var newScenario = new NewScenario();
            pnlContainer.Controls.Add(newScenario);
        }
    }
}
