using System;
using System.Windows.Forms;

namespace PixTracker
{
    public partial class ScenarioPlayResult : UserControl
    {
        public event EventHandler ReLoadScenarioList;

        public ScenarioPlayResult()
        {
            InitializeComponent();
        }

        public Scenario ScenarioDetails { get; set; }

        private void playTest_Click(object sender, EventArgs e)
        {
            ScenarioDetails.LoadScenario();
            ScenarioDetails.RunTest();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ScenarioDetails.Delete();
            if (ReLoadScenarioList != null)
                ReLoadScenarioList(null, null);
        }
    }
}
