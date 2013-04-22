using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Gma.UserActivityMonitor;

namespace RecordAndPlayBack
{
    public class RecordAction:IRecordAction
    {
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        private DateTime lastActionTime;
        public RecordAction()
        {
            lastActionTime = DateTime.Now;
        }
        private List<EventArgsAndTimeTaken> actionArgs = new List<EventArgsAndTimeTaken>();
        public List<EventArgsAndTimeTaken> ActionArgs
        {
            get { return actionArgs; }
            set { actionArgs = value; }
        }

        public int ID { get; set; }

        public void Record(GlobalActionType actionType, EventArgs e)
        {
            var eventArgsAndTimeTaken = new EventArgsAndTimeTaken() {eventArgs = e, lagTime = DateTime.Now.Subtract(lastActionTime).TotalMilliseconds};
            if (e is KeyEventArgs)
            {
                var isCapsLockOn = GetKeyState(20);
                eventArgsAndTimeTaken.IsCapsLockON = isCapsLockOn==1?true:false;
            }

            ActionArgs.Add(eventArgsAndTimeTaken);
            lastActionTime=DateTime.Now;
        }

        public void Execute()
        {
            var playBack = new PlayBack();
            playBack.Play(this);
        }

        public void Save(int order, int scenarioID)
        {
            var pkactionID= Repository.Instance.ExecuteScalar<int>(string.Format("INSERT INTO T_ActionAssertion (FK_ScenarioID,TestType,ActionOrder) VALUES ({0},{1},{2})  SELECT @@Identity", scenarioID,(int)TestType.Action,order));
            var actionOrder = 1;
            actionArgs.ForEach(taken => taken.Save(actionOrder++,pkactionID));
        }

        public void Load()
        {
            var recordedAction = Repository.Instance.LoadDataTableWithQuery("Select * from T_ActionData Where FK_ActionID=" + ID);
            bool mouseButtonToggle = true;
            foreach (DataRow recordAction in recordedAction.Rows)
            {
                var pk_ID = Convert.ToInt32(recordAction["PK_ID"]);
                var actionOrder = Convert.ToInt32(recordAction["ActionOrder"]);
                var lagTime = Convert.ToDouble(recordAction["LagTime"]);
                var X = Convert.ToInt32(recordAction["X"]);
                var Y = Convert.ToInt32(recordAction["Y"]);
                var IsMouseAction = Convert.ToBoolean(recordAction["IsMouseAction"]);
                var isCapsLockON = Convert.ToBoolean(recordAction["IsCapsLockON"]);
                var keyValue = Convert.ToString(recordAction["KeyValue"]);

                try
                {

                    EventArgs e;
                    if (IsMouseAction)
                    {
                        e = new MouseEventExtArgs(MouseButtons.Left, 1, X, Y, 0, mouseButtonToggle);
                        mouseButtonToggle = !mouseButtonToggle;
                    }
                    else
                    {
                        if (keyValue == "\r")
                            keyValue = Keys.Enter.ToString();
                        var keyValueEntered = (Keys)Enum.Parse(typeof(Keys), keyValue);
                        e = new KeyEventArgs(keyValueEntered);
                    }

                    var eventArgsAndTimeTaken = new EventArgsAndTimeTaken()
                                                    {
                                                        ID = pk_ID,
                                                        lagTime = lagTime,
                                                        IsCapsLockON = isCapsLockON,
                                                        eventArgs = e,
                                                        Order = actionOrder
                                                    };

                    actionArgs.Add(eventArgsAndTimeTaken);
                }
                catch (Exception)
                {

             
                }

            }
        }
    }

    public class PlayBack : IPlayBack
    {

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,UIntPtr dwExtraInfo);

        public void Play(IRecordAction recordedAction)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
            (UIntPtr)0);

            for (var i = 0; i < recordedAction.ActionArgs.Count; i++)
            {
                var eventArgsAndTimeTaken = recordedAction.ActionArgs[i];
                var args = eventArgsAndTimeTaken.eventArgs;
                if (args is MouseEventExtArgs)
                {
                    var mouseArgs = args as MouseEventExtArgs;
                    SetCursorPos(mouseArgs.X, mouseArgs.Y);
                    var down = mouseArgs.Button == MouseButtons.Left ? (int)MouseEventType.LeftDown : (int)MouseEventType.RightDown;
                    var up = mouseArgs.Button == MouseButtons.Left ? (int)MouseEventType.LeftUp : (int)MouseEventType.LeftDown;
                   
                    if (mouseArgs.IsMouseButtonDown)
                    {
                     mouse_event(down, mouseArgs.X, mouseArgs.Y, 0, 0);
                    }
                    else
                    {
                     mouse_event(up, mouseArgs.X, mouseArgs.Y, 0, 0);
                    }
                }
                else
                {
                    var keyArgs = args as KeyEventArgs;
                    var keyValue = char.ConvertFromUtf32(keyArgs.KeyValue);
                    keyValue = keyValue.ToLower();
                    if (eventArgsAndTimeTaken.IsCapsLockON)
                    {
                        SendKeys.SendWait("{CAPSLOCK}" + keyValue);
                    }
                    else
                    {
                        SendKeys.Send(keyValue);
                    }
                }
                if ((i + 1) < recordedAction.ActionArgs.Count)
                    Thread.Sleep(Convert.ToInt32(recordedAction.ActionArgs[i + 1].lagTime));


            }
        }
        public static AssertionAction CompleteAssertionList=new AssertionAction();
        private ImageCompare imageComparer = new ImageCompare();
        public void Assert(AssertionAction assertionData)
        {
            var screenCapture = new ScreenCapture();
            var captureScreen = screenCapture.CaptureScreen();
            foreach (var assertionDatum in assertionData)
            {
                var bitmap = new Bitmap(captureScreen);
                var startPointX = assertionDatum.CropInfo.X;
                var startPointY = assertionDatum.CropInfo.Y;
                var width = assertionDatum.CropInfo.Width;
                var height = assertionDatum.CropInfo.Height;
                var markingRect = new Rectangle(startPointX, startPointY, width, height);
                var clonedImage = bitmap.Clone(markingRect, bitmap.PixelFormat);
                var compareImage = imageComparer.CompareImage(clonedImage, assertionDatum.ExpectedImage);
                assertionDatum.ActualImage = clonedImage;
                if (compareImage <= 10)
                    assertionDatum.IsSuccess = true;
                CompleteAssertionList.Add(assertionDatum);
            }
            
        }
    }

    public interface IPlayBack
    {
        void Play(IRecordAction recordedAction);
    }

    public enum MouseEventType
    {
        LeftDown = 0x02,
        LeftUp = 0x04,
        RightDown = 0x08,
        RightUp = 0x10
    }
    public interface IRecordAction:IAssertionAction
    {
        void Record(GlobalActionType actionType, EventArgs e);
        List<EventArgsAndTimeTaken> ActionArgs { get; set; }
    }
}
