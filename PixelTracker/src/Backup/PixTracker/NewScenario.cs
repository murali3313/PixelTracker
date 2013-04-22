using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PixTracker.Properties;
using RecordAndPlayBack;

namespace PixTracker
{
    public partial class NewScenario : UserControl
    {
        public NewScenario()
        {
            InitializeComponent();
        }

        private void playBack(object sender, EventArgs e)
        {
            FindForm().TopLevel = false;
            SendToBack();
            PlayBack.CompleteAssertionList=new AssertionAction();
            scenarioActioAssertion.ForEach(action => action.Execute());
            var assertionReports = new AssertionReports();
            assertionReports.AssertionAction = PlayBack.CompleteAssertionList;
            assertionReports.ShowDialog();
            FindForm().TopLevel = true;
        }

        private void AssertionStart(object sender, EventArgs e)
        {
            FindForm().SendToBack();
            if (btnStartAssertion.Text == Resources.NewScenario_AssertionStart_Start_Assertion)
            {
                UnsubscribeForMouseMove();
                scenarioActioAssertion.Add(recAct);
                recAct=new RecordAction();
                UnSubscribeForClickEventsAndRemoveLastClickActions();
                var screenCapture = new ScreenCapture();
                var captureScreen = screenCapture.CaptureScreen();
                var assertBox = new AssertBox { ScreenShot = captureScreen };
                assertBox.Closing += assertBox_Closing;
                assertBox.ShowDialog();
                btnStartAssertion.Text = Resources.NewScenario_AssertionStart_Continue_Test_Actions;
            }
            else
            {
                SubScribeForMouseMove();
                SubscribeForClickAndKeyActions();
                btnStartAssertion.Text = Resources.NewScenario_AssertionStart_Start_Assertion;
            }
        }

        void assertBox_Closing(object sender, CancelEventArgs e)
        {
            scenarioActioAssertion.Add(AssertBox.AssertionData);
            AssertBox.AssertionData=new AssertionAction();
        }

        private void SubscribeForClickAndKeyActions()
        {
            globalEventProvider.MouseClick += MouseClicked;
            globalEventProvider.KeyUp += globalEventProvider_KeyUp;
        }

        private void UnSubscribeForClickEventsAndRemoveLastClickActions()
        {
            UnSubscribeMouseKeyAction();
            if (recAct == null || recAct.ActionArgs == null || recAct.ActionArgs.Count < 2) return;
            recAct.ActionArgs.RemoveAt(recAct.ActionArgs.Count - 1);
            recAct.ActionArgs.RemoveAt(recAct.ActionArgs.Count - 1);
        }

        private void UnSubscribeMouseKeyAction()
        {
            globalEventProvider.MouseClick -= MouseClicked;
            globalEventProvider.KeyUp -= globalEventProvider_KeyUp;
        }

        private void btnRecordStart_Click(object sender, EventArgs e)
        {
            StartTestPositionChange();
            recAct = new RecordAction();
            AssertBox.AssertionData = new AssertionAction();
            globalEventProvider.MouseClick += MouseClicked;
            globalEventProvider.KeyUp += globalEventProvider_KeyUp;
            btnRecordStart.Enabled = false;
            btnStartAssertion.Enabled = true;
            btnFlushAll.Enabled = true;
        }

        void globalEventProvider_MouseMove(object sender, MouseEventArgs e)
        {
            var parentForm = FindForm();
            if (e.X >= parentForm.Location.X && e.X <= parentForm.Location.X + parentForm.Width && e.Y <= 100)
            {
                parentForm.TopMost = true;
                parentForm.BringToFront();
                parentForm.Visible = true;
            }
            else
            {
//                parentForm.SendToBack();
                parentForm.Visible = false;
            }

        }

        void globalEventProvider_KeyUp(object sender, KeyEventArgs e)
        {
           recAct.Record(GlobalActionType.KeyIn, e);
        }

        private readonly List<IAssertionAction> scenarioActioAssertion = new List<IAssertionAction>();

        IRecordAction recAct = new RecordAction();

        void MouseClicked(object sender, MouseEventArgs e)
        {
            recAct.Record(GlobalActionType.MouseClick, e);
        }

        private  void flushAll_Click(object sender, EventArgs e)
        {
            recAct=new RecordAction();
            UnSubscribeMouseKeyAction();
            btnRecordStart.Enabled = true;
            btnStartAssertion.Enabled = false;
            btnStartPlayBack.Enabled = false;
            btnStartAssertion.Text = Resources.NewScenario_AssertionStart_Start_Assertion;
        }

        private void BtnEndTestClick(object sender, EventArgs e)
        {
            scenarioActioAssertion.Add(recAct);
            PlaceFormInTheCenter();
            btnStartPlayBack.Enabled = true;
            btnStartAssertion.Enabled = false;
            btnFlushAll.Enabled = false;
            btnStartAssertion.Text = Resources.NewScenario_AssertionStart_Start_Assertion;
            UnSubscribeForClickEventsAndRemoveLastClickActions();
        }

        private void PlaceFormInTheCenter()
        {
            var parentForm = FindForm();
            var primaryScreen = Screen.PrimaryScreen;
            var screenWidth = primaryScreen.WorkingArea.Width;
            var screenHeight = primaryScreen.WorkingArea.Height;
            var startPositionLeft = (screenWidth/2)-(parentForm.Width/2);
            var startPositionTop = (screenHeight/2)-(parentForm.Height/2);
            parentForm.Location=new Point(startPositionLeft,startPositionTop);
            UnsubscribeForMouseMove();
        }

        private void StartTestPositionChange()
        {

            var parentForm = FindForm();
            parentForm.StartPosition = FormStartPosition.Manual;
            var primaryScreen = Screen.PrimaryScreen;
            var screenWidth = primaryScreen.WorkingArea.Width;
            var startPositionLeft = (screenWidth / 2) - (parentForm.Width / 2);
            var startPositionTop = -150;
            parentForm.Location = new Point(startPositionLeft, startPositionTop);
            FindForm().SendToBack();
            SubScribeForMouseMove();
        }

        private void UnsubscribeForMouseMove()
        {
            globalEventProvider.MouseMove -= globalEventProvider_MouseMove;
        }

        private void SubScribeForMouseMove()
        {
            globalEventProvider.MouseMove += globalEventProvider_MouseMove;
        }

        private void BtnSaveTestClick(object sender, EventArgs e)
        {

            var pkscenarioID = Repository.Instance.ExecuteScalar<int>(string.Format("INSERT INTO T_Scenario (Description,IgnoreScenario) VALUES ('{0}',{1})   SELECT @@Identity", txtScenarioDesc.Text,0));
            var order = 1;
            scenarioActioAssertion.ForEach(action => action.Save(order++, pkscenarioID));   
        }

        private void NewScenario_Load(object sender, EventArgs e)
        {

        }
    }
}
