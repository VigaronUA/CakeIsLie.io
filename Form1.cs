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
        int y = 0;
        int sizeH = 0;
        int sizeW=0;
        Random randomGod;
        
        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            randomGod = new Random();
            timer1.Interval = 10;

            //начальная позиция по высоте/ширине для зоны
            x = randomGod.Next(0, this.Width);
            y = randomGod.Next(0,this.Height);


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

       
          

         void timer1_Tick(object sender, EventArgs e)
        {   
            //если начальная позиция по высоте больше 0 - тогда отнимаем 1 от позиции двигая зону вверх
            //и сдвигаем 1 пиксель вправо ширины
            if(x > 0) {x--;  sizeH ++;}

            //так же и по ширине
            if(y > 0){ y--; sizeW ++;}


            //в любом случае отрисовываем справа еще 1 пиксель
            sizeW ++;
            //так же внизу
            sizeH ++;
            
            Rectangle rectangle = new Rectangle(x, y, sizeH, sizeW);
            Pen drawingPen = drawingPen = new Pen(Color.Blue, 1);
            graphics.DrawRectangle(drawingPen, rectangle);
            //если дошли донизу и до низу - остановка таймера (все умерли)
            if (sizeH == this.Height && sizeW == this.Width) timer1.Enabled = false;
        }
    }
}
