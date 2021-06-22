using System;
using System.Activities;
using System.Drawing;
using System.Windows.Forms;

namespace Custom_Control
{

    public sealed class Mouse_Pointer_Hower : CodeActivity
    {
        public InArgument<int> X { get; set; }
        public InArgument<int> Y { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int x = Convert.ToInt32(X.Get(context).ToString());
            int y = Convert.ToInt32(Y.Get(context).ToString());

            Cursor.Position = new Point(x, y);
        }
    }
}
