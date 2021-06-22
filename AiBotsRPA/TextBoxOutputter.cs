using System;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace AibotsRPA
{

    public class TextBoxOutputter : TextWriter
    {
        TextBox textBox = null;

        public   TextBoxOutputter(TextBox output)
        {
            try
            {

            
            textBox = output;

            }
            catch
            {
                ;
            }
        }

        public override async void Write(char value)
        {
            try
            {
                  base.Write(value);
            await textBox.Dispatcher.BeginInvoke(new Action(() =>
            {
                textBox.AppendText(value.ToString());
            }));
            }
            catch
            {
                ;
            }
        }
        public void clearText()
        {
            textBox.Text = "";
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}