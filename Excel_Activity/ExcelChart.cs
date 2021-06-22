using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Excel_Activity
{
    public sealed class ExcelChart : CodeActivity
    {
        public InArgument<string> From { get; set; }
        public InArgument<string> To { get; set; }
        public InArgument<XlChartType> ChartType { get; set; }
        public InArgument<string> ChartTitle { get; set; }
        public InArgument<string> CategoryTitle { get; set; }
        public InArgument<string> ValueTitle { get; set; }
        public InArgument<double> PositionLeft { get; set; }
        public InArgument<double> PositionTop { get; set; }
        public InArgument<double> ChartWidth { get; set; }
        public InArgument<double> ChartHeight { get; set; }
        public InArgument<int> ChartLayout { get; set; }
        public InArgument<double> YAxisMinimum { get; set; }
        public InArgument<double> YAxisMaximum { get; set; }
        public InArgument<int> DataFromSheet { get; set; }
        public OutArgument<bool> Output { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string from = context.GetValue(this.From);
            string to = context.GetValue(this.To);
            XlChartType chart = context.GetValue(this.ChartType);
            string title = context.GetValue(this.ChartTitle);
            string category = context.GetValue(this.CategoryTitle);
            string value = context.GetValue(this.ValueTitle);
            double left = context.GetValue(this.PositionLeft);
            double top = context.GetValue(PositionTop);
            double width = context.GetValue(this.ChartWidth);
            double height = context.GetValue(this.ChartHeight);
            int layout = context.GetValue(this.ChartLayout);
            double minimum = context.GetValue(this.YAxisMinimum);
            double maximum = context.GetValue(this.YAxisMaximum);
            int data = context.GetValue(this.DataFromSheet);
            string error = null;
            bool output = false;
            try
            {
                output = Excel_Core.ExcelChart(from, to, chart, title, category, value, left, top, width, height, layout, minimum, maximum, data);
                context.SetValue(Output, output);
            }
            catch (Exception ex)
            {
                string[] errorArray = { };
                error = ex.ToString();
                context.SetValue(Error, error);
            }
        }

    }
}
