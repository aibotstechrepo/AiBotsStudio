using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Runtime.InteropServices;

namespace GlobalMacroRecorder
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {

        }
    }
  

namespace Dotnetrix.Samples.CSharp
    {

        public enum ButtonDrawState
        {
            Normal = 1,
            Hot,
            Pressed,
            Disabled,
            Focused
        }


        /// <summary>
        /// Summary description for Button.
        /// </summary>
        public class Button : System.Windows.Forms.Button
        {
            /// <summary> 
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.Container components = null;

            public Button()
            {
                // This call is required by the Windows.Forms Form Designer.
                InitializeComponent();

                // TODO: Add any initialization after the InitializeComponent call

            }


            /// <summary> 
            /// Clean up any resources being used.
            /// </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }


            #region Component Designer generated code
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                components = new System.ComponentModel.Container();
            }
            #endregion

            private ButtonDrawState m_State = ButtonDrawState.Normal;
            private bool keyPressed;

            public new event PaintEventHandler Paint;

            [Browsable(false)]
            public ButtonDrawState State
            {
                get { return m_State; }
            }


            private bool VisualStylesEnabled
            {
                get
                {
                    NativeMethods.DLLVERSIONINFO dllver = new NativeMethods.DLLVERSIONINFO();
                    dllver.cbSize = Marshal.SizeOf(dllver);
                    NativeMethods.CommonControlsGetVersion(ref dllver);
                    if (dllver.dwMajorVersion >= 6)
                    {
                        return NativeMethods.IsAppThemed();
                    }
                    return false;
                }
            }


            #region Draw Methods

            protected override void OnPaint(PaintEventArgs e)
            {
                bool Result = false;

                if (this.FlatStyle == FlatStyle.Standard && this.VisualStylesEnabled)
                {
                    e.Graphics.Flush();
                    Result = DrawVSButton(e.Graphics);
                    if (Result)
                    {
                        DrawImage(e.Graphics);
                        DrawText(e.Graphics);
                        DrawFocus(e.Graphics);
                    }
                }

                if (Result == false) base.OnPaint(e);
                //Raising a Paint Event allows us to custom paint the 
                //content of our Button without modifying this class.
                if (Paint != null)
                    Paint(this, e);

            }


            protected bool DrawVSButton(Graphics g)
            {
                int ReturnValue = 1;
                IntPtr hTheme = NativeMethods.OpenThemeData(this.Handle, "BUTTON");
                if (!hTheme.Equals(IntPtr.Zero))
                {
                    IntPtr hdc = g.GetHdc();
                    NativeMethods.RECT r = new NativeMethods.RECT(new Rectangle(Point.Empty, this.Size));
                    if (NativeMethods.DrawThemeParentBackground(Handle, hdc, ref r) == NativeMethods.S_OK)
                    {
                        ReturnValue = NativeMethods.DrawThemeBackground(hTheme, hdc, 1, (int)m_State, ref r, ref r);
                    }
                    g.ReleaseHdc(hdc);
                    NativeMethods.CloseThemeData(hTheme);
                }
                return (ReturnValue == NativeMethods.S_OK);
            }


            protected void DrawImage(Graphics g)
            {
                if (this.Image == null) return;

                PointF pt = new Point();

                switch (this.ImageAlign)
                {
                    case ContentAlignment.TopLeft:
                        {
                            pt.X = 5;
                            pt.Y = 5;
                            break;
                        }
                    case ContentAlignment.TopCenter:
                        {
                            pt.X = Convert.ToSingle(Width - this.Image.Width) / 2;
                            pt.Y = 5;
                            break;
                        }
                    case ContentAlignment.TopRight:
                        {
                            pt.X = Width - this.Image.Width - 5;
                            pt.Y = 5;
                            break;
                        }
                    case ContentAlignment.MiddleLeft:
                        {
                            pt.X = 5;
                            pt.Y = Convert.ToSingle(Height - this.Image.Height) / 2;
                            break;
                        }
                    case ContentAlignment.MiddleCenter:
                        {
                            pt.X = Convert.ToSingle(Width - this.Image.Width) / 2;
                            pt.Y = Convert.ToSingle(Height - this.Image.Height) / 2;
                            break;
                        }
                    case ContentAlignment.MiddleRight:
                        {
                            pt.X = Width - this.Image.Width - 5;
                            pt.Y = Convert.ToSingle(Height - this.Image.Height) / 2;
                            break;
                        }
                    case ContentAlignment.BottomLeft:
                        {
                            pt.X = 5;
                            pt.Y = Height - this.Image.Height - 5;
                            break;
                        }
                    case ContentAlignment.BottomCenter:
                        {
                            pt.X = Convert.ToSingle(Width - this.Image.Width) / 2;
                            pt.Y = Height - this.Image.Height - 5;
                            break;
                        }
                    default:
                        {
                            pt.X = Width - this.Image.Width - 5;
                            pt.Y = Height - this.Image.Height - 5;
                            break;
                        }
                }

                if (this.Enabled)
                {
                    if (this.ImageList == null)
                        g.DrawImage(this.Image, pt.X, pt.Y);
                    else
                        this.ImageList.Draw(g, Point.Round(pt), this.ImageIndex);
                }
                else
                    ControlPaint.DrawImageDisabled(g, this.Image, (int)pt.X, (int)pt.Y, this.BackColor);
            }


            protected void DrawText(Graphics g)
            {
                SolidBrush TextBrush = new SolidBrush(this.ForeColor);
                RectangleF R = new RectangleF(3, 3, Width - 6, Height - 6);

                if (!this.Enabled) TextBrush.Color = SystemColors.GrayText;

                StringFormat sf = new StringFormat(StringFormatFlags.LineLimit);

                if (ShowKeyboardCues)
                    sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
                else
                    sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide;

                switch (this.TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        {
                            sf.Alignment = StringAlignment.Near;
                            sf.LineAlignment = StringAlignment.Near;
                            break;
                        }
                    case ContentAlignment.TopCenter:
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Near;
                            break;
                        }
                    case ContentAlignment.TopRight:
                        {
                            sf.Alignment = StringAlignment.Far;
                            sf.LineAlignment = StringAlignment.Near;
                            break;
                        }
                    case ContentAlignment.MiddleLeft:
                        {
                            sf.Alignment = StringAlignment.Near;
                            sf.LineAlignment = StringAlignment.Center;
                            break;
                        }
                    case ContentAlignment.MiddleCenter:
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            break;
                        }
                    case ContentAlignment.MiddleRight:
                        {
                            sf.Alignment = StringAlignment.Far;
                            sf.LineAlignment = StringAlignment.Center;
                            break;
                        }
                    case ContentAlignment.BottomLeft:
                        {
                            sf.Alignment = StringAlignment.Near;
                            sf.LineAlignment = StringAlignment.Far;
                            break;
                        }
                    case ContentAlignment.BottomCenter:
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Far;
                            break;
                        }
                    default:
                        {
                            sf.Alignment = StringAlignment.Far;
                            sf.LineAlignment = StringAlignment.Far;
                            break;
                        }
                }

                g.DrawString(this.Text, this.Font, TextBrush, R, sf);

            }


            protected void DrawFocus(Graphics g)
            {
                if ((this.ShowFocusCues && this.Focused) == false) return;
                Rectangle focusRect = this.ClientRectangle;
                focusRect.Inflate(-3, -3);
                ControlPaint.DrawFocusRectangle(g, focusRect);
            }


            #endregion

            #region Control Actions

            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                if (!this.Enabled) return;
                if (e.KeyValue == (int)Keys.Space)
                {
                    keyPressed = true;
                    m_State = ButtonDrawState.Pressed;
                    Invalidate();
                }
            }


            protected override void OnKeyUp(KeyEventArgs e)
            {
                base.OnKeyUp(e);
                if (e.KeyValue == (int)Keys.Space)
                {
                    keyPressed = false;
                    m_State = ButtonDrawState.Focused;
                    Invalidate();
                }
            }


            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                if (this.Enabled && !keyPressed)
                {
                    m_State = ButtonDrawState.Hot;
                    Invalidate();
                }
            }


            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                if (this.Enabled && !keyPressed)
                {
                    if (this.IsDefault)
                    {
                        m_State = ButtonDrawState.Focused;
                    }
                    else
                    {
                        m_State = ButtonDrawState.Normal;
                    }
                    Invalidate();
                }
            }


            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (!this.Enabled) return;
                if (e.Button == MouseButtons.Left)
                {
                    m_State = ButtonDrawState.Pressed;
                    Invalidate();
                }
            }


            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                if (this.Enabled)
                {
                    m_State = ButtonDrawState.Focused;
                    Invalidate();
                }
            }


            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                if (!this.Enabled) return;
                if (Rectangle.FromLTRB(0, 0, Width, Height).Contains(e.X, e.Y) && e.Button == MouseButtons.Left)
                    m_State = ButtonDrawState.Pressed;
                else
                {
                    if (keyPressed) return;
                    m_State = ButtonDrawState.Hot;
                }
                Invalidate();
            }


            protected override void OnGotFocus(EventArgs e)
            {
                base.OnGotFocus(e);
                if (this.Enabled)
                {
                    m_State = ButtonDrawState.Focused;
                    Invalidate();
                }
            }


            protected override void OnLostFocus(EventArgs e)
            {
                base.OnLostFocus(e);
                if (this.Enabled)
                {
                    m_State = ButtonDrawState.Normal;
                    Invalidate();
                }
            }


            protected override void OnEnabledChanged(EventArgs e)
            {
                base.OnEnabledChanged(e);
                if (this.Enabled)
                {
                    m_State = ButtonDrawState.Normal;
                }
                else
                {
                    m_State = ButtonDrawState.Disabled;
                }
                Invalidate();

            }


            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                base.OnLostFocus(EventArgs.Empty);
            }


            protected override void OnDoubleClick(EventArgs e)
            {
                base.OnDoubleClick(e);
                base.OnLostFocus(EventArgs.Empty);
            }


            #endregion

        }

        internal class NativeMethods
        {
            private NativeMethods()
            {
                //Uninstantiable Class
            }

            [DllImport("Comctl32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DllGetVersion")]
            public static extern int CommonControlsGetVersion(ref DLLVERSIONINFO pdvi);

            public struct DLLVERSIONINFO
            {
                public int cbSize, dwMajorVersion, dwMinorVersion, dwBuildNumber, dwPlatformID;
            }


            [DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern bool IsAppThemed();

            [DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public static extern IntPtr OpenThemeData(IntPtr hwnd, String pszClassList);

            [DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int CloseThemeData(IntPtr hTheme);

            [DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int DrawThemeParentBackground(IntPtr hwnd, IntPtr hdc, ref RECT prc);

            [DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, ref RECT pClipRect);

            public struct RECT
            {
                public int l, t, r, b;
                public RECT(Rectangle rect)
                {
                    l = rect.Left;
                    t = rect.Top;
                    r = rect.Right;
                    b = rect.Bottom;
                }
            }


            public const int S_OK = 0;

        }
    }
}



