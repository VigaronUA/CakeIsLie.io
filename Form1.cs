using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace PanSurvival
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        int x = 0;
        int y = 5;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.WindowState = FormWindowState.Maximized;

            this.MaximumSize = this.MinimumSize = new Size(SystemInformation.VirtualScreen.Width + 15, SystemInformation.VirtualScreen.Height + 15);
            this.VScroll = true;
            this.HScroll = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void PaintZone()
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (graphics == null)
                graphics = this.CreateGraphics();
            // Градиентное закрашивание прямоугольника
            //LinearGradientBrush drawingBrush = new LinearGradientBrush(rectangle, Color.Blue, Color.Gold, 45);
            //e.Graphics.FillRectangle(drawingBrush, rectangle);
            // MessageBox.Show((this.Width / 45).ToString());
            for (int i = 0; i < this.Width / 45; i++)
            {
                for (int j = 0; j < this.Height / 45; j++)
                {
                    graphics.DrawImage(Image.FromFile("Grass_1.png"), i * 45, j * 45);
                    graphics.DrawString(i + " " + j, new Font("Calibri", 8), Brushes.Red, (i * 45) + 10, (j * 45) + 10);
                }
                
                // e.Graphics.Flush();

            }
            timer1.Enabled = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {



        }

        private void drawZone(int size,int naPalkeGavno)
        {
            Rectangle rectangle = new Rectangle(x, y, size, naPalkeGavno);
          
            Pen drawingPen = null;
            //1450, 820

            drawingPen = new Pen(Color.Blue, 3);
            Thread.Sleep(10);
            graphics.DrawRectangle(drawingPen, rectangle);

            if (size == 600 && naPalkeGavno == 600) timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0, j = 0; ; i ++, j ++)
            {
                drawZone(i, j);
               
        
            }
            // drawZone(200);
        }
        // Рисование границы прямоугольника.


    }
}
