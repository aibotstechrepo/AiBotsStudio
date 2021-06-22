using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;

namespace Core_Activities
{
    [Designer(typeof(ActivityDesigner1))]
    public sealed class Run_Prompt : CodeActivity
    {

        [Category("Input")]
        [DisplayName("Command")]
        [RequiredArgument]
        public InArgument<string> Command { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                string cmd = context.GetValue(this.Command);
            Process.Start(cmd);
            //ExecuteCommand(cmd);
            //func();
            Result.Set(context, true);
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}
            
        }

        public void func()
        {
            var processToRun = new[] { "notepad.exe" };
            var connection = new ConnectionOptions();
            connection.Username = "Administrator";
            connection.Password = "Twin@0786";
            var wmiScope = new ManagementScope(String.Format("\\\\{0}\\root", "192.168.0.50"), connection);
            var wmiProcess = new ManagementClass(wmiScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
            wmiProcess.InvokeMethod("Create", processToRun);
        }
        public void ExecuteCommand(string Command)
        {
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe",  Command);
            ////ProcessInfo.CreateNoWindow = true;
            ///ProcessInfo.UseShellExecute = true;

            Process = Process.Start(ProcessInfo);
        }
    }
}
