using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Core_Activities
{

    public sealed class Delay : CodeActivity
    {
        public enum Durations
        { 
            Secs,
            Mins,
            Hours
        }

        [Category("Input")]
        [DisplayName("Time")]
        [RequiredArgument]
        public InArgument<Int32> dur { get; set; }
         
        [Category("Input")]
        [DisplayName("Duration")]
        [RequiredArgument]
        public Durations Duration { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        { 
            int text = context.GetValue(this.dur);
            string ctl = Convert.ToString(Duration);
            //MessageBox.Show(text);
            int val = 0;
            if (ctl == "Hours")
            {
                val = text * ((1000 * 60) * 60);
                System.Threading.Thread.Sleep(val);
                Result.Set(context, true);
            }
            else if (ctl == "Mins")
            {
                val = text * (1000 * 60);
                System.Threading.Thread.Sleep(val);
                Result.Set(context, true);
            }
            else if (ctl == "Secs")
            {
                val = text * (1000);
                System.Threading.Thread.Sleep(val);
                Result.Set(context, true);
            }
            else
            {
                Result.Set(context, false);
            }


        }
    }
}
