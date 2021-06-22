using System.ComponentModel; 
using System.Activities.DynamicUpdate;
using System.Activities.Expressions;
using System.Collections.ObjectModel;
using System.Linq.Expressions; 
using System.Windows.Markup;
using System.Activities;
using System;
using System.Collections.Generic; 

namespace Core_Activities
{
    [Designer(typeof(For_Loop_Designer))]
    public class For_Loop : NativeActivity
    {
        //[Category("Input")]
        //[DisplayName("Button")]
        public Collection<Activity> Activities { get; set; }
        public InArgument<Int32> I { get; set; }
        public InArgument<Int32> N { get; set; }
        public InArgument<string> condition { get; set; }
        public InArgument<string> operation { get; set; }

        public For_Loop()
        {
            Activities = new Collection<Activity>();

        }

        int activityCounter = 0;


         
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            RuntimeArgument arg = new RuntimeArgument("I", typeof(int), ArgumentDirection.In);
            metadata.Bind(I, arg);
            RuntimeArgument arg1 = new RuntimeArgument("N", typeof(int), ArgumentDirection.In);
            metadata.Bind(N, arg1);
            RuntimeArgument arg2 = new RuntimeArgument("conditiond", typeof(string), ArgumentDirection.In);
            metadata.Bind(condition, arg2);
            RuntimeArgument arg3 = new RuntimeArgument("operation", typeof(string), ArgumentDirection.In);
            metadata.Bind(operation, arg3);

            metadata.AddArgument(arg);
            metadata.AddArgument(arg1);
            metadata.AddArgument(arg2);
            metadata.AddArgument(arg3);

            foreach (var activity in Activities)
            {
                //metadata.AddImplementationChild(activity);
                metadata.AddChild(activity);
            }
        }
        int i = 0;
        protected override void Execute(NativeActivityContext context)
        {

            int ival = context.GetValue(I);
            int nval = context.GetValue(N);
            string con = context.GetValue(condition).Trim();
            string ope = context.GetValue(operation).Trim();
            // System.Windows.MessageBox.Show("I value : " + ival.ToString());
            // System.Windows.MessageBox.Show("nval value : " + nval.ToString());
            //for (int i = ival; i < nval; i++)
            activityCounter = 0;

            //ScheduleActivities(context);  

            //System.Windows.MessageBox.Show("completed");
            if (con == "" || ope == "")
            {

            }
            else if (con == "<" && ope == "i++")
            {
                for (int j = ival; j < nval; j++)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i], onCompleted: dataSetI);  
                    }

                    
                }
            }

            else if (con == "<" && ope == "i--")
            {
                for (int j = ival; j < nval; j--)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == "<" && ope == "++i")
            {
                for (int j = ival; j < nval; ++j)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == "<" && ope == "--i")
            {
                for (int j = ival; j < nval; --j)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == "<=" && ope == "i++")
            {
                for (int j = ival; j <= nval; j++)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == "<=" && ope == "i--")
            {
                for (int j = ival; j <= nval; j--)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == "<=" && ope == "++i")
            {
                for (int j = ival; j <= nval; ++j)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == "<=" && ope == "--i")
            {
                for (int j = ival; j <= nval; --j)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == ">=" && ope == "i++")
            {
                for (int j = ival; j >= nval; j++)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == ">=" && ope == "i--")
            {
                for (int j = ival; j >= nval; j--)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == ">=" && ope == "++i")
            {
                for (int j = ival; j >= nval; ++j)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == ">=" && ope == "--i")
            {
                for (int j = ival; j >= nval; --j)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == ">" && ope == "i++")
            {
                for (int j = ival; j > nval; j++)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == ">" && ope == "i--")
            {
                for (int j = ival; j > nval; j--)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == ">" && ope == "++i")
            {
                for (int j = ival; j > nval; ++j)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }

            else if (con == ">" && ope == "--i")
            {
                for (int j = ival; j > nval; --j)
                {

                    for (int i = Activities.Count - 1; i >= 0; i--)
                    {
                        I.Set(context, j);
                        context.ScheduleActivity(this.Activities[i]);
                    }
                }
            }


            //for (int j = ival; j <= nval; j++)
            //{

            //    for (int i = Activities.Count - 1; i >= 0; i--)
            //    {
            //        I.Set(context, j);
            //        context.ScheduleActivity(this.Activities[i]);
            //    }
            //}

        }

        private void dataSetI(NativeActivityContext context, ActivityInstance completedInstance)
        {
            
            I.Set(context, i+1);
            i = i + 1;
        }

        void ScheduleActivities(NativeActivityContext context)
        {


            //if (activityCounter < Activities.Count)
            //{ 

            context.ScheduleActivity(this.Activities[activityCounter++], OnActivityCompleted);// System.Windows.MessageBox.Show("Inside 2 : activity called exe");


            //} 
        }

        void OnActivityCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {

            // System.Windows.MessageBox.Show("Inside : " + i.ToString());
            if (activityCounter < Activities.Count)
            {
                //System.Windows.MessageBox.Show("Counter : "+ activityCounter);

                ScheduleActivities(context);
            }

            // System.Windows.MessageBox.Show("Inside 1 : activity completed");


        }

    }
}
