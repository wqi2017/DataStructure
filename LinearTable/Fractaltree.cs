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
    public partial class Fractaltree : Form
    {
        Graphics myg;
        
        public Fractaltree()
        {
            InitializeComponent();
            myg = pictureBox1.CreateGraphics();
            //DrawTree(new Point(20, 20), 10);
        }

        private void Fractaltree_Load(object sender, EventArgs e)
        {
           
        }
        
        void DrawMainTree(Point m_point,int length)
        {
            Pen pen = new Pen(Color.Green, 2);
            
            Pen pen1 = new Pen(Color.Red, 2);
            Point m = new Point(m_point.X, m_point.Y - length);
            Point m1 = new Point(Convert.ToInt16(m.X - length * 0.5 * Math.Sqrt(2)),Convert.ToInt16(m.Y - length * 0.5 * Math.Sqrt(2)));
            Point m2 = new Point(Convert.ToInt16(m.X + length * 0.5 * Math.Sqrt(2)),Convert.ToInt16(m.Y - length * 0.5 * Math.Sqrt(2)));
            myg.DrawLine(pen1, m1, m);
            myg.DrawLine(pen1, m2, m);
            myg.DrawLine(pen, m, m_point); 
        }
        void DrawTree(Point m_point, int length,int heading)
        {
            Pen pen = new Pen(Color.Green, 2);

            Pen pen1 = new Pen(Color.Red, 2);
            if (heading == 1 || heading == 2)
            {
                Point m = new Point(m_point.X, m_point.Y - length);
                Point m1 = new Point(Convert.ToInt16(m.X - length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m.Y - length * 0.5 * Math.Sqrt(2)));
                Point m2 = new Point(Convert.ToInt16(m.X + length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m.Y - length * 0.5 * Math.Sqrt(2)));
                myg.DrawLine(pen1, m1, m);
                myg.DrawLine(pen1, m2, m);
                myg.DrawLine(pen, m, m_point);
            }
            else
            {
                Point m = new Point(m_point.X, m_point.Y + length);
                Point m1 = new Point(Convert.ToInt16(m.X - length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m.Y + length * 0.5 * Math.Sqrt(2)));
                Point m2 = new Point(Convert.ToInt16(m.X + length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m.Y + length * 0.5 * Math.Sqrt(2)));
                myg.DrawLine(pen1, m1, m);
                myg.DrawLine(pen1, m2, m);
                myg.DrawLine(pen, m, m_point);
            }
            if(heading==1||heading==3)
            {
                Point m = new Point(m_point.X - length, m_point.Y );
                Point m1 = new Point(Convert.ToInt16(m.X - length * 0.5 * Math.Sqrt(2) ), Convert.ToInt16(m.Y - length * 0.5 * Math.Sqrt(2)));
                Point m2 = new Point(Convert.ToInt16(m.X - length * 0.5 * Math.Sqrt(2) ), Convert.ToInt16(m.Y + length * 0.5 * Math.Sqrt(2)));
                myg.DrawLine(pen1, m1, m);
                myg.DrawLine(pen1, m2, m);
                myg.DrawLine(pen, m, m_point);
            }
            else
            {
                Point m = new Point(m_point.X + length, m_point.Y);
                Point m1 = new Point(Convert.ToInt16(m.X + length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m.Y - length * 0.5 * Math.Sqrt(2)));
                Point m2 = new Point(Convert.ToInt16(m.X + length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m.Y + length * 0.5 * Math.Sqrt(2)));
                myg.DrawLine(pen1, m1, m);
                myg.DrawLine(pen1, m2, m);
                myg.DrawLine(pen, m, m_point);
            }
        }
        struct m_struct
        {
            public Point m_point;
            public int length;
            public int heading;
            /*
             * 1  2
             * 3  4*/
            public m_struct(Point t,int len,int head)
            {
                this.m_point = t;
                this.length = len;
                this.heading = head;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Point start = new Point(500, 600);
            int init_length = 150;
            CQueue<m_struct> m_struct1 = new CQueue<m_struct>();
            m_struct m1=new m_struct(new Point(Convert.ToInt16(500-init_length*0.5*Math.Sqrt(2)),
                        Convert.ToInt16(600-init_length-init_length*0.5*Math.Sqrt(2))),Convert.ToInt16(init_length*0.5),1);
            m_struct m2 = new m_struct(new Point(Convert.ToInt16(500 + init_length * 0.5 * Math.Sqrt(2)),
                        Convert.ToInt16(600 - init_length - init_length * 0.5 * Math.Sqrt(2))), Convert.ToInt16(init_length * 0.5), 2);
            DrawMainTree(start, init_length); 
            //DrawTree(m1.m_point, m1.length, m1.heading);
            //kDrawTree(m2.m_point, m2.length, m2.heading);
            m_struct1.In(m1); m_struct1.In(m2);
            init_length = Convert.ToInt16(init_length * 0.5);
            while(init_length>2)
            {
                init_length = Convert.ToInt16(init_length * 0.5);
                CQueue<m_struct> m_queue_bak = new CQueue<m_struct>();
                while(!m_struct1.IsEmpty())
                {
                    m_struct m12 = m_struct1.Out();
                    m_struct m_1, m_2, m_3, m_4;
                    if(m12.heading==1||m12.heading==2)
                    {
                        m_1.heading = 1; m_2.heading = 2;
                        m_1.length = init_length; m_2.length = init_length;
                        m_1.m_point = new Point(Convert.ToInt16(m12.m_point.X - m12.length * 0.5 * Math.Sqrt(2)),Convert.ToInt16(m12.m_point.Y - m12.length - m12.length * 0.5 * Math.Sqrt(2)));
                        m_2.m_point = new Point(Convert.ToInt16(m12.m_point.X + m12.length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m12.m_point.Y - m12.length - m12.length * 0.5 * Math.Sqrt(2)));
                    }
                    else
                    {
                        m_1.heading = 3; m_2.heading = 4; 
                        m_1.length = init_length; m_2.length = init_length;
                        m_1.m_point = new Point(Convert.ToInt16(m12.m_point.X - m12.length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m12.m_point.Y + m12.length + m12.length * 0.5 * Math.Sqrt(2)));
                        m_2.m_point = new Point(Convert.ToInt16(m12.m_point.X + m12.length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m12.m_point.Y + m12.length + m12.length * 0.5 * Math.Sqrt(2)));
                    }
                    if(m12.heading==1||m12.heading==3)
                    {
                        m_3.heading = 1; m_4.heading = 3;
                        m_3.length = init_length; m_4.length = init_length;
                        m_3.m_point = new Point(Convert.ToInt16(m12.m_point.X - m12.length- m12.length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m12.m_point.Y - m12.length * 0.5 * Math.Sqrt(2)));
                        m_4.m_point = new Point(Convert.ToInt16(m12.m_point.X - m12.length- m12.length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m12.m_point.Y + m12.length * 0.5 * Math.Sqrt(2)));
                    }
                    else
                    {
                        m_3.heading = 2; m_4.heading = 4;
                        m_3.length = init_length; m_4.length = init_length;
                        m_3.m_point = new Point(Convert.ToInt16(m12.m_point.X + m12.length + m12.length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m12.m_point.Y - m12.length * 0.5 * Math.Sqrt(2)));
                        m_4.m_point = new Point(Convert.ToInt16(m12.m_point.X + m12.length + m12.length * 0.5 * Math.Sqrt(2)), Convert.ToInt16(m12.m_point.Y + m12.length * 0.5 * Math.Sqrt(2)));
                    }
                    DrawTree(m12.m_point,m12.length,m12.heading);
                    m_queue_bak.In(m_1);
                    m_queue_bak.In(m_2);
                    m_queue_bak.In(m_3);
                    m_queue_bak.In(m_4);

                }
                m_struct1 = m_queue_bak;
            }
        }
    }
}
