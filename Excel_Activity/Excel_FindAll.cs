
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class Excel_FindAll : CodeActivity
    {

        public enum oper
        {
            Part,
            Whole_Word
        }

        [Category("Input")]
        [DisplayName("Match Word")]
        public oper op { get; set; }

        [Category("Input")]
        [DisplayName("Case Sensitive")]
        [DefaultValue(false)]
        public Boolean Case { get; set; }

        [Category("Input")]
        [DisplayName("String to Find")]
        [RequiredArgument]
        public InArgument<string> find { get; set; } 

        [Category("Input")]
        [DisplayName("From Position")]
        //[RequiredArgument]
        public InArgument<string> from { get; set; }
        [Category("Input")]
        [DisplayName("To Position")]
       // [RequiredArgument]
        public InArgument<string> to { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Number")]
        // [RequiredArgument]
        public InArgument<Int32> sheet { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")] 
        public InArgument<string> SheetName { get; set; }

        [Category("Output")]
        [DisplayName("Data")]
      //  [RequiredArgument]
        public OutArgument<string[]> data { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            string[] a = new string[0];
            try
            {
                int oval = Convert.ToInt32(op);
                string Find = context.GetValue(this.find);
                int Sheet = context.GetValue(this.sheet);
                string sheetName = context.GetValue(this.SheetName);
                string From = context.GetValue(this.from);
                string To = context.GetValue(this.to);
                bool word = false;
                if (oval == 0)
                {
                    word = true;
                }
                else if (oval == 1)
                {
                    word = false;
                }
                string[] Data = Excel_Core.findAll(Find, Sheet,sheetName, From, To, word, Case);
                data.Set(context, Data);
            }
            catch
            {
                data.Set(context, a);
            }


        }
    }
}
