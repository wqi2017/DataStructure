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
    public partial class Maze4 : Form
    {

        public Maze4()
        {
            InitializeComponent();
            myg = pictureBox1.CreateGraphics();
            string m_strout =init();
            m_maze4 = new CMaze(m_strout);
            //draw();
            mouseClick = new Point();
        }
        Graphics myg;
        CMaze m_maze4;
        Point mouseClick;
        bool flag = false;
        /*false left
         * true right*/
        private string init()
        {
           
            string m_strout = ""; 
            OpenFileDialog dlg = new OpenFileDialog();
            string str = "..\\..\\data\\";
            dlg.InitialDirectory = str;
            dlg.Filter = "数据文件（maze*.dat）|maze*.dat|文本文件（maze*.txt）|maze*.txt";
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
            Image image2 = System.Drawing.Image.FromFile("../../man.bmp");
            Image image3 = System.Drawing.Image.FromFile("../../p1.bmp");
            Image image4 = System.Drawing.Image.FromFile("../../p01.bmp");
            Image image5 = System.Drawing.Image.FromFile("../../p2.bmp");
            Image image6 = System.Drawing.Image.FromFile("../../p02.bmp");
            //image0对象的宽度和高度
            int pw = image0.Width;
            int ph = image0.Height;
            for (int i = 0; i < m_maze4.Rows+ 2; i++)
                {
                    for (int j = 0; j < m_maze4.Cols+ 2; j++)
                    {
                        Rectangle rt1 = new Rectangle(0, 0, pw, ph);
                        Rectangle rt2 = new Rectangle(i * (pw), j * (ph), pw, ph);
                        if (mouseClick.X >= rt2.X && mouseClick.X <= rt2.X + pw && mouseClick.Y >= rt2.Y && mouseClick.Y <= rt2.Y + ph)
                        {
                            moved t = new moved();
                            t.initmoved(j,i);
                            if (flag == false)
                                m_maze4.Start = t;
                            else if(m_maze4.Getelems(m_maze4.Start.x,m_maze4.Start.y)==m_maze4.Getelems(t.x,t.y)) m_maze4.End = t;
                        }
                    }
                }
            moved move = new moved();
            if (!(m_maze4.Start.x == m_maze4.End.x && m_maze4.Start.y == m_maze4.End.y)&&(m_maze4.Start.x!=0&&m_maze4.Start.y!=0&&m_maze4.End.x!=0&&m_maze4.End.y!=0))
            {
                m_maze4.ShortPath3();
                m_maze4.Setelems(m_maze4.Start.x, m_maze4.Start.y, 1);
                m_maze4.Setelems(m_maze4.End.x, m_maze4.End.y, 1);
                m_maze4.Start = move;
                m_maze4.End = move;
            }
            //定义矩形区域
            for(int i=0;i<m_maze4.Rows+2;i++)
            {
                for (int j=0;j<m_maze4.Cols+2;j++)
                {
                    Rectangle rt1 = new Rectangle(0, 0, pw, ph);
                    Rectangle rt2 = new Rectangle(j * (pw), i * (ph), pw, ph);
                    if(m_maze4.Getelems(i,j)==-2)
                    {
                        myg.DrawImage(image1, rt2, rt1, GraphicsUnit.Pixel);
                    }
                    else if(m_maze4.Getelems(i,j)==1)
                    {
                        myg.FillRectangle(new SolidBrush(Color.White), rt2);
                    }
                    else if(m_maze4.Getelems(i,j)==2)
                    {
                        myg.DrawImage(image2, rt2, rt1, GraphicsUnit.Pixel);
                    }
                    else if(m_maze4.Getelems(i,j)==3)
                    {
                        myg.DrawImage(image3, rt2, rt1, GraphicsUnit.Pixel);
                    }
                    else if(m_maze4.Getelems(i,j)==4)
                    {
                        myg.DrawImage(image4, rt2, rt1, GraphicsUnit.Pixel);
                    }
                    else if(m_maze4.Getelems(i,j)==5)
                    {
                        myg.DrawImage(image5, rt2, rt1, GraphicsUnit.Pixel);
                    }
                    else if(m_maze4.Getelems(i,j)==6)
                    {
                        myg.DrawImage(image6, rt2, rt1, GraphicsUnit.Pixel);
                    }
                }
            }
           
            //从image0上根据矩形rt1取出来的部分图像，贴到由rt2确定的矩形区域上

            //m_maze4.ShortPath();
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
