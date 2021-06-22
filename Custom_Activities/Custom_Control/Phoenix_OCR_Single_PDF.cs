using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_Control
{
    public partial class Phoenix_OCR_Single_PDF : Form
    {
        CustomFunction c = new CustomFunction();
        public Phoenix_OCR_Single_PDF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Browse PDF";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                try
                { 
                    textBox1.Text = fdlg.FileName;
                    MessageBox.Show(textBox1.Text);
                    string a = c.PheniexOCR(@"" + textBox1.Text);
                    textBox2.Text = a;
                }
                catch
                {
                    ;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //textBox1.Text = fdlg.FileName;
                string a = c.PheniexOCR(@"" + textBox1.Text);
                textBox2.Text = a;
            }
            catch
            {
                ;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            MessageBox.Show("Clipbord Cleared");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
            MessageBox.Show("Copied to Clipbord");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = ""; 
        }
    }
}
