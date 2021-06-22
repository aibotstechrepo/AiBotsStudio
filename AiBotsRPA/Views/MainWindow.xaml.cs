using Custom_Control;
using Microsoft.Win32;
using AibotsRPA.Helpers;
using System;
using System.Activities;
using System.Activities.Presentation.Toolbox;
using System.Activities.XamlIntegration;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Drawing;
using Web_Scrapping;
using Tab_Files;
using Recorder_New;
using ArrayOperation;
using Excel_Activity;

using String_Operation;
namespace AibotsRPA.Views
{
    public partial class MainWindow : Window
    {

        
        TextBoxOutputter outputter;
        Phoenix_OCR_Single_PDF c = new Phoenix_OCR_Single_PDF(); 
        
        public void MainWindow1()
        {
            try
            {
                outputter = new TextBoxOutputter(consoleOutput);
                Console.SetOut(outputter);
                Console.WriteLine("Started");

                //var timer1 = new System.Threading.Timer(TimerTick, "Timer1", 0, 1000);
                //var timer2 = new System.Threading.Timer(TimerTick, "Timer2", 0, 500);
            }
            catch
            {
                ;
            }
        }

        void TimerTick(object state)
        {
            try
            {
                    var who = state as string;
                    Console.WriteLine(who);
            }
            catch
            {
                ;
            }

        }

