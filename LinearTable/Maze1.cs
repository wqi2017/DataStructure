using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LinearTable
{
    public partial class Maze1 : Form
    {
        public Maze1()
        {
            InitializeComponent();
            myg1 = pictureBox1.CreateGraphics();
            myg2 = pictureBox2.CreateGraphics();
        }

       


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            string str = "..\\..\\data\\";
            dlg.InitialDirectory = str;
            dlg.Filter = "数据文件（maze*.dat）|maze*.dat|文本文件                                                                          （maze*.txt）|maze*.txt";
            dlg.Title = "打开迷宫数据文件";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;
                StreamReader sr = new StreamReader(textBox2.Text);
                textBox1.Text = sr.ReadToEnd();

                sr.Close();
                button3.Enabled = true;
            }
            else 
                button3.Enabled = false;

        }
        Graphics myg1,myg2;
        private void DrawMaze(CMaze m_maze, bool flag)
        {
            Brush b1 = new SolidBrush(Color.Gray);
            Brush b2 = new SolidBrush(Color.Yellow);
            Brush b3 = new SolidBrush(Color.Green);
            Brush b4 = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.Red, 1);
            if(flag==false)
            {
                
                int width = pictureBox1.Width;
                int height = pictureBox1.Height;
                myg1.FillRectangle(b4, new Rectangle(0,0,width, height));
                Point start = new Point(30, 30);
                int interval_x=Convert.ToInt16((width-60)/m_maze.Cols);
                int interval_y=Convert.ToInt16((height-60)/m_maze.Rows);
                
                for (int i=0;i<m_maze.Rows;i++)
                {
                    for (int j = 0; j < m_maze.Cols; j++)
                    {
                        Point p1 = new Point(start.X+interval_x*j, start.Y + interval_y * i);
                        Point p2 = new Point(p1.X + interval_x, p1.Y + interval_y) ;
                        if (m_maze.Getelems(i + 1, j + 1) == 1)
                            myg1.FillRectangle(b1, p1.X, p1.Y, interval_x, interval_y);
                        else if (m_maze.Getelems(i + 1, j + 1) == 0)
                            myg1.FillRectangle(b2, p1.X, p1.Y, interval_x, interval_y);
                    }
                }
                for (int i=0;i<=m_maze.Rows;i++)
                {
                    Point p1=new Point(start.X, start.Y + interval_y * i);
                    Point p2=new Point(start.X +interval_x*m_maze.Cols , start.Y + interval_y * i);
                    Font font = new Font("华为宋体", 12);
                    if(i<m_maze.Rows)
                        myg1.DrawString(Convert.ToString(i+1),font,b3,new Point(p1.X-20,p1.Y));
                    myg1.DrawLine(pen, p1, p2);
                }
                for (int i=0;i<=m_maze.Cols;i++)
                {
                    Point p1 = new Point(start.X + interval_x * i, start.Y);
                    Point p2 = new Point(start.X + interval_x * i, start.Y + interval_y * m_maze.Rows);
                    Font font = new Font("华为宋体", 12);
                    if (i < m_maze.Cols)
                        myg1.DrawString(Convert.ToString(i + 1), font, b3, new Point(p1.X , p1.Y-20));
                    myg1.DrawLine(pen, p1, p2); 
                }
            }
            else
            {
                int width = pictureBox2.Width;
                int height = pictureBox2.Height;
                myg2.FillRectangle(b4, new Rectangle(0, 0, width, height));
                Point start = new Point(30, 30);
                int interval_x = Convert.ToInt16((width - 60) / m_maze.Cols);
                int interval_y = Convert.ToInt16((height - 60) / m_maze.Rows);

                for (int i = 0; i < m_maze.Rows; i++)
                {
                    for (int j = 0; j < m_maze.Cols; j++)
                    {
                        Point p1 = new Point(start.X + interval_x * j, start.Y + interval_y * i);
                        Point p2 = new Point(p1.X + interval_x, p1.Y + interval_y);
                        if (m_maze.Getelems(i + 1, j + 1) == 1)
                            myg2.FillRectangle(b1, p1.X, p1.Y, interval_x, interval_y);
                        else if (m_maze.Getelems(i + 1, j + 1) == 0)
                            myg2.FillRectangle(b2, p1.X, p1.Y, interval_x, interval_y);
                        else if (m_maze.Getelems(i + 1, j + 1) == -1)
                            myg2.FillRectangle(b3, p1.X, p1.Y, interval_x, interval_y);
                    }
                }
                for (int i = 0; i <= m_maze.Rows; i++)
                {
                    Point p1 = new Point(start.X, start.Y + interval_y * i);
                    Point p2 = new Point(start.X + interval_x * m_maze.Cols, start.Y + interval_y * i);
                    Font font = new Font("华为宋体", 12);
                    if (i < m_maze.Rows)
                        myg2.DrawString(Convert.ToString(i + 1), font, b3, new Point(p1.X - 20, p1.Y));
                    myg2.DrawLine(pen, p1, p2);
                }
                for (int i = 0; i <= m_maze.Cols; i++)
                {
                    Point p1 = new Point(start.X + interval_x * i, start.Y);
                    Point p2 = new Point(start.X + interval_x * i, start.Y + interval_y * m_maze.Rows);
                    Font font = new Font("华为宋体", 12);
                    if (i < m_maze.Cols)
                        myg2.DrawString(Convert.ToString(i + 1), font, b3, new Point(p1.X, p1.Y - 20));
                    myg2.DrawLine(pen, p1, p2);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(textBox1.Text);
            CMaze m_cmaze = new CMaze(str);
            DrawMaze(m_cmaze, false);
            textBox3.Text= m_cmaze.ShortPath();
            DrawMaze(m_cmaze, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // OpenFileDialog dlg = new OpenFileDialog();
            SaveFileDialog dlg = new SaveFileDialog();
            string str = "..\\..\\data\\";
            dlg.InitialDirectory = str;
            dlg.Filter = "数据文件（maze*.dat）|maze*.dat|文本文件                                                                          （maze*.txt）|maze*.txt";
            dlg.Title = "打开迷宫数据文件";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;
                StreamWriter sr = new StreamWriter(dlg.FileName);
                //StreamReader sr = new StreamReader(textBox2.Text);
                //textBox1.Text = sr.ReadToEnd();
                sr.Write(textBox1.Text);

                sr.Close();
                button3.Enabled = true;
            }
            else
                button3.Enabled = false;
        }
    }
}
