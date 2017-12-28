using System;
using System.Drawing;
using System.Windows.Forms;
using Graph_placement_algorithm;

namespace Course_Work__WF_Block_Layout_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DrawResult();
        }

        private void DrawResult()
        {
            int startX = 50, startY = 50, width = 100, height = 150;
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);
            graph.DrawRectangle(pen, startX, startY, width, height);

            for (int i = 0; i < Config_matrix.L; i++)
            {
                if (i % 2 == 0)
                {
                    graph.DrawRectangle(pen, startX + i * (startX + width), startY, width, height);
                    graph.DrawLine(pen, startX + width + i * (startX + width), startY + height / 2,
                        startX + 2 * (startX + width) + i * (startX + width), startY + height / 2);
                }
                else
                    graph.DrawRectangle(pen, startX + i * (startX + width), startY + height, width, height);
            }

            pictureBox.Image = bmp;
        }
        
    }
}
