using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvironmentFunctions
{
    public sealed class EnvironmentVariables : CodeActivity
    {
        public enum Fold
        {
            UserName,
            ExitCode,
            TickCount,
            CommandLine,
            CurrentDirectory,
            MachineName,
            ProcessorCount,
            SystemPageSize,
            NewLine,
            Version,
            WorkingSet,
            OSVersion,
            StackTrace,
            Is64BitProcess,
            Is64BitOperatingSystem,
            HasShutdownStarted,
            SystemDirectory,
            UserInteractive,
            UserDomainName,
            CurrentManagedThreadId,
        }
        [Category("Input")]
        [DisplayName("SelectFolder")]

        public Fold fol { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<String> Variables { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            int Fold = Convert.ToInt32(fol);
            WindowsFormsSection Foldval = new WindowsFormsSection();
            String variables;
            if (Fold == 0)
            {
                variables = Environment.UserName;
            }
            else if (Fold == 1)
            {
                variables = (Environment.ExitCode).ToString();
            }
            else if (Fold == 2)
            {
                variables = (Environment.TickCount).ToString();
            }
            else if (Fold == 3)
            {
                variables = Environment.CommandLine;
            }
            else if (Fold == 4)
            {
                variables = Environment.CurrentDirectory;
            }
            else if (Fold == 5)
            {
                variables = Environment.MachineName;
            }
            else if (Fold == 6)
            {
                variables = (Environment.ProcessorCount).ToString();
            }
            else if (Fold == 7)
            {
                variables = (Environment.SystemPageSize).ToString();
            }
            else if (Fold == 8)
            {
                variables = Environment.NewLine;
            }
            else if (Fold == 9)
            {
                variables = (Environment.Version).ToString();
            }
            else if (Fold == 10)
            {
                variables = (Environment.WorkingSet).ToString();
            }
            else if (Fold == 11)
            {
                variables = (Environment.OSVersion).ToString();
            }
            else if (Fold == 12)
            {
                variables = Environment.StackTrace;
            }
            else if (Fold == 13)
            {
                variables = (Environment.Is64BitProcess).ToString();
            }
            else if (Fold == 14)
            {
                variables = (Environment.Is64BitOperatingSystem).ToString();
            }
            else if (Fold == 15)
            {
                variables = (Environment.HasShutdownStarted).ToString();
            }
            else if (Fold == 16)
            {
                variables = Environment.SystemDirectory;
            }
            else if (Fold == 17)
            {
                variables = (Environment.UserInteractive).ToString();
            }
            else if (Fold == 18)
            {
                variables = Environment.UserDomainName;
            }
            else if (Fold == 19)
            {
                variables = (Environment.CurrentManagedThreadId).ToString();
            }
            else
            {
                variables = Environment.UserName;
            }
            context.SetValue(Variables, variables);
        }
    }
}