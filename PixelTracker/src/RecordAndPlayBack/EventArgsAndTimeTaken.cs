using System;
using System.Windows.Forms;

namespace RecordAndPlayBack
{
    public class EventArgsAndTimeTaken
    {
        public Double lagTime { get; set; }
        public EventArgs eventArgs { get; set; }
        public bool IsCapsLockON { get; set; }

        public int ID { get; set; }

        public int Order { get; set; }

        public void Save(int actionOrder, int pkactionID)
        {
            var X = eventArgs is MouseEventArgs ? ((MouseEventArgs)eventArgs).X : 0;
            var Y = eventArgs is MouseEventArgs ? ((MouseEventArgs)eventArgs).Y : 0;
            var keyValue = eventArgs is KeyEventArgs ? "'" + char.ConvertFromUtf32(((KeyEventArgs)eventArgs).KeyValue) + "'" : "''";
            Repository.Instance.ExecuteNonQuery(
            string.Format(@"INSERT INTO T_ActionData (
                            FK_ActionID,
                            ActionOrder,
                            LagTime,
                            X,
                            Y,
                            IsMouseAction,
                            IsCapsLockON,
                            KeyValue) 
                   VALUES ( {0},
                            {1},
                            {2},
                            {3},
                            {4},
                            {5},
                            {6},
                            {7})",
                             pkactionID,
                             actionOrder,
                             lagTime,
                             X,
                             Y,
                             (eventArgs is MouseEventArgs) ? 1 : 0,
                             IsCapsLockON ? 1 : 0,
                             keyValue
                             ));
        }
    }
}