        private void PhoenixOCR_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                c.Show();
            }
            catch
            {
                Phoenix_OCR_Single_PDF d = new Phoenix_OCR_Single_PDF();
                d.Show();
            }
        }

        private void TessractOCR_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{ 
            //}
            //catch
            //{
            //    Tessaract_OCR_Single j = new Tessaract_OCR_Single();
            //    j.Show();
            //}

        }
        
        private void PhoenixInspect_Click(object sender, RoutedEventArgs e)
        {
            try
            { 

            }
            catch
            {
                ;
            }
            //a.Show();
            //SelectedAutomationType = AutomationType.UIA3;
            //DialogResult = true;
        }

        private void UIRecorder_Click(object sender, RoutedEventArgs e)
        {
            Tab_Files.Recorder recorder = new Recorder();
            recorder.Show();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.DialogResult result3 = System.Windows.Forms.MessageBox.Show("Do you want to save the file before closing ?", "Close Studio", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);

            if (result3 == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {

                    if (_currentWorkflowFile == String.Empty)
                    {
                        var dialogSave = new SaveFileDialog();
                        dialogSave.Title = "Save Workflow";
                        dialogSave.Filter = "Workflows (.xaml)|*.xaml";

                        if (dialogSave.ShowDialog() == true)
                        {
                            CustomWfDesigner.Instance.Save(dialogSave.FileName);
                            _currentWorkflowFile = dialogSave.FileName;
                            LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        CustomWfDesigner.Instance.Save(_currentWorkflowFile);
                        LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                    }
                }
                catch
                {
                    ;
                }
            }
            else if (result3 == System.Windows.Forms.DialogResult.No)
            {
                ;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
    public partial class MainWindow : INotifyPropertyChanged
    {
        private WorkflowApplication _wfApp;
        private ToolboxControl _wfToolbox;
        private CustomTrackingParticipant _executionLog;

        private string _currentWorkflowFile = string.Empty;
        private Timer _timer;


        public MainWindow()
        {
            InitializeComponent();
            MainWindow1();
            _timer = new Timer(1000);
            _timer.Enabled = false;
            _timer.Elapsed += TrackingDataRefresh;

            //load all available workflow activities from loaded assemblies 
            InitializeActivitiesToolbox();

            //initialize designer
            WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
            WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;

        }


        public string ExecutionLog
        {
            get
            {
                if (_executionLog != null)
                    return _executionLog.TrackData;
                else
                    return string.Empty;
            }
            set { _executionLog.TrackData = value; NotifyPropertyChanged("ExecutionLog"); }
        }


        private void TrackingDataRefresh(Object source, ElapsedEventArgs e)
        {
            NotifyPropertyChanged("ExecutionLog");
            NotifyPropertyChanged("consoleOutput");
        }


        private void consoleExecutionLog_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            consoleExecutionLog.ScrollToEnd();
        }
        private void consoleOutput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            consoleOutput.ScrollToEnd();
        }


        /// <summary>
        /// show execution log in ui
        /// </summary>
        private void UpdateTrackingData()
        {
            // retrieve & display execution log
            consoleExecutionLog.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Normal,
                new Action(
                    delegate ()
                    {
                        //consoleExecutionLog.Text = _executionLog.TrackData;
                        NotifyPropertyChanged("ExecutionLog");
                    }
            ));
        }


        /// <summary>
        /// Retrieves all Workflow Activities from the loaded assemblies and inserts them into a ToolboxControl 
        /// </summary>
        private void InitializeActivitiesToolbox()
        {
            try
            {
                _wfToolbox = new ToolboxControl();
                #region mainloaded com
                //load dependency
                // AppDomain.CurrentDomain.Load("Twilio.Api");
                // load Custom Activity Libraries into current domain
                //AppDomain.CurrentDomain.Load("MeetupActivityLibrary");
                //// load System Activity Libraries into current domain; uncomment more if libraries below available on your system
                //AppDomain.CurrentDomain.Load("System.Activities");
                //AppDomain.CurrentDomain.Load("System.ServiceModel.Activities");
                //AppDomain.CurrentDomain.Load("System.Activities.Core.Presentation");
                //////AppDomain.CurrentDomain.Load("Microsoft.Workflow.Management");
                //////AppDomain.CurrentDomain.Load("Microsoft.Activities.Extensions");
                //////AppDomain.CurrentDomain.Load("Microsoft.Activities");
                //////AppDomain.CurrentDomain.Load("Microsoft.Activities.Hosting");
                //////AppDomain.CurrentDomain.Load("Microsoft.PowerShell.Utility.Activities");
                //////AppDomain.CurrentDomain.Load("Microsoft.PowerShell.Security.Activities");
                //////AppDomain.CurrentDomain.Load("Microsoft.PowerShell.Management.Activities");
                //////AppDomain.CurrentDomain.Load("Microsoft.PowerShell.Diagnostics.Activities");
                //////AppDomain.CurrentDomain.Load("Microsoft.Powershell.Core.Activities");
                //////AppDomain.CurrentDomain.Load("Microsoft.PowerShell.Activities");

                ////// get all loaded assemblies
                //IEnumerable<Assembly> appAssemblies = AppDomain.CurrentDomain.GetAssemblies().OrderBy(a => a.GetName().Name);

                //// check if assemblies contain activities
                //int activitiesCount = 0;
                //foreach (Assembly activityLibrary in appAssemblies)
                //{
                //    var wfToolboxCategory = new ToolboxCategory(activityLibrary.GetName().Name);
                //    var actvities = from
                //                        activityType in activityLibrary.GetExportedTypes()
                //                    where
                //                        (activityType.IsSubclassOf(typeof(Activity))
                //                        || activityType.IsSubclassOf(typeof(NativeActivity))
                //                        || activityType.IsSubclassOf(typeof(DynamicActivity))
                //                        || activityType.IsSubclassOf(typeof(ActivityWithResult))
                //                        || activityType.IsSubclassOf(typeof(AsyncCodeActivity))
                //                        || activityType.IsSubclassOf(typeof(CodeActivity))
                //                        || activityType == typeof(System.Activities.Core.Presentation.Factories.ForEachWithBodyFactory<Type>)
                //                        || activityType == typeof(System.Activities.Statements.FlowNode)
                //                        || activityType == typeof(System.Activities.Statements.State)
                //                        || activityType == typeof(System.Activities.Core.Presentation.FinalState)
                //                        || activityType == typeof(System.Activities.Statements.FlowDecision)
                //                        || activityType == typeof(System.Activities.Statements.FlowNode)
                //                        || activityType == typeof(System.Activities.Statements.FlowStep)
                //                        || activityType == typeof(System.Activities.Statements.FlowSwitch<Type>)
                //                        || activityType == typeof(System.Activities.Statements.ForEach<Type>)
                //                        || activityType == typeof(System.Activities.Statements.Switch<Type>)
                //                        || activityType == typeof(System.Activities.Statements.TryCatch)
                //                        || activityType == typeof(System.Activities.Statements.While))
                //                        && activityType.IsVisible
                //                        && activityType.IsPublic
                //                        && !activityType.IsNested
                //                        && !activityType.IsAbstract
                //                        && (activityType.GetConstructor(Type.EmptyTypes) != null)
                //                        && !activityType.Name.Contains('`') //optional, for extra cleanup
                //                    orderby
                //                        activityType.Name
                //                    select
                //                        new ToolboxItemWrapper(activityType);

                //    actvities.ToList().ForEach(wfToolboxCategory.Add);

                //    if (wfToolboxCategory.Tools.Count > 0)
                //    {
                //        _wfToolbox.Categories.Add(wfToolboxCategory);
                //        activitiesCount += wfToolboxCategory.Tools.Count;
                //    }
                //}

                //fixed ForEach
                //_wfToolbox.Categories.Add(
                //       new System.Activities.Presentation.Toolbox.ToolboxCategory
                //       {
                //           CategoryName = "Custome Tools",
                //           Tools = {
                //                            new ToolboxItemWrapper(typeof(System.Activities.Statements.If),"IF Condition"),
                //                            new ToolboxItemWrapper(typeof(System.Activities.Statements.ForEach<>),"For Each Loop"),
                //                            new ToolboxItemWrapper(typeof(System.Activities.Statements.While),"While Loop"),
                //                            new ToolboxItemWrapper(typeof(Microsoft.Office.Interop.Excel.Worksheet),"Work Sheet")
                //           }
                //       }
                // );
                #endregion

                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Basic Activities",
                            Tools =
                            {
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.Assign),"Assign Value"),
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.Sequence),"Sequence"),
                                 new ToolboxItemWrapper(typeof(Core_Activities.Control_Send),"Control Send"),
                                 new ToolboxItemWrapper(typeof(Core_Activities.Delay),"Sleep"),
                                 new ToolboxItemWrapper(typeof(Core_Activities.Console_Write),"Console Write"),
                                 new ToolboxItemWrapper(typeof(Core_Activities.Run_Prompt),"Run Command"),
                                 new ToolboxItemWrapper(typeof(Core_Activities.InputBox),"Input Box"),
                                 new ToolboxItemWrapper(typeof(Core_Activities.MessageBox),"Message Box"),
                                 new ToolboxItemWrapper(typeof(File_Operations.Activate_Window),"Activate Window"),
                                 new ToolboxItemWrapper(typeof(Custom_Control.Windows_Switch),"Switch Window"),
                                 new ToolboxItemWrapper(typeof(Custom_Control.Windows_Close),"Close Window"),
                                 //new ToolboxItemWrapper(typeof(ActivityLibrary.MySequence),"seq loop"),
                                 //new ToolboxItemWrapper(typeof(Core_Activities.ForEach<object>),"For Each"),


                                  
                                //new ToolboxItemWrapper(typeof(System.Activities.Statements.Assign),"Asign Value"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.Confirm),"Confirmation"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.Delay),"Sleep"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.DoWhile),"Do While"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.FlowDecision),"Flowchart Condition"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.If),"If Condition"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.Parallel),"Parallel Flow"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.Rethrow),"Rethrow"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.Sequence),"Sequence Flow"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.TerminateWorkflow),"Stop"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.Throw),"Throw"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.TryCatch),"Try"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.While),"While"),
                                //            new ToolboxItemWrapper(typeof(System.Activities.Statements.WriteLine),"Console Write"),
                                //            new ToolboxItemWrapper(typeof(MeetupWfIntro.MeetupActivityLibrary.Misc.ShowMessageBox),"Message Box"),
                                //            new ToolboxItemWrapper(typeof(Core_Activities.Run_Prompt),"Run Command"),
                                            
                                //            new ToolboxItemWrapper(typeof(Core_Activities.Clipboard_Empty),"Clipboard Empty"),
                                //            new ToolboxItemWrapper(typeof(Core_Activities.Clipboard_SetText),"Clipboard Set Text"),
                                //            new ToolboxItemWrapper(typeof(Core_Activities.Clipbord_GetText),"Clipboard Get Text"),
                                            
                                //            new ToolboxItemWrapper(typeof(Core_Activities.InputBox),"Input Box"),
                                            
                                           //new ToolboxItemWrapper(typeof(System.Activities.Statements.While),"While Loop"),
                                           // new ToolboxItemWrapper(typeof(Microsoft.Office.Interop.Excel.AutoCorrect),"Work Sheet")

                             }
                        }
                  );
                _wfToolbox.Categories.Add(
               new System.Activities.Presentation.Toolbox.ToolboxCategory
               {
                   CategoryName = "Collection",
                   Tools =
                   {
                       new ToolboxItemWrapper(typeof(System.Activities.Statements.AddToCollection<>),"Add To Collection"),
                       new ToolboxItemWrapper(typeof(System.Activities.Statements.ClearCollection<>),"Clear Collection"),
                       new ToolboxItemWrapper(typeof(System.Activities.Statements.ExistsInCollection<>),"Exists In Collection"),
                       new ToolboxItemWrapper(typeof(System.Activities.Statements.RemoveFromCollection<>),"Remove From Collection"),
                    }
               });
                //_wfToolbox.Categories.Add(
                //        new System.Activities.Presentation.Toolbox.ToolboxCategory
                //        {
                //            CategoryName = "State Machine",
                //            Tools =
                //            {
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.StateMachine),"State Machine"),
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.State),"State"),
                //            }
                //        }
                //  );
                //_wfToolbox.Categories.Add(
                //       new System.Activities.Presentation.Toolbox.ToolboxCategory
                //       {
                //           CategoryName = "Workflow Control",
                //           Tools =
                //           {
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.CancellationScope),"Cancellation Scope") ,
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.InvokeAction),"Invoke Action"),
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.InvokeDelegate),"Invoke Delegate"),
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.InvokeMethod),"Invoke Method"),
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.Parallel),"Parallel"),
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.Pick),"Pick"),
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.PickBranch),"Pick Branch"),
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.Transition),"Transition"),
                //                 new ToolboxItemWrapper(typeof(System.Activities.Statements.TransactionScope),"Transition Scope"),
                //           }
                //       }
                // );
                _wfToolbox.Categories.Add(
               new System.Activities.Presentation.Toolbox.ToolboxCategory
               {
                   CategoryName = "Prompts",
                   Tools =
                   {
                       new ToolboxItemWrapper(typeof(Prompt.PromptForFile),"Prompt For File"),
                       new ToolboxItemWrapper(typeof(Prompt.PromptForFolder),"Prompt For Folder"),
                    }
               });

                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Loops",
                            Tools =
                            {
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.While),"While"),
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.DoWhile),"Do While"),
                                 new ToolboxItemWrapper(typeof(Core_Activities.For_Loop),"For Loop"),
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.If),"If Condition"),
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.Switch<>),"Switch") ,
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.ForEach<string>),"For Each Loop") ,
                            }
                        }
                  );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Flow Chart",
                            Tools =
                            {
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.Flowchart),"Flow Chart"),
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.FlowDecision),"Flow Decision"),
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.FlowSwitch<>),"Flow Switch"),
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.TerminateWorkflow),"Terminate Workflow"),
                                 //new ToolboxItemWrapper(typeof(System.Activities.Statements.CancellationScope),"Cancellation Scope") ,
                                 
                            }
                        }
                  );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Exceptions",
                            Tools =
                            {
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.TryCatch),"Try Catch"),
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.Throw),"Throw"),
                                 new ToolboxItemWrapper(typeof(System.Activities.Statements.Rethrow),"Rethrow"),
                            }
                        }
                  );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Clipboard",
                            Tools =
                            {
                                 new ToolboxItemWrapper(typeof(Core_Activities.Clipboard_Empty),"Clipboard Empty"),
                                 new ToolboxItemWrapper(typeof(Core_Activities.Clipboard_SetText),"Clipboard Set Text"),
                                 new ToolboxItemWrapper(typeof(Core_Activities.Clipbord_GetText),"Clipboard Get Text"),
                            }
                        }
                  );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Mouse Events",
                            Tools =
                            {

                                 new ToolboxItemWrapper(typeof(Custom_Control.Mouse_Pointer_Click_Left),"Mouse Left Click"),
                                 new ToolboxItemWrapper(typeof(Custom_Control.Mouse_Pointer_Click_Right),"Mouse Right Click"),
                                 new ToolboxItemWrapper(typeof(Custom_Control.Mouse_Pointer_Click_Double),"Mouse Left Double Click"),
                                 new ToolboxItemWrapper(typeof(Custom_Control.Mouse_Pointer_Hower),"Mouse Hower"),
                                 new ToolboxItemWrapper(typeof(Custom_Control.Mouse_Pointer_Drag),"Mouse Drag"),
                            }
                        }
                  );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Keyboard Events",
                            Tools =
                            { 
                                 new ToolboxItemWrapper(typeof(Custom_Control.Keyboard_Copy),"Keyboard Copy"),
                                 new ToolboxItemWrapper(typeof(Custom_Control.Keyboard_Cut),"Keyboard Cut"),
                                 new ToolboxItemWrapper(typeof(Custom_Control.Keyboard_Paste),"Keyboard Paste"),
                                 new ToolboxItemWrapper(typeof(Custom_Control.Keyboard_Select_All),"Keyboard Select All"),
                            }
                        }
                  );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "CSV",
                            Tools =
                            {
                                 new ToolboxItemWrapper(typeof(CSV.CSVRead),"CSV Read"),
                                 new ToolboxItemWrapper(typeof(CSV.CSVWrite),"CSV Write"),
                                 new ToolboxItemWrapper(typeof(CSV.CSVAppend),"CSV Append"),
                            }
                        }
                  );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Excel Activities",
                            Tools =
                            {
                                new ToolboxItemWrapper(typeof(Excel_Activity.Excel_Create),"Excel Create"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.Excel_Open),"Excel Open"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelNewWorksheet),"Excel Create Sheet"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelReadCellValueByCell_I_J_value),"Excel Read Cell by Position"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelReadCellValueByCell_Range),"Excel Read Cell by Range"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelReadCellFormula),"Excel Read Cell Formula by Range"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelWriteCellByPosition),"Excel Write Cell by Position"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelWriteCellByRange),"Excel Write Cell by Range"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelReadRangeCellPositions),"Excel Read Range Position"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelReadRangeCellRange),"Excel Read Range Value"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelWriteRangeCellPosition),"Excel Write Range Value"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelInvokeMacro),"Excel Invoke Macro"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelCountSheets),"Excel Count Sheets"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSheetNames),"Excel Count Sheet Names"),
                                new ToolboxItemWrapper(typeof(ExtendedActivities.Excel_Copy_Paste),"Excel Sheet Copy to Another Excel"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelCopySheetSameExcel),"Excel Sheet Copy to Same Excel"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSheetActivate),"Excel Activate Sheet"), 
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelDeleteRange),"Excel Delete Range"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelFindReplace),"Excel Find Replace"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelFind),"Excel Find"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.Excel_FindAll),"Excel Find All"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSort),"Excel Sort"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSave),"Excel Save"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSaveAs),"Excel SaveAs"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelRenameSheet),"Excel Rename Sheet"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelDeleteSheet),"Excel Delete Sheet"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelProtect),"Excel Protect Sheet"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelProtectPassword),"Excel Protect Sheet with Password"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelUnProtect),"Excel Unprotect Sheet"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelUnProtectPassword),"Excel Unprotect Sheet with Password"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.Excel_WorkBook_Close),"Excel Workbook Close"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelClose),"Excel Close"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelAddFooter),"Excel Add Footer"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelAutoFit),"Excel AutoFit"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelBackgroundColor),"Excel Background Color"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelBoldCell),"Excel Bold Cell"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelBorderAllSides),"Excel Border All Sides"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelCellIncrementDecrement),"Excel Cell Increment Decrement"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelChart),"Excel Add Chart"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelColumnAddress),"Excel Get Column Address"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelColumnNumber),"Excel Get Column Number"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelCopyRow),"Excel Copy Row"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelExportAsPDF),"Excel Export as PDF"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelFontColor),"Excel Font Color"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelFonts),"Excel Add Font"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelFontSize),"Excel Font Size"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelGetLastColumn),"Excel Get Last Column"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelHAlign),"Excel Horizontal Align"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelHideWorksheet),"Excel Hide Worksheet"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelInsertColumn),"Excel Insert Column"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelInsertRow),"Excel Insert Row"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelLastColumnByCellAddress),"Excel Last Column By Cell Address"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelLastRowByCellAddress),"Excel Last Row By Cell Address"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelLastUsedCell),"Excel Last Used Cell"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelMerge),"Excel Merge Cells"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelPageBreak),"Excel Page Break"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelRightPageHeader),"Excel Right Page Header"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSetBorder),"Excel Set Border"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSetCellFormat),"Excel Set Cell Format"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSetColumnWidth),"Excel Set Column Width"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSetMargin),"Excel Set Margin"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSetPageOrientation),"Excel Set Page Orientation"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSetPageSize),"Excel Set Page Size"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelSetRowHeight),"Excel Set Row Height"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelUnMerge),"Excel Unmerge Cells"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelVAlign),"Excel Vertical Align"),
                                new ToolboxItemWrapper(typeof(Excel_Activity.ExcelWrapText),"Excel Wrap Text"),
                            }
                        }
                 );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "File Operations",
                            Tools =
                            {
                                new ToolboxItemWrapper(typeof(File_Operations.File_List_to_Array),"File List"),
                                new ToolboxItemWrapper(typeof(File_Operations.File_Copy_Move),"File Copy / Move"),
                                new ToolboxItemWrapper(typeof(LogToFile.LogToFileCreateLog),"Create Log"),
                                new ToolboxItemWrapper(typeof(File_Operations.MakeZipOperation),"Zip Operation"),

                            }
                        }
                 );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "PDF Operations",
                            Tools =
                            {
                                new ToolboxItemWrapper(typeof(File_Operations.PDF_Text_Read),"PDF Text Read"),
                                new ToolboxItemWrapper(typeof(File_Operations.PDF_Open),"PDF Open "),
                                new ToolboxItemWrapper(typeof(File_Operations.PDF_Close),"PDF Close"),
                                new ToolboxItemWrapper(typeof(File_Operations.PDFAddLink),"PDF Add Link"),
                            }
                        }
                 );                 
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Array Operations",
                            Tools =
                            {
                                new ToolboxItemWrapper(typeof(Array_Operations.Array_Concat),"1D Array Concatenation"),
                                new ToolboxItemWrapper(typeof(Array_Operations.Array_Find),"1D Array Find"),
                                new ToolboxItemWrapper(typeof(Array_Operations.Array_Redim),"1D Array Resize"),
                                new ToolboxItemWrapper(typeof(Array_Operations.Array_Trim),"1D Array Trim"),
                                new ToolboxItemWrapper(typeof(Array_Operations.Array_Unique),"1D Array Unique"),
                                new ToolboxItemWrapper(typeof(Array_Operations.ArrayDeleteByIndex),"1D Array Delete By Index"),
                                new ToolboxItemWrapper(typeof(Array_Operations.ArrayToString),"1D Array to String"),
                                new ToolboxItemWrapper(typeof(Array_Operations.ArrayDisplay),"1D Array Display"),
                                new ToolboxItemWrapper(typeof(Array_Operations.ArrayTranspose),"1D Array Transpose"),
                                new ToolboxItemWrapper(typeof(Array_Operations._2DArrayConcat),"2D Array Concatenation"),
                                new ToolboxItemWrapper(typeof(Array_Operations._2DArrayResize),"2D Array Resize"),
                                new ToolboxItemWrapper(typeof(Array_Operations._2dArrayTranspose),"2D Array Transpose"),
                                new ToolboxItemWrapper(typeof(Array_Operations._2DArrayDisplay),"2D Array Dispaly"),
                                new ToolboxItemWrapper(typeof(Array_Operations._2DArraytoString),"2D Array String"),
                                //new ToolboxItemWrapper(typeof(Core_Activities.Retry),"Retry"),
                            }
                        }
                 );
                _wfToolbox.Categories.Add(
                        new System.Activities.Presentation.Toolbox.ToolboxCategory
                         {
                             CategoryName = "String Operations",
                             Tools =
                             {
                                new ToolboxItemWrapper(typeof(String_Operation.String_Between),"String Between"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Compare),"String Compare"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_in_String),"String in String"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_AlphaNumeric),"String Alphanumeric"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Left),"String Left"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Right),"String Right"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Mid),"String Middle"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Length),"String Length"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Replace),"String Replace"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Trim_WS),"String Trim Whitespace"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Trim_Char),"String Trim Character"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_ASCII_to_Char),"String ASCII to Char"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Char_to_ASCII),"String Char to ASCII"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_String_to_ASCII_IntArray),"String to ASCII"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Extract_Numbers),"String Extract Numbers"),
                                new ToolboxItemWrapper(typeof(String_Operation.String_Extract_Characaters),"String Extract Characters"),
                             }
                         }
                 );
                _wfToolbox.Categories.Add(
                new System.Activities.Presentation.Toolbox.ToolboxCategory
                        {
                            CategoryName = "Web Scrapping",
                            Tools =
                            {
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Create),"IE Create"),
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Loadwait),"IE Loadwait"),
                                //new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Body_Read_Html),"IE Get HTML"),
                                //new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Body_Read_Text),"IE Get Text"),
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Properties),"IE Properties"),
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Tag_Input),"IE Tag Input"),
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Action),"IE Action"),
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Form_Input),"IE Form Input"),
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Frame_Input),"IE Frame Input"),
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Navigate),"IE Navigate"),
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IE_Quit),"IE Quit"), 
                                new ToolboxItemWrapper(typeof(Web_Scrapping.WebScrapByTagName),"WebScrap By TagName"), 
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IFrameWebScrapByTagName),"IFrame WebScrap By TagName"), 
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IFrame_Tag_Action),"IFrame Tag Action"), 
                                new ToolboxItemWrapper(typeof(Web_Scrapping.IESelectDropDown),"IE Select DropDown"), 
                                //new ToolboxItemWrapper(typeof(IE.Chrome_Navigate),"Chrome_Navigate"),
                                //new ToolboxItemWrapper(typeof(ExtendedActivities.WebScrape),"Array"),
                            }
                        }
                 );
               // _wfToolbox.Categories.Add(
               //new System.Activities.Presentation.Toolbox.ToolboxCategory
               //{
               //    CategoryName = "Array Operation",
               //    Tools =
               //    {
               //        new ToolboxItemWrapper(typeof(ArrayOperation._1DArrayConCat),"1d Array"), 
                                 
               //         //new ToolboxItemWrapper(typeof(Web_Scrapping.IESelectDropDown),"IE Select DropDown"), 
               //         //new ToolboxItemWrapper(typeof(IE.Chrome_Navigate),"Chrome_Navigate"),
               //         //new ToolboxItemWrapper(typeof(ExtendedActivities.WebScrape),"Array"),
               //     }
               //});

                _wfToolbox.Categories.Add(
                    new System.Activities.Presentation.Toolbox.ToolboxCategory
                    {
                        CategoryName = "Word Document Operations",
                        Tools =
                        {
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsCreate),"Word Create"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsOpen),"Word Open"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsWriteText),"Word Write Text"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsSave),"Word Save"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsSaveAs),"Word SaveAs"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsClose),"Word Close"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsAddTable),"Word Add Table"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsAddImage),"Word Add Image"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsAddShape),"Word Add Shape"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsExportToPDF),"Word Export To PDF"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsFindAndReplace),"Word Find and Replace"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsCreateBookMark),"Word Create BookMark"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsSetBookMarkContent),"Word Set Book Mark Content"),
                            new ToolboxItemWrapper(typeof(WordOperations.WordOperationsBookMarksList),"Word BookMark List"),
                        }
                    }
                    );
                _wfToolbox.Categories.Add(
                    new System.Activities.Presentation.Toolbox.ToolboxCategory
                    {
                        CategoryName = "Window Operations",
                        Tools =
                        {
                            new ToolboxItemWrapper(typeof(WindowOperations.WindowOpsOpenState),"Window Open"),
                            new ToolboxItemWrapper(typeof(WindowOperations.WindowOpsGetHandle),"Window Get Handle"),
                            new ToolboxItemWrapper(typeof(WindowOperations.WindowOpsActivate),"Window Activate"),
                            new ToolboxItemWrapper(typeof(WindowOperations.WindowOpsExists),"Window Exists"),
                            new ToolboxItemWrapper(typeof(WindowOperations.WindowOpsSetState),"Window Set State"),
                            new ToolboxItemWrapper(typeof(WindowOperations.WindowOpsElement),"Window Element Action"),
                        }
                    }
                    );
                _wfToolbox.Categories.Add(
                    new System.Activities.Presentation.Toolbox.ToolboxCategory
                    {
                        CategoryName = "Environment Functions",
                        Tools =
                        {
                            new ToolboxItemWrapper(typeof(EnvironmentFunctions.EnvironmentBeep),"Environment Beep"),
                            new ToolboxItemWrapper(typeof(EnvironmentFunctions.EnvironmentFolder),"Environment Folders"),
                            new ToolboxItemWrapper(typeof(EnvironmentFunctions.EnvironmentVariables),"Environment Variables"),
                            new ToolboxItemWrapper(typeof(EnvironmentFunctions.GetPassword),"Environment Get Password"),
                        }
                    }
                    );
                //_wfToolbox.Categories.Add(
                //    new System.Activities.Presentation.Toolbox.ToolboxCategory
                //    {
                //        CategoryName = "Log Handler",
                //        Tools =
                //        {
                //            new ToolboxItemWrapper(typeof(LogHandler.LogHandlerModule),"Module Log File"),
                //            new ToolboxItemWrapper(typeof(LogHandler.LogHandlerMessageBody),"Message Body Data"),
                //            new ToolboxItemWrapper(typeof(LogHandler.LogHandlerMessageBodyClear),"Message Body Clear"),
                //            new ToolboxItemWrapper(typeof(LogHandler.LogHandlerErrorReport),"Error Report"),
                //            new ToolboxItemWrapper(typeof(LogHandler.LogHandlerErrorReportClear),"Error Report Clear"),
                //            new ToolboxItemWrapper(typeof(LogHandler.LogHandlerKillExcelFileProcess),"Kill Excel File Process"),
                //        }
                //    }
                //    );
                _wfToolbox.Categories.Add(
                    new System.Activities.Presentation.Toolbox.ToolboxCategory
                    {
                        CategoryName = "IMAP",
                        Tools =
                        {
                            new ToolboxItemWrapper(typeof(IMAP.IMAPDownloadAttachments),"Download Attachments"),
                        }
                    }
                    );
                _wfToolbox.Categories.Add(
                    new System.Activities.Presentation.Toolbox.ToolboxCategory
                    {
                        CategoryName = "SMTP",
                        Tools =
                        {
                            new ToolboxItemWrapper(typeof(SMTP.SMTPSend),"Send Email"),
                        }
                    }
                    );
                _wfToolbox.Categories.Add(
                    new System.Activities.Presentation.Toolbox.ToolboxCategory
                    {
                        CategoryName = "Outlook",
                        Tools =
                        {
                            new ToolboxItemWrapper(typeof(Outlook.OutlookSendEmail),"Send Email"),
                            new ToolboxItemWrapper(typeof(Outlook.OutlookReadEmail),"Read Mails"),
                        }
                    }
                    );
                #region additional files
                //_wfToolbox.Categories.Add(
                //        new System.Activities.Presentation.Toolbox.ToolboxCategory
                //        {
                //            CategoryName = "Excel Activities",
                //            Tools =
                //            {
                //                            new ToolboxItemWrapper(typeof(AIBOTS.CSV.Activities.ReadCsvFile),"Read Csv File"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.CSV.Activities.WriteCsvFile),"Write Csv File"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.CSV.Activities.AppendCsvFile),"Append Csv File"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelApplicationScope),"Excel Application"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelAppendRange),"ExcelAppendRange"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelCloseWorkbook),"ExcelCloseWorkbook"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelDeleteColumn),"ExcelDeleteColumn"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelFilterTable),"ExcelFilterTable"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelGetCellColor),"ExcelGetCellColor"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelGetTableRange),"ExcelGetTableRange"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelInsertColumn),"ExcelInsertColumn"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelReadCell),"ExcelReadCell"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelReadCellFormula),"ExcelReadCellFormula"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelReadColumn),"ExcelReadColumn"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelReadRange),"ExcelReadRange"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelReadRow),"ExcelReadRow"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelSaveWorkbook),"ExcelSaveWorkbook"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelSelectRange),"ExcelSelectRange"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelSetRangeColor),"ExcelSetRangeColor"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelSortTable),"ExcelSortTable"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelWriteCell),"ExcelWriteCell"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExcelWriteRange),"ExcelWriteRange"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.ExecuteMacro),"ExecuteMacro"),
                //                            new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.InvokeVBA),"InvokeVBA")
                //                            //new ToolboxItemWrapper(typeof(AIBOTS.Excel.Activities.),"Excel"),
                //            }
                //        }
                //          //  );

                //          _wfToolbox.Categories.Add(
                //new System.Activities.Presentation.Toolbox.ToolboxCategory
                //{
                //	CategoryName = "UI Activities",
                //	Tools =
                //	{
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Clipboard_Get_Text)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Clipboard_Selected_Copy)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Clipboard_Set_Text)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Keybord_Copy)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Keybord_Cut)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Keybord_Paste)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Keybord_Select_All)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Mouse_Pointer_Click_Double)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Mouse_Pointer_Click_Left)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Mouse_Pointer_Click_Right)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Mouse_Pointer_Drag)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Send)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Send_Control)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.Send_To_Window)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.String_Between)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.String_Left)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.String_Match)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.String_Mid)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.String_Replace)),
                //		 new ToolboxItemWrapper(typeof(Custom_Control.String_Right)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.String_Split)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.FileList_to_Array)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.Loop_ForEach)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.Excel_Scope)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.Excel_Save_File)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.PhoenixOCR)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.Open_File)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.Cell_push)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.Internet_Explorer)),
                //		 //new ToolboxItemWrapper(typeof(Custom_Control.User_Input)),

                //                      }
                //}
                //);
                //LabelStatusBar.Content = String.Format("Loaded Activities: {0}", activitiesCount.ToString());
                #endregion
                WfToolboxBorder.Child = _wfToolbox;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message,"Compile Error",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }


        /// <summary>
        /// Retrieve Workflow Execution Logs and Workflow Execution Outputs
        /// </summary>
        private async void WfExecutionCompleted(WorkflowApplicationCompletedEventArgs ev)
        {
            try
            {
                //retrieve & display execution log
                _timer.Stop();
                 UpdateTrackingData();

                //retrieve & display execution output
                foreach (var item in ev.Outputs)
                {
                     consoleOutput.Dispatcher.Invoke(
                        System.Windows.Threading.DispatcherPriority.Normal,
                        new Action(
                            async delegate()
                            {
                                 consoleOutput.Text += string.Format("[{0}] {1}" + Environment.NewLine, item.Key, item.Value);
                            }
                    ));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #region Commands Handlers - Executed - New, Open, Save, Run

        /// <summary>
        /// Creates a new Workflow Application instance and executes the Current Workflow
        /// </summary>
        private void CmdWorkflowRun(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {

                if (_currentWorkflowFile == String.Empty)
                {
                    var dialogSave = new SaveFileDialog();
                    dialogSave.Title = "Save Workflow";
                    dialogSave.Filter = "Workflows (.xaml)|*.xaml";

                    if (dialogSave.ShowDialog() == true)
                    {
                        CustomWfDesigner.Instance.Save(dialogSave.FileName);
                        _currentWorkflowFile = dialogSave.FileName;
                        LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                        try
                        {

                            outputter.clearText();


                            //get workflow source from designer
                            CustomWfDesigner.Instance.Flush();
                            string readText = System.IO.File.ReadAllText(@"d:\1.xaml");
                            //MemoryStream workflowStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(CustomWfDesigner.Instance.Text));
                            MemoryStream workflowStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(readText));
                            
                            ActivityXamlServicesSettings settings = new ActivityXamlServicesSettings()
                            {
                                CompileExpressions = true
                            };

                            DynamicActivity activityExecute = ActivityXamlServices.Load(workflowStream, settings) as DynamicActivity;

                            //configure workflow application    
                            //consoleExecutionLog.Text = String.Empty;
                            //consoleOutput.Text = String.Empty;
                            _executionLog = new CustomTrackingParticipant();
                            _wfApp = new WorkflowApplication(activityExecute);
                            _wfApp.Extensions.Add(_executionLog);
                            _wfApp.Completed = WfExecutionCompleted;

                            //execute 
                            _wfApp.Run();

                            //enable timer for real-time logging
                            _timer.Start();
                        }

                        catch
                        {
                            System.Windows.MessageBox.Show("Complete flow not established , Try Again with other combinations of controls", "Main", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }
                else
                {
                    CustomWfDesigner.Instance.Save(_currentWorkflowFile);
                    LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                    try
                    {

                        outputter.clearText();


                        //get workflow source from designer
                        CustomWfDesigner.Instance.Flush();
                        MemoryStream workflowStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(CustomWfDesigner.Instance.Text));
                        //string readText = System.IO.File.ReadAllText(@"d:\1.xaml");
                        //MemoryStream workflowStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(readText));
                        ActivityXamlServicesSettings settings = new ActivityXamlServicesSettings()
                        {
                            CompileExpressions = true
                        };
                        

                       // DynamicActivity activityExecute = ActivityXamlServices.Load(workflowStream, settings) as DynamicActivity;
                        DynamicActivity activityExecute = ActivityXamlServices.Load(workflowStream, settings) as DynamicActivity;

                        //configure workflow application    
                        //consoleExecutionLog.Text = String.Empty;
                        //consoleOutput.Text = String.Empty;
                        _executionLog = new CustomTrackingParticipant();
                        _wfApp = new WorkflowApplication(activityExecute);
                        _wfApp.Extensions.Add(_executionLog);
                        _wfApp.Completed = WfExecutionCompleted;

                        //execute 
                        _wfApp.Run();

                        //enable timer for real-time logging
                        _timer.Start();
                    }

                    catch
                    {
                        System.Windows.MessageBox.Show("Complete flow not established , Try Again with other combinations of controls", "Main", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch
            {
                ;
            }

        }

        /// <summary>
        /// Stops the Current Workflow
        /// </summary>
        private void CmdWorkflowStop(object sender, ExecutedRoutedEventArgs e)
        {

            //manual stop
            if (_wfApp != null)
            {
                try
                {
                    _wfApp.Abort("Stopped by User");
                    _timer.Stop();
                    UpdateTrackingData();
                    Console.WriteLine("Stopped by User");

                }
                catch
                {
                    System.Windows.MessageBox.Show("Stoped Already", "Main");
                }
            }



        }


        /// <summary>
        /// Save the current state of a Workflow
        /// </summary>
        private void CmdWorkflowSave(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {

                if (_currentWorkflowFile == String.Empty)
                {
                    var dialogSave = new SaveFileDialog();
                    dialogSave.Title = "Save Workflow";
                    dialogSave.Filter = "Workflows (.xaml)|*.xaml";

                    if (dialogSave.ShowDialog() == true)
                    {
                        CustomWfDesigner.Instance.Save(dialogSave.FileName);
                        _currentWorkflowFile = dialogSave.FileName;
                        LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                    }
                }
                else
                {
                    CustomWfDesigner.Instance.Save(_currentWorkflowFile);
                    LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                }
            }
            catch
            {
                ;
            }
        }
        private void ButtonProjectSaveAs_Click(object sender, RoutedEventArgs e)
        {
            var dialogSave = new SaveFileDialog();
                dialogSave.Title = "Save Workflow";
                dialogSave.Filter = "Workflows (.xaml)|*.xaml";

                if (dialogSave.ShowDialog() == true)
                {
                    CustomWfDesigner.Instance.Save(dialogSave.FileName);
                    _currentWorkflowFile = dialogSave.FileName;
                    LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                }
        }

        /// <summary>
        /// Creates a new Workflow Designer instance and loads the Default Workflow 
        /// </summary>
        private void CmdWorkflowNew(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result3 = System.Windows.Forms.MessageBox.Show("Do you want to save the file before closing ?", "New File", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button1);
             
            try
            {
                    if (result3 == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {

                            if (_currentWorkflowFile == String.Empty)
                            {
                                var dialogSave = new SaveFileDialog();
                                dialogSave.Title = "Save Workflow";
                                dialogSave.Filter = "Workflows (.xaml)|*.xaml";

                                if (dialogSave.ShowDialog() == true)
                                {
                                    CustomWfDesigner.Instance.Save(dialogSave.FileName);
                                    _currentWorkflowFile = dialogSave.FileName;
                                    LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                                _currentWorkflowFile = String.Empty;
                                CustomWfDesigner.NewInstance();
                                WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
                                WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;
                                LabelStatusBar.Content = "New File";
                            } 
                            }
                            else
                            {
                                CustomWfDesigner.Instance.Save(_currentWorkflowFile);
                                LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                            _currentWorkflowFile = String.Empty;
                            CustomWfDesigner.NewInstance();
                            WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
                            WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;
                            LabelStatusBar.Content = "New File";
                        } 
                            
                        }
                        catch
                        {
                            ;
                        }
                    }
                    else if (result3 == System.Windows.Forms.DialogResult.No)
                    {
                        _currentWorkflowFile = String.Empty;
                        CustomWfDesigner.NewInstance();
                        WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
                        WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;
                        LabelStatusBar.Content = "New File";
                    }
                    else
                    {
                        ;
                    }
            }
            catch
            {
                ;
            }
        }

        /// <summary>
        /// Creates a new Workflow Designer instance and loads the Default Workflow 
        /// </summary>
        private void CmdWorkflowNewVB(object sender, ExecutedRoutedEventArgs e)
        {
            try
            { 
            _currentWorkflowFile = String.Empty;
            CustomWfDesigner.NewInstanceVB();
            WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
            WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;
            }
            catch
            {
                ;
            }
        }


        /// <summary>
        /// Creates a new Workflow Designer instance and loads the Default Workflow with C# Expression Editor
        /// </summary>
        private void CmdWorkflowNewCSharp(object sender, ExecutedRoutedEventArgs e)
        {
            try
            { 
            _currentWorkflowFile = String.Empty;
            CustomWfDesigner.NewInstanceCSharp();
            WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
            WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;
            }
            catch
            {
                ;
            }
        
        }


        /// <summary>
        /// Loads a Workflow into a new Workflow Designer instance
        /// </summary>
        private void CmdWorkflowOpen(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result3 = System.Windows.Forms.MessageBox.Show("Do you want to save the file before closing ?", "New File", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button1);

            try
            {
                if (result3 == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {

                        if (_currentWorkflowFile == String.Empty)
                        {
                            var dialogSave = new SaveFileDialog();
                            dialogSave.Title = "Save Workflow";
                            dialogSave.Filter = "Workflows (.xaml)|*.xaml";

                            if (dialogSave.ShowDialog() == true)
                            {
                                CustomWfDesigner.Instance.Save(dialogSave.FileName);
                                _currentWorkflowFile = dialogSave.FileName;
                                LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                                try
                                {


                                    var dialogOpen = new OpenFileDialog();
                                    dialogOpen.Title = "Open Workflow";
                                    dialogOpen.Filter = "Workflows (.xaml)|*.xaml";

                                    if (dialogOpen.ShowDialog() == true)
                                    {
                                        using (var file = new StreamReader(dialogOpen.FileName, true))
                                        {
                                            CustomWfDesigner.NewInstance(dialogOpen.FileName);
                                            WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
                                            WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;

                                            _currentWorkflowFile = dialogOpen.FileName;
                                        }
                                    }
                                }
                                catch
                                {
                                    ;
                                }
                            }
                        }
                        else
                        {
                            CustomWfDesigner.Instance.Save(_currentWorkflowFile);
                            LabelStatusBar.Content = _currentWorkflowFile + "  -    " + "Saved.";
                            try
                            {


                                var dialogOpen = new OpenFileDialog();
                                dialogOpen.Title = "Open Workflow";
                                dialogOpen.Filter = "Workflows (.xaml)|*.xaml";

                                if (dialogOpen.ShowDialog() == true)
                                {
                                    using (var file = new StreamReader(dialogOpen.FileName, true))
                                    {
                                        CustomWfDesigner.NewInstance(dialogOpen.FileName);
                                        WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
                                        WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;

                                        _currentWorkflowFile = dialogOpen.FileName;
                                    }
                                }
                            }
                            catch
                            {
                                ;
                            }
                        }

                    }
                    catch
                    {
                        ;
                    }
                }
                else if (result3 == System.Windows.Forms.DialogResult.No)
                {
                    try
                    {


                        var dialogOpen = new OpenFileDialog();
                        dialogOpen.Title = "Open Workflow";
                        dialogOpen.Filter = "Workflows (.xaml)|*.xaml";

                        if (dialogOpen.ShowDialog() == true)
                        {
                            using (var file = new StreamReader(dialogOpen.FileName, true))
                            {
                                CustomWfDesigner.NewInstance(dialogOpen.FileName);
                                WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
                                WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;

                                _currentWorkflowFile = dialogOpen.FileName;
                            }
                        }
                    }
                    catch
                    {
                        ;
                    }
                }
                else
                {
                    ;
                }
            }
            catch
            {
                ;
            }



            //try
            //{

            
            //var dialogOpen = new OpenFileDialog();
            //dialogOpen.Title = "Open Workflow";
            //dialogOpen.Filter = "Workflows (.xaml)|*.xaml";

            //if (dialogOpen.ShowDialog() == true)
            //{
            //    using (var file = new StreamReader(dialogOpen.FileName, true))
            //    {
            //        CustomWfDesigner.NewInstance(dialogOpen.FileName);
            //        WfDesignerBorder.Child = CustomWfDesigner.Instance.View;
            //        WfPropertyBorder.Child = CustomWfDesigner.Instance.PropertyInspectorView;

            //        _currentWorkflowFile = dialogOpen.FileName;
            //    }
            //}
            //}
            //catch
            //{
            //    ;
            //}
        }

        #endregion


        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {   
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }

    
    

}