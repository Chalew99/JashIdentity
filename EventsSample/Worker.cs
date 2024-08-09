using System;
using System.Threading;

namespace EventsSample
{

    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
                Thread.Sleep(3000);
            }
            OnWorkCompleted();
        }
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //Raising Events only if Listeners are attached
            //Approach1
            if (WorkPerformed != null)
            {
                WorkPerformedEventArgs e = new WorkPerformedEventArgs()
                {
                    Hours = hours,
                    WorkType = workType
                };
                WorkPerformed(this, e);
            }

            //Approach2
            //EventHandler<WorkPerformedEventArgs> del1 = WorkPerformed as EventHandler<WorkPerformedEventArgs;
            //if (del1 != null)
            //{
            //    WorkPerformedEventArgs e = new WorkPerformedEventArgs()
            //    {
            //        Hours = hours,
            //        WorkType = workType
            //    };
            //    del1(this, e);
            //}
            //Approach3
            //if (WorkPerformed is EventHandler<WorkPerformedEventArgs> del2)
            //{
            //    WorkPerformedEventArgs e = new WorkPerformedEventArgs()
            //    {
            //        Hours = hours,
            //        WorkType = workType
            //    };
            //    del2(this, e);
            //}
        }
        protected virtual void OnWorkCompleted()
        {
            //Raising the Event
            //Approach1
            //EventHandler delegate takes two parameters i.e. object sender, EventArgs e
            //Sender is the current class i.e. this keyword and we do not need to pass any data
            //So, we need to pass Empty EventArgs
            //WorkCompleted?.Invoke(this, EventArgs.Empty);
            //Approach2
            if (WorkCompleted is EventHandler del)
            {
                del(this, EventArgs.Empty);
            }
            //Note: You can also use other two Approaches
        }
    }
    public enum WorkType
    {
        Golf,
        GotoMeetings,
        GenerateReports
    }
}
