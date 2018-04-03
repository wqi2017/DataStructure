using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinearTable
{
    public partial class SingleList : Form
    {
        private SingleListClass<int> m_SingleList;
        public SingleList()
        {
            InitializeComponent();
            m_SingleList = new SingleListClass<int>();
            DrawSingleList();
        }

        private void DrawSingleList()//画出单链表
        {
            //通过画刷进行填充
            Graphics myg = pictureBox1.CreateGraphics();
            Brush bkbrush = new SolidBrush(Color.White);
            myg.FillRectangle(bkbrush, 0, 0, 741,628);
            Color bkColor = Color.FromArgb(255, 255,215,0);
            Brush bkbrush1 = new SolidBrush(bkColor);
            int interval = 80;
            int dx = 60, dy = 50;
            int y = 20;
            int time = 0;
            bool direction = true;
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
            SingleListNodeClass<int> p = m_SingleList.Head;
            for (int i = 0; i <= m_SingleList.Length; i++)
            {
                int x = interval * time + 20;
                if (x > 740 - interval && direction == true)
                {
                    x -= interval;
                    y += interval;
                    direction = false;
                }
                else if (x < 20 && direction == false)
                {
                    x += interval;
                    y += interval;
                    direction = true;
                }
                if (direction == true) time += 1;
                else time -= 1;
                if (p == m_SingleList.Currrent)
                {
                    Brush t = new SolidBrush(Color.Pink);
                    myg.FillRectangle(t, (float)(x), (float)(y), dx, dy);//画填充矩形
                }
                else
                    myg.FillRectangle(bkbrush1, (float)(x), (float)(y), dx, dy);//画填充矩形
                //画箭头
                Pen penLine = new Pen(Color.Red, 1);
                penLine.CustomEndCap = lineCap;
                Point arrowp1 = new Point(0, 0);
                Point arrowp2 = new Point(0, 0);
                if (direction == true && i != 0)
                {
                    arrowp1 = new Point(x + dx - interval, y + dy / 2);
                    arrowp2 = new Point(x, y + dy / 2);
                }
                else if (direction == false)
                {
                    arrowp1 = new Point(x + interval, y + dy / 2);
                    arrowp2 = new Point(x + dx, y + dy / 2);
                }
                myg.DrawLine(penLine, arrowp1, arrowp2);
                Pen pen2 = new Pen(Color.Red, 1);
                if (direction == false && x + interval > 720)
                {
                    Point pp1 = new Point(x + interval, y - interval + dy / 2);
                    Point pp2 = new Point(x + interval, y + dy / 2);
                    myg.DrawLine(pen2, pp1, pp2);
                    pp2 = pp1;
                    pp1 = new Point(x + dx, y - interval + dy / 2);
                    myg.DrawLine(pen2, pp1, pp2);
                    time -= 1;
                }
                else if (direction == true && x <= 30 && i != 0)
                {
                    Point pp1 = new Point(x - interval + dx, y - interval + dy / 2);
                    Point pp2 = new Point(x - interval + dx, y + dy / 2);
                    myg.DrawLine(pen2, pp1, pp2);
                    pp2 = pp1;
                    pp1 = new Point(x, y - interval + dy / 2);
                    myg.DrawLine(pen2, pp1, pp2);
                    time +=1;
                }
                //画四周四条边
                Pen pen1 = new Pen(Color.Red, 1);
                Point p1 = new Point(x, y);
                Point p2 = new Point(x, y + dy);
                myg.DrawLine(pen1, p1, p2);
                p1 = p2;
                p2 = new Point(x + dx, y + dy);
                myg.DrawLine(pen1, p1, p2);
                p1 = p2;
                p2 = new Point(x + dx, y);
                myg.DrawLine(pen1, p1, p2);
                p1 = p2;
                p2 = new Point(x, y);
                myg.DrawLine(pen1, p1, p2);
                //显示字符串
                string str = Convert.ToString(p.Data);
                if (i == 0) str = "head";
                p = p.Next;
                Font font = new Font("Arial", 12);
                SolidBrush b1 = new SolidBrush(Color.Blue);
                StringFormat sf1 = new StringFormat();
                myg.DrawString(str, font, b1, x + 18, y + 15, sf1);


            }
            button11.Text = Convert.ToString(m_SingleList.Currrent.GetHashCode());
            button12.Text = Convert.ToString(m_SingleList.Currrent.Data);
            if (m_SingleList.Currrent.Next == null)
                button13.Text = "null";
            else
            button13.Text = Convert.ToString(m_SingleList.Currrent.Next.GetHashCode());
        }


        private void button8_Click(object sender, EventArgs e)//关闭本窗口
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int m_createno = Convert.ToInt16(textBox1.Text);
            int[] dt = new int[m_createno];
            Random ran = new Random();
            if (feibonaqi.Checked == true)
            {
                int a = 1; int b = 1;
                for (int i = 0; i < m_createno; i++)
                {
                    if (i % 2 == 0)
                    {
                        dt[i] = a;
                        a = a + b;
                    }
                    else
                    {
                        dt[i] = b;
                        b = a + b;
                    }
                }
            }
            else if (sushu.Checked == true)
            {
                int count = 2;
                for (int i = 0; i < m_createno; i++)
                {
                    dt[i] = count;

                    for (int j = 0; j < i; j++)
                    {
                        if (dt[i] % dt[j] == 0)
                        { i--; break; }
                    }
                    count++;
                }
            }

            else if (checkBox1.Checked == true)
            {
                for (int i = 0; i < m_createno; i++)
                {
                    dt[i] = ran.Next(m_createno) + 1;
                    for (int j = 0; j < i; j++)
                        if (dt[i] == dt[j])
                        {
                            i--; break;
                        }
                }
            }
            else
            {
                for (int i = 0; i < m_createno; i++)
                    dt[i] = i + 1;
            }
            if (m_createno <= 99 && m_createno >= 1)
            {
                if (radioButton1.Checked == true) //头插法
                    m_SingleList.CreateHead(dt, m_createno);
                else //尾插法
                    m_SingleList.CreateRear(dt, m_createno);
                DrawSingleList();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int m_date;
            if (m_SingleList.Length < 99)
            {
                m_date = Convert.ToInt16(textBox2.Text);
                if (radioButton4.Checked == true)
                    m_SingleList.InsertHead(m_date);
                else if (radioButton5.Checked == true)
                    m_SingleList.Insert(m_date, true);
                else if (radioButton3.Checked == true)
                    m_SingleList.Insert(m_date, false);
                else if (radioButton6.Checked == true)
                    m_SingleList.AppendRear(m_date);
                DrawSingleList();
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            m_SingleList.NextNode();
            DrawSingleList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            m_SingleList.Currrent = m_SingleList.Head;
            DrawSingleList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_SingleList.MakeEmpty();
            DrawSingleList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt16(textBox2.Text);
            SingleListNodeClass<int> t=new SingleListNodeClass<int>();
            t.Data = number;
            m_SingleList.Update(t);
            DrawSingleList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            m_SingleList.Delete();
            DrawSingleList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt16(textBox2.Text);
            SingleListNodeClass<int> p = m_SingleList.Head.Next;
            while(p.Next!=null)
            {
                if(p.Data==number)
                {
                    m_SingleList.Currrent = p;
                    break;
                }
                p = p.Next;
            }
            if (p.Next == null)
                MessageBox.Show("没有该数据");
            DrawSingleList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            m_SingleList.convers();
            DrawSingleList();
        }

        private void sortSingleList()
        {
            SingleListNodeClass<int> p = m_SingleList.Head.Next;
            while (p.Next != null)
            {
                SingleListNodeClass<int> q = p.Next;
                while (q != null)
                {
                    if (p.Data > q.Data)
                    {
                        int k = p.Data;
                        p.Data = q.Data;
                        q.Data = k;
                    }
                    q = q.Next;
                }
                p = p.Next;
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            button6_Click(sender,e);
            sortSingleList();
            DrawSingleList();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int min = Convert.ToInt16(textBox3.Text);
            int max = Convert.ToInt16(textBox4.Text);

            //通过画刷进行填充
            Graphics myg = pictureBox1.CreateGraphics();
            Brush bkbrush = new SolidBrush(Color.White);
            myg.FillRectangle(bkbrush, 0, 0, 741, 628);
            Color bkColor = Color.FromArgb(255, 255, 215, 0);
            Brush bkbrush1 = new SolidBrush(bkColor);
            int interval = 80;
            int dx = 60, dy = 50;
            int y = 20;
            int time = 0;
            bool direction = true;
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
            SingleListNodeClass<int> p = m_SingleList.Head;
            for (int i = 0; i <= m_SingleList.Length; i++)
            {
                int x = interval * time + 20;
                if (x > 740 - interval && direction == true)
                {
                    x -= interval;
                    y += interval;
                    direction = false;
                }
                else if (x < 20 && direction == false)
                {
                    x += interval;
                    y += interval;
                    direction = true;
                }
                if (direction == true) time += 1;
                else time -= 1;
                if (p.Data<=Math.Max(max,min)&&p.Data>=Math.Min(max,min))
                {
                    Brush t = new SolidBrush(Color.Pink);
                    myg.FillRectangle(t, (float)(x), (float)(y), dx, dy);//画填充矩形
                }
                else
                    myg.FillRectangle(bkbrush1, (float)(x), (float)(y), dx, dy);//画填充矩形
                //画箭头
                Pen penLine = new Pen(Color.Red, 1);
                penLine.CustomEndCap = lineCap;
                Point arrowp1 = new Point(0, 0);
                Point arrowp2 = new Point(0, 0);
                if (direction == true && i != 0)
                {
                    arrowp1 = new Point(x + dx - interval, y + dy / 2);
                    arrowp2 = new Point(x, y + dy / 2);
                }
                else if (direction == false)
                {
                    arrowp1 = new Point(x + interval, y + dy / 2);
                    arrowp2 = new Point(x + dx, y + dy / 2);
                }
                myg.DrawLine(penLine, arrowp1, arrowp2);
                Pen pen2 = new Pen(Color.Red, 1);
                if (direction == false && x + interval > 720)
                {
                    Point pp1 = new Point(x + interval, y - interval + dy / 2);
                    Point pp2 = new Point(x + interval, y + dy / 2);
                    myg.DrawLine(pen2, pp1, pp2);
                    pp2 = pp1;
                    pp1 = new Point(x + dx, y - interval + dy / 2);
                    myg.DrawLine(pen2, pp1, pp2);
                    time -= 1;
                }
                else if (direction == true && x <= 30 && i != 0)
                {
                    Point pp1 = new Point(x - interval + dx, y - interval + dy / 2);
                    Point pp2 = new Point(x - interval + dx, y + dy / 2);
                    myg.DrawLine(pen2, pp1, pp2);
                    pp2 = pp1;
                    pp1 = new Point(x, y - interval + dy / 2);
                    myg.DrawLine(pen2, pp1, pp2);
                    time += 1;
                }
                //画四周四条边
                Pen pen1 = new Pen(Color.Red, 1);
                Point p1 = new Point(x, y);
                Point p2 = new Point(x, y + dy);
                myg.DrawLine(pen1, p1, p2);
                p1 = p2;
                p2 = new Point(x + dx, y + dy);
                myg.DrawLine(pen1, p1, p2);
                p1 = p2;
                p2 = new Point(x + dx, y);
                myg.DrawLine(pen1, p1, p2);
                p1 = p2;
                p2 = new Point(x, y);
                myg.DrawLine(pen1, p1, p2);
                //显示字符串
                string str = Convert.ToString(p.Data);
                if (i == 0) str = "head";
                p = p.Next;
                Font font = new Font("Arial", 12);
                SolidBrush b1 = new SolidBrush(Color.Blue);
                StringFormat sf1 = new StringFormat();
                myg.DrawString(str, font, b1, x + 18, y + 15, sf1);


            }
            button11.Text = Convert.ToString(m_SingleList.Currrent.GetHashCode());
            button12.Text = Convert.ToString(m_SingleList.Currrent.Data);
            if (m_SingleList.Currrent.Next == null)
                button13.Text = "null";
            else
                button13.Text = Convert.ToString(m_SingleList.Currrent.Next.GetHashCode());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            m_SingleList.FirstNode();
            int min = Convert.ToInt16(textBox3.Text);
            int max = Convert.ToInt16(textBox4.Text);
            SingleListNodeClass<int> p = m_SingleList.Head;
            SingleListNodeClass<int> q = m_SingleList.Head;
            while(p.Next!=null)
            {
                if (p.Next.Data <= Math.Max(max, min) && p.Next.Data >= Math.Min(max, min))
                {
                    m_SingleList.DeleteNode(p.Next);
                    
                    continue;
                }
                p = p.Next;
                q = q.Next;
            }
            DrawSingleList();
        }
    }
}
