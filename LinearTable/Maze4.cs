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
{   public class CMaze4
    {   
        private int rows, cols;
        private int[,] elems;
        private moved start, end;
        
        private CQueue<sqtype> sq;
        static moved[] move = new moved[8];
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }
        
        public moved Start
        {
            set
            {
                start = value;
            }
            get
            {
                return start;
            }
        }
        public moved End
        {
            set
            {
                end = value;
            }
            get
            {
                return end;
            }
        }
        public int GetIntData(string strdata, int k, out int outk)
        {
            int len = strdata.Length;
            int ks = k, data;
            string str;
            while ((ks < len) && ((strdata[ks] < '0') || (strdata[ks] > '9')))
                ks++;
            str = "";
            while ((ks < len) && ((strdata[ks] >= '0') && (strdata[ks] <= '9')))
                str = str + strdata[ks++];
            if (str != "")
                data = Convert.ToInt32(str);
            else
                data = 0;
            outk = ks;
            return (data);
        }
        public CMaze4(string strmazedata,bool flag=false)
        {
            int i,j,dd,know;
            know = 0;
            if (strmazedata == "")
            {   rows = cols = 0;   return;  }
            rows = GetIntData(strmazedata, know, out know);
            cols = GetIntData(strmazedata, know, out know);
            if (flag == true)
            {
                start.x = GetIntData(strmazedata, know, out know);
                start.y = GetIntData(strmazedata, know, out know);
                end.x = GetIntData(strmazedata, know, out know);
                end.y = GetIntData(strmazedata, know, out know);
            }
            elems = new int[(rows + 4) , (cols + 4)];
            for(i=0;i<rows+4;i++)
            {
                for (j=0;j<cols+4;j++)
                {
                    if (i == 0 || i == rows + 3 || j == 0 || j == cols + 3)
                    {
                        elems[i, j] = 1;
                    }
                    else if(i==1||i==rows+2||j==1||j==cols+2)
                    {
                        elems[i, j] = 0;
                    }
                    else
                    {
                        elems[i, j] = GetIntData(strmazedata, know,out know);
                    }
                }
            }
        }

        
        public int Getelems(int row,int col)
        {
            return elems[row, col];
        }
        
        public void Setelems(int row,int col,int num)
        {
            elems[row,col]=num;
        }
        public string ShortPath()//最短路径
        {
            move[0].x = 0; move[0].y = +1;
            move[1].x = +1; move[1].y = +1;
            move[2].x = +1; move[2].y = 0;
            move[3].x = +1; move[3].y = -1;
            move[4].x = 0; move[4].y = -1;
            move[5].x = -1; move[5].y = -1;
            move[6].x = -1; move[6].y = 0;
            move[7].x = -1; move[7].y = +1;//初始化位置坐标增量
            sq = new CQueue<sqtype>();//创建队列
            if (rows == 0 || cols == 0)
                return "";
            sqtype temp = new sqtype();
            temp.x = temp.y = 1; temp.pre = 0; sq.In(temp); Setelems(1, 1, -1);//起点进队         
            while (!sq.IsEmpty())//队不空时循环
            {
                temp = sq.Getfront(); int x = temp.x; int y = temp.y;//取队头
                for (int k = 0; k < 8; k+=2)//查找八个方向
                {
                    int i = x + move[k].x; int j = y + move[k].y;
                    if (Getelems(i, j) == 0)//路通
                    {
                        temp.x = i;
                        temp.y = j;
                        temp.pre = sq.Front() + 1;//前一个结点
                        sq.In(temp);//进队
                        Setelems(i, j, -1);//走过的设置为-1

                    }
                    if (i == rows && j == cols)
                    {

                        int j1 = sq.Rear();
                        int len = 0;
                        for (int i1 = sq.Rear(); i1 >= 1; i1--)
                        {
                            temp = sq.Getdata(i1);
                            if (i1 == j1)
                            {
                                Setelems(temp.x, temp.y, -1);
                                j1 = temp.pre;
                                len++;
                            }
                            else
                                Setelems(temp.x, temp.y, 0);
                        }
                        return "";

                    }
                }
                sq.Out();//出队
            }
            return "";
        }
        public string ShortPath2()//最短路径
        {
            for (int i = 0; i < Rows + 4; i++)
            {
                for (int j = 0; j < Cols + 4; j++)
                    if (Getelems(i, j) == -1) Setelems(i, j, 0);
            }
            move[0].x = 0; move[0].y = +1;
            move[1].x = +1; move[1].y = +1;
            move[2].x = +1; move[2].y = 0;
            move[3].x = +1; move[3].y = -1;
            move[4].x = 0; move[4].y = -1;
            move[5].x = -1; move[5].y = -1;
            move[6].x = -1; move[6].y = 0;
            move[7].x = -1; move[7].y = +1;//初始化位置坐标增量
            sq = new CQueue<sqtype>();//创建队列
            if (rows == 0 || cols == 0)
                return "";
            sqtype temp = new sqtype();
            temp.x = start.x; temp.y = start.y;
            Setelems(end.x, end.y, 0);
            sq.In(temp); Setelems(temp.x, temp.y, -1);//起点进队         
            while (!sq.IsEmpty())//队不空时循环
            {
                temp = sq.Getfront(); int x = temp.x; int y = temp.y;//取队头
                for (int k = 0; k < 8; k += 2)//查找八个方向
                {
                    int i = x + move[k].x; int j = y + move[k].y;
                    if (Getelems(i, j) == 0)//路通
                    {
                        temp.x = i;
                        temp.y = j;
                        temp.pre = sq.Front() + 1;//前一个结点
                        sq.In(temp);//进队
                        Setelems(i, j, -1);//走过的设置为-1

                    }
                    if (i == end.x && j == end.y)
                    {

                        int j1 = sq.Rear();
                        int len = 0;
                        for (int i1 = sq.Rear(); i1 >= 1; i1--)
                        {
                            temp = sq.Getdata(i1);
                            if (i1 == j1)
                            {
                                Setelems(temp.x, temp.y, -1);
                                j1 = temp.pre;
                                len++;
                            }
                            else
                                Setelems(temp.x, temp.y, 0);
                        }
                        return "";// PrintMazeQueue();

                    }
                }
                sq.Out();//出队
            }
            return "";
        }

    }
    public partial class Maze4 : Form
    {

        public Maze4()
        {
            InitializeComponent();
            myg = pictureBox1.CreateGraphics();
            string m_strout =init();
            m_maze4 = new CMaze4(m_strout);
            //draw();
            mouseClick = new Point();
        }
        Graphics myg;
        CMaze4 m_maze4;
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
            for (int i = 0; i < m_maze4.Rows+ 4; i++)
                {
                    for (int j = 0; j < m_maze4.Cols+ 4; j++)
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
                m_maze4.ShortPath2();
                m_maze4.Setelems(m_maze4.Start.x, m_maze4.Start.y, 0);
                m_maze4.Setelems(m_maze4.End.x, m_maze4.End.y, 0);
                m_maze4.Start = move;
                m_maze4.End = move;
            }
            //定义矩形区域
            for(int i=0;i<m_maze4.Rows+4;i++)
            {
                for (int j=0;j<m_maze4.Cols+4;j++)
                {
                    Rectangle rt1 = new Rectangle(0, 0, pw, ph);
                    Rectangle rt2 = new Rectangle(j * (pw), i * (ph), pw, ph);
                    if(m_maze4.Getelems(i,j)==-1)
                    {
                        myg.DrawImage(image1, rt2, rt1, GraphicsUnit.Pixel);
                    }
                    else if(m_maze4.Getelems(i,j)==0)
                    {
                        myg.FillRectangle(new SolidBrush(Color.White), rt2);
                    }
                    else if(m_maze4.Getelems(i,j)==1)
                    {
                        myg.DrawImage(image0, rt2, rt1, GraphicsUnit.Pixel);
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
