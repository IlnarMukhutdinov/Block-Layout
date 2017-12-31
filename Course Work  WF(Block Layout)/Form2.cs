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
            int startX = 150,
                startY = 150,
                widthOfRectangle = 100,
                heightOfRectangle = 150,
                labelwidth = 20,
                fontForText = 10;

            string internalLinks = "I = ";
            string externalLinks = "E";
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);

            Label g1Chunk = new Label();
            Label g2Chunk = new Label();
            Label g3Chunk = new Label();
            Label g4Chunk = new Label();
            Label g1InternalLinksCountLabel = new Label();
            Label g2InternalLinksCountLabel = new Label();
            Label g3InternalLinksCountLabel = new Label();
            Label g4InternalLinksCountLabel = new Label();
            Label externalLinksLabel12 = new Label();
            Label externalLinksLabel23 = new Label();
            Label externalLinksLabel34 = new Label();
            Label externalLinksLabel41 = new Label();
            Label externalLinksLabel13 = new Label();
            Label externalLinksLabel42 = new Label();

            graph.DrawRectangle(pen, startX, startY, widthOfRectangle, heightOfRectangle);
            graph.DrawRectangle(pen, startX + 2 * widthOfRectangle, startY, widthOfRectangle, heightOfRectangle);
            graph.DrawLine(pen, startX + widthOfRectangle, startY + heightOfRectangle / 2, startX + 2 * widthOfRectangle, startY + heightOfRectangle / 2);

            g1Chunk.Location = new Point(startX + widthOfRectangle / 2 - fontForText, startY + fontForText);
            g1Chunk.AutoSize = true;
            g1Chunk.Text = "G1: \n";

            for (int i = 0; i < Config_matrix.M; i++)
            {
                g1Chunk.Text += Config_matrix.VertexShape[i] + "\n";
            }

            g1InternalLinksCountLabel.Location = new Point(startX + widthOfRectangle / 2 - fontForText,
                startY + heightOfRectangle - fontForText);
            g1InternalLinksCountLabel.AutoSize = true;
            g1InternalLinksCountLabel.Text = internalLinks + Config_matrix.InternalLinksInResultMatrix[0];

            g2Chunk.Location = new Point(startX + 2 * widthOfRectangle + widthOfRectangle / 2 - fontForText,
                startY + fontForText);
            g2Chunk.AutoSize = true;
            g2Chunk.Text = "G2: \n";

            for (int i = 0; i < Config_matrix.M; i++)
            {
                g2Chunk.Text += Config_matrix.VertexShape[i + Config_matrix.M] + "\n";
            }

            g2InternalLinksCountLabel.Location = new Point(
                startX + 2 * widthOfRectangle + widthOfRectangle / 2 - fontForText,
                startY + heightOfRectangle - fontForText);
            g2InternalLinksCountLabel.AutoSize = true;
            g2InternalLinksCountLabel.Text = internalLinks + Config_matrix.InternalLinksInResultMatrix[1];

            externalLinksLabel12.Location =
                new Point(startX + widthOfRectangle + widthOfRectangle / 2 - fontForText,
                    startY + heightOfRectangle / 2 - fontForText);
            externalLinksLabel12.AutoSize = true;
            externalLinksLabel12.Text = externalLinks + "1 = " + Config_matrix.ExternalLinksInResultMatrix[0];

            pictureBox.Controls.Add(g1Chunk);
            pictureBox.Controls.Add(g2Chunk);
            pictureBox.Controls.Add(g3Chunk);
            pictureBox.Controls.Add(g4Chunk);
            pictureBox.Controls.Add(g1InternalLinksCountLabel);
            pictureBox.Controls.Add(g2InternalLinksCountLabel);
            pictureBox.Controls.Add(g3InternalLinksCountLabel);
            pictureBox.Controls.Add(g4InternalLinksCountLabel);
            pictureBox.Controls.Add(externalLinksLabel12);
            pictureBox.Controls.Add(externalLinksLabel23);
            pictureBox.Controls.Add(externalLinksLabel34);
            pictureBox.Controls.Add(externalLinksLabel41);
            pictureBox.Controls.Add(externalLinksLabel13);
            pictureBox.Controls.Add(externalLinksLabel42);

            switch (Config_matrix.L)
            {
                case 3:
                    graph.DrawRectangle(pen, startX + widthOfRectangle, startY + heightOfRectangle + 10, widthOfRectangle, heightOfRectangle);
                    graph.DrawLine(pen, startX + widthOfRectangle / 2, startY + heightOfRectangle, startX + widthOfRectangle, startY + 10 + heightOfRectangle + heightOfRectangle / 2);
                    graph.DrawLine(pen, startX + 2 * widthOfRectangle, startY + heightOfRectangle + heightOfRectangle / 2, startX + 2 * widthOfRectangle + widthOfRectangle / 2, startY + heightOfRectangle);

                    g3Chunk.Location = new Point(startX + widthOfRectangle + widthOfRectangle / 2 - fontForText, startY + heightOfRectangle + 2 * fontForText);
                    g3Chunk.AutoSize = true;
                    g3Chunk.Text = "G3: \n";

                    for (int i = 0; i < Config_matrix.M; i++)
                    {
                        g3Chunk.Text += Config_matrix.VertexShape[i + Config_matrix.M * 2] + "\n";
                    }

                    g3InternalLinksCountLabel.Location = new Point(startX + widthOfRectangle + widthOfRectangle / 2 - fontForText, startY + 2 * heightOfRectangle - fontForText);
                    g3InternalLinksCountLabel.AutoSize = true;
                    g3InternalLinksCountLabel.Text = internalLinks + Config_matrix.InternalLinksInResultMatrix[2];

                    externalLinksLabel23.Location = new Point(startX + 2 * widthOfRectangle + fontForText, startY + heightOfRectangle + heightOfRectangle / 4);
                    externalLinksLabel23.AutoSize = true;
                    externalLinksLabel23.Text = externalLinks + "2 = " + Config_matrix.ExternalLinksInResultMatrix[1];

                    externalLinksLabel13.Location = new Point(startX + widthOfRectangle / 2, startY + heightOfRectangle + heightOfRectangle / 4);
                    externalLinksLabel13.AutoSize = true;
                    externalLinksLabel13.Text = externalLinks + "3 = " + Config_matrix.ExternalLinksInResultMatrix[2];

                    break;
                case 4:
                    graph.DrawRectangle(pen, startX, startY + heightOfRectangle + heightOfRectangle / 2, widthOfRectangle, heightOfRectangle);
                    graph.DrawRectangle(pen, startX + 2 * widthOfRectangle, startY + heightOfRectangle + heightOfRectangle / 2, widthOfRectangle, heightOfRectangle);
                    graph.DrawLine(pen, startX + widthOfRectangle, startY + 2 * heightOfRectangle, startX + 2 * widthOfRectangle, startY + 2 * heightOfRectangle);

                    graph.DrawLine(pen, startX + widthOfRectangle / 2, startY + heightOfRectangle, startX + widthOfRectangle / 2, startY + heightOfRectangle + heightOfRectangle / 2);
                    graph.DrawLine(pen, startX + 2 * widthOfRectangle + widthOfRectangle / 2, startY + heightOfRectangle, startX + 2 * widthOfRectangle + widthOfRectangle / 2, startY + heightOfRectangle + heightOfRectangle / 2);

                    graph.DrawLine(pen, startX + widthOfRectangle, startY + heightOfRectangle / 2, startX + 2 * widthOfRectangle, startY + 2 * heightOfRectangle);
                    graph.DrawLine(pen, startX + widthOfRectangle, startY + 2 * heightOfRectangle, startX + 2 * widthOfRectangle, startY + heightOfRectangle / 2);

                    g3Chunk.Location = new Point(startX + 2 * widthOfRectangle + widthOfRectangle / 2, startY + heightOfRectangle + heightOfRectangle / 2 + fontForText);
                    g3Chunk.AutoSize = true;
                    g3Chunk.Text = "G3: \n";

                    for (int i = 0; i < Config_matrix.M; i++)
                    {
                        g3Chunk.Text += Config_matrix.VertexShape[i + Config_matrix.M * 2] + "\n";
                    }

                    g4Chunk.Location = new Point(startX + widthOfRectangle / 2, startY + heightOfRectangle + heightOfRectangle / 2 + fontForText);
                    g4Chunk.AutoSize = true;
                    g4Chunk.Text = "G4: \n";

                    for (int i = 0; i < Config_matrix.M; i++)
                    {
                        g4Chunk.Text += Config_matrix.VertexShape[i + Config_matrix.M * 3] + "\n";
                    }

                    g3InternalLinksCountLabel.Location = new Point(startX + 2 * widthOfRectangle + widthOfRectangle / 2, startY + 2 * heightOfRectangle + heightOfRectangle / 2 - fontForText);
                    g3InternalLinksCountLabel.AutoSize = true;
                    g3InternalLinksCountLabel.Text = internalLinks + Config_matrix.InternalLinksInResultMatrix[2];

                    g4InternalLinksCountLabel.Location = new Point(startX + widthOfRectangle / 2, startY + 2 * heightOfRectangle + heightOfRectangle / 2 - fontForText);
                    g4InternalLinksCountLabel.AutoSize = true;
                    g4InternalLinksCountLabel.Text = internalLinks + Config_matrix.InternalLinksInResultMatrix[3];

                    externalLinksLabel23.Location = new Point(startX + 2 * widthOfRectangle + widthOfRectangle / 2, startY + heightOfRectangle + heightOfRectangle / 4);
                    externalLinksLabel23.AutoSize = true;
                    externalLinksLabel23.Text = externalLinks + "2 = " + Config_matrix.ExternalLinksInResultMatrix[1];

                    externalLinksLabel34.Location = new Point(startX + widthOfRectangle + widthOfRectangle / 2, startY + 2 * heightOfRectangle);
                    externalLinksLabel34.AutoSize = true;
                    externalLinksLabel34.Text = externalLinks + "3 = " + Config_matrix.ExternalLinksInResultMatrix[2];

                    externalLinksLabel41.Location = new Point(startX + widthOfRectangle / 2, startY + heightOfRectangle + heightOfRectangle / 4);
                    externalLinksLabel41.AutoSize = true;
                    externalLinksLabel41.Text = externalLinks + "4 = " + Config_matrix.ExternalLinksInResultMatrix[3];

                    externalLinksLabel13.Location = new Point(startX  + widthOfRectangle, startY + 3 * heightOfRectangle / 4);
                    externalLinksLabel13.AutoSize = true;
                    externalLinksLabel13.Text = externalLinks + "5 = " + Config_matrix.ExternalLinksInResultMatrix[4];

                    externalLinksLabel42.Location = new Point(startX + widthOfRectangle + widthOfRectangle / 4 - fontForText, startY + heightOfRectangle + 3 * heightOfRectangle / 4);
                    externalLinksLabel42.AutoSize = true;
                    externalLinksLabel42.Text = externalLinks + "6 = " + Config_matrix.ExternalLinksInResultMatrix[5];
                    break;
            }
            pictureBox.Image = bmp;
        }
    }
}
