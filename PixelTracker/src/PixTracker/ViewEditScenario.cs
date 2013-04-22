using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RecordAndPlayBack;

namespace PixTracker
{
    public partial class ViewEditScenario : UserControl
    {
        public ViewEditScenario()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var scenarioTable = Repository.Instance.LoadDataTableWithQuery("Select * From T_Scenario");
            var scenarioList= (from DataRow scenarioRow in scenarioTable.Rows
                               select new Scenario()
                                          {
                                              ScenarioID=Convert.ToInt32(scenarioRow["PK_ID"]),
                                              Description = Convert.ToString(scenarioRow["Description"]),
                                              IgnoreScenario = Convert.ToBoolean(scenarioRow["IgnoreScenario"])
                                          }).ToList();
            this.cntPanel.Controls.Clear();

            foreach (var scenario in scenarioList)
            {
                var scenarioPlayResult = new ScenarioPlayResult {ScenarioDetails = scenario};
                scenarioPlayResult.ReLoadScenarioList+=ReloadScenarioList;
                    
               cntPanel.Controls.Add(scenarioPlayResult);
            }
        }

        void ReloadScenarioList(object sender, EventArgs e)
        {
            OnLoad(null);
        }
    }
}
