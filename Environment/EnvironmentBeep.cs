using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Environments
{
    public sealed class EnvironmentBeep : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.Beep(2100, 1000);
        }
    }
}
