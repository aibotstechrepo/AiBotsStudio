using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics;

namespace File_Operations
{

    public sealed class PDF_Open : CodeActivity
    {
        [Category("Input")]
        [DisplayName("PDF File Name")]
        [RequiredArgument]
        public InArgument<string> file { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                string cmd = context.GetValue(this.file);

                string a = context.GetValue(this.file);
                int lastString = Convert.ToInt32(a.Length);
                int count = 4;

                if (count <= lastString)
                {
                    string str = a.Substring(lastString - count).ToUpper();
                    if (str == ".pdf" || str == ".PDF")
                    {
                        Process.Start(cmd);
                        Result.Set(context, true);
                    }
                    //}
                    //else
                    //{
                    //    Result.Set(context, false);
                    //}
                }
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}

        }
    }
}
