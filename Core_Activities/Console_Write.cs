using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Core_Activities
{

    public sealed class Console_Write : CodeActivity
    {
        public enum oper
        { 
            Write_Line,
            Write
        }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Text")]
        public InArgument<string> Text { get; set; }

        [Category("Input")]
        [DisplayName("Type")]
        public oper op { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                string text = context.GetValue(this.Text);
                int oval = Convert.ToInt32(op);

                if (oval == 0)
                {
                    Console.WriteLine(text);
                }
                if (oval == 1)
                {
                    Console.Write(text);
                }
            //}
            //catch
            //{
            //    ;
            //}

        }
    }
}
