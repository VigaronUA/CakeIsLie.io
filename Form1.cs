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

        int fieldSizeH = 50;
        int fieldSizeW = 50;
        Random randomGod;
        const int texturSize = 35;
        
        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            randomGod = new Random();
            //timer1.Interval = 10;

            //начальная позиция по высоте/ширине для зоны
            x = randomGod.Next(0, this.Width);
            y = randomGod.Next(0,this.Height);


            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            this.MaximumSize = this.MinimumSize = new Size(SystemInformation.VirtualScreen.Width + 15, SystemInformation.VirtualScreen.Height + 15);
            this.VScroll = true;
            this.HScroll = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
        }

        private void PaintZone()
        {

        }
        private void keyDownListener(object sender, KeyEventArgs e){
            MessageBox.Show(e.KeyData.ToString());
}

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GC.Collect();
            if (graphics == null)
                graphics = this.CreateGraphics();
            // Градиентное закрашивание прямоугольника
            //LinearGradientBrush drawingBrush = new LinearGradientBrush(rectangle, Color.Blue, Color.Gold, 45);
            //e.Graphics.FillRectangle(drawingBrush, rectangle);
            // MessageBox.Show((this.Width / 45).ToString());
            for (int i = 0; i < this.Width / texturSize+1; i++)
            {
                for (int j = 0; j < this.Height / texturSize+1; j++)
                {
                    graphics.DrawImage(Image.FromFile(i == 0 ?  "WayVertical.png" : "Grass_777.png"), i * texturSize, j * texturSize);
                    graphics.DrawString(i + " " + j, new Font("Calibri", 8), Brushes.Red, (i * texturSize) + 1, (j * texturSize) + 1);
                }
                
                // e.Graphics.Flush();

            }
            graphics.DrawImage(Image.FromFile("Man.png"),2 * texturSize,3*texturSize);
            //timer1.Enabled = true;
            //paintRoad();
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
        public void paintRoad()
            {
            for(int i = 0;i<this.Width/texturSize;i++)
                graphics.DrawImage(Image.FromFile("WayHorizontal.png"),i * 45,i * 45);
            }

    }
}
