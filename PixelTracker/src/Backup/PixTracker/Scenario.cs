using System;
using System.Collections.Generic;
using System.Data;
using RecordAndPlayBack;
using System.Linq;

namespace PixTracker
{
    public class Scenario
    {
        public bool IgnoreScenario { get; set; }
        public string Description { get; set; }

        public int ScenarioID { get; set; }
        readonly List<IAssertionAction> playAssertCollection=new List<IAssertionAction>();
        public void LoadScenario()
        {
            playAssertCollection.Clear();
            PlayBack.CompleteAssertionList.Clear();
            DataTable assertionActions = Repository.Instance.LoadDataTableWithQuery("select * from T_ActionAssertion Where FK_ScenarioID="+ScenarioID);
            foreach (DataRow assertion in assertionActions.Rows.Cast<DataRow>().OrderBy(row => row["ActionOrder"]))
            {
                var testType = Convert.ToString(assertion["TestType"]);
                var testTypeEnum = (TestType)Enum.Parse(typeof (TestType), testType);
                if(testTypeEnum==TestType.Action)
                {
                    var recordAction = new RecordAction() {ID = Convert.ToInt32(assertion["PK_ID"])};
                    playAssertCollection.Add(recordAction);
                }
                else
                {
                    var assertionAction1 = new AssertionAction() { ID = Convert.ToInt32(assertion["PK_ID"]) };
                    playAssertCollection.Add(assertionAction1);
                }
            }

            playAssertCollection.ForEach(action => action.Load());
        }

        public void RunTest()
        {
            playAssertCollection.ForEach(action => action.Execute());
            var assertionReports = new AssertionReports();
            assertionReports.AssertionAction = PlayBack.CompleteAssertionList;
            assertionReports.ShowDialog();
        }

        public void Delete()
        {
            Repository.Instance.LoadDataTableWithQuery("DELETE FROM T_Scenario Where PK_ID=" + ScenarioID);
            
        }
    }
}