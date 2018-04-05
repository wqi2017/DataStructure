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
    public partial class Maze2 : Form
    {
        public Maze2()
        {
            InitializeComponent();
            myg = pictureBox1.CreateGraphics();
            string m_strout =init();
            m_maze2 = new CMaze(m_strout, true);
            //draw();
            mouseClick = new Point();
        }
        Graphics myg;
        CMaze m_maze2;
        Point mouseClick;
        bool flag = false;
        /*false left
         *true  right
         */
        bool startORend = false;
        /*false start
         * end  end
         */
        private string init()
        {
           
            string m_strout = ""; 
            OpenFileDialog dlg = new OpenFileDialog();
            string str = "..\\..\\data\\";
            dlg.InitialDirectory = str;
            dlg.Filter = "数据文件（maze*.dat）|maze*.dat|文本文件                                                                          （maze*.txt）|maze*.txt";
            dlg.Title = "打开迷宫数据文件";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dlg.FileName);
                m_strout = sr.ReadToEnd();

                sr.Close();
            }
            return m_strout;
            

        }
        private void draw()
        {
            myg.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            Image image0 = System.Drawing.Image.FromFile("../../tile.bmp");
            Image image1 = System.Drawing.Image.FromFile("../../ball0.bmp");
            //image0对象的宽度和高度
            int pw = image0.Width;
            int ph = image0.Height;
            if(flag==false)
            for (int i = 0; i < m_maze2.Rows + 2; i++)
            {
                for (int j = 0; j < m_maze2.Cols + 2; j++)
                {
                    Rectangle rt1 = new Rectangle(0, 0, pw, ph);
                    Rectangle rt2 = new Rectangle(j * (pw), i * (ph), pw, ph);
                    if (mouseClick.X >= rt2.X && mouseClick.X <= rt2.X + pw && mouseClick.Y >= rt2.Y && mouseClick.Y <= rt2.Y + ph)
                    {
                        if (m_maze2.Getelems(i, j) == -1) m_maze2.Setelems(i, j, 1);
                        else
                            m_maze2.Setelems(i, j, (m_maze2.Getelems(i, j) + 1) % 2);
                        break;
                    }
                }
            }
            else for (int i = 0; i < m_maze2.Rows + 2; i++)
                {
                    for (int j = 0; j < m_maze2.Cols + 2; j++)
                    {
                        Rectangle rt1 = new Rectangle(0, 0, pw, ph);
                        Rectangle rt2 = new Rectangle(j * (pw), i * (ph), pw, ph);
                        if (mouseClick.X >= rt2.X && mouseClick.X <= rt2.X + pw && mouseClick.Y >= rt2.Y && mouseClick.Y <= rt2.Y + ph)
                        {
                            moved t = new moved();
                            t.initmoved(i, j);
                            if (startORend == false)
                                m_maze2.Start = t;
                            else m_maze2.End = t;
                            startORend = !startORend;
                        }
                    }
                }
            m_maze2.ShortPath2();
            //定义矩形区域
            for(int i=0;i<m_maze2.Rows+2;i++)
            {
                for (int j=0;j<m_maze2.Cols+2;j++)
                {
                    Rectangle rt1 = new Rectangle(0, 0, pw, ph);
                    Rectangle rt2 = new Rectangle(j * (pw), i * (ph), pw, ph);
                    
                    if(m_maze2.Getelems(i,j)==1)
                    myg.DrawImage(image0, rt2, rt1, GraphicsUnit.Pixel);
                    else if(m_maze2.Getelems(i,j)==-1)
                    {
                        myg.DrawImage(image1,rt2,rt1,GraphicsUnit.Pixel);
                    }
                }
            }
            Image startImage = System.Drawing.Image.FromFile("../../p1.bmp");
            Image endImage = System.Drawing.Image.FromFile("../../p2.bmp");
            Rectangle rt_1 = new Rectangle((pw) * m_maze2.Start.y, (ph) * m_maze2.Start.x, pw, ph);
            Rectangle rt_2 = new Rectangle(0, 0, pw, ph);
            myg.DrawImage(startImage, rt_1, rt_2, GraphicsUnit.Pixel);
            Rectangle rt_3 = new Rectangle((pw) * m_maze2.End.y, (ph) * m_maze2.End.x, pw, ph);
            myg.DrawImage(endImage, rt_3, rt_2, GraphicsUnit.Pixel);
            //从image0上根据矩形rt1取出来的部分图像，贴到由rt2确定的矩形区域上

            //m_maze2.ShortPath();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(e.ToString());
            draw();
        }

   

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) flag = false;
            else if (e.Button == MouseButtons.Right) flag = true;
            mouseClick = e.Location;
            //draw();
        }
    }
}
