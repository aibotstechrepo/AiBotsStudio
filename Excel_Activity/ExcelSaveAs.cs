using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelSaveAs : CodeActivity
    {
        [Category("Input")]
        [DisplayName("FileName and Location")]
        [RequiredArgument]
        public InArgument<string> path { get; set; }

        protected override void Execute(CodeActivityContext context)
        { 
            string Path = context.GetValue(this.path);

            //Excel_Core excel = new Excel_Core();
            Excel_Core.saveAs(Path);
        }
    }
}
