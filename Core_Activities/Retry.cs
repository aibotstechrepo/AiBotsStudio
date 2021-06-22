using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Core_Activities
{

    [Designer(typeof(ForEachFileDesigner))]
    public class Retry : NativeActivity
    {
        public InArgument<int> MaxRetries { get; set; }
        public Activity Body { get; set; }

        Variable<int> CurrentRetry = new Variable<int>("CurrentRetry");

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddChild(Body);
            metadata.AddImplementationVariable(CurrentRetry);
            RuntimeArgument arg = new RuntimeArgument("MaxRetries", typeof(int), ArgumentDirection.In);
            metadata.Bind(MaxRetries, arg);
            metadata.AddArgument(arg);
        }

        protected override void Execute(NativeActivityContext context)
        {
            CurrentRetry.Set(context, 0);
            context.ScheduleActivity(Body, OnFaulted);
        }

        private void OnFaulted(NativeActivityFaultContext faultContext, Exception propagatedException, ActivityInstance propagatedFrom)
        {
            int current = CurrentRetry.Get(faultContext);
            int max = MaxRetries.Get(faultContext);

            if (current < max)
            {
                faultContext.CancelChild(propagatedFrom);
                faultContext.HandleFault();
                //faultContext.ScheduleActivity(Delay, OnDelayComplete);
                CurrentRetry.Set(faultContext, current + 1);
            }
        }

        private void OnDelayComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            context.ScheduleActivity(Body, OnFaulted);
        }
    }
}
