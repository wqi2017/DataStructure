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
            DrawTree(new Point(20, 20), 10);
        }

        private void Fractaltree_Load(object sender, EventArgs e)
        {
           
        }
        
        void DrawTree(Point m_point,int length)
        {
            Pen pen = new Pen(Color.Green, 2);
            Point m = new Point(m_point.X, m_point.Y - length);
            Pen pen1 = new Pen(Color.Red, 2);
            Point m1 = new Point(Convert.ToInt16(m.X - length * 0.5 * Math.Sqrt(2)),Convert.ToInt16(m.Y - length * 0.5 * Math.Sqrt(2)));
            Point m2 = new Point(Convert.ToInt16(m.X + length * 0.5 * Math.Sqrt(2)),Convert.ToInt16(m.Y - length * 0.5 * Math.Sqrt(2)));
            myg.DrawLine(pen1, m1, m);
            myg.DrawLine(pen1, m2, m);
            myg.DrawLine(pen, m, m_point); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DrawTree(new Point(500, 600), 100);
        }
    }
}
