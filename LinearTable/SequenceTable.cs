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
    public partial class SequenceTable : Form
    {
        public SequenceTable()
        {
            InitializeComponent();
        }

        private SequenceTableClass<int> m_seqlist;

        private void button1_Click(object sender, EventArgs e)//创建顺序表
        {
            int m_createmaxno = Convert.ToInt16(textBox1.Text);
            int m_createno = Convert.ToInt16(textBox2.Text);
            int[] dt = new int[m_createno];
            if (radioButton2.Checked == true)
            {
                Random ran = new Random();
                int[] data = new int[m_createno];
                for (int i = 0; i < m_createno; i++)
                {
                    data[i] = ran.Next(m_createno) + 1;
                    for (int j = 0; j < i; j++)
                        if (data[i] == data[j])
                        {
                            i--; break;
                        }
                }
                for (int i = 0; i < m_createno; i++)
                {

                    dt[i] = data[i];
                }
            }
            else if (radioButton1.Checked == true)
            {
                for (int i = 0; i < m_createno; i++)
                    dt[i] = i + 1;

            }
            else if (radioButton7.Checked == true)
            {//feibonaqishulie
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
            else if (radioButton8.Checked == true)
            {//sushu
                int count=2;
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



            if (m_createno <= m_createmaxno && m_createno >= 1)
            {
                m_seqlist = new SequenceTableClass<int>(m_createmaxno, dt, m_createno);
                string str = m_seqlist.MyPrint();
                richTextBox1.Text = str;
            }
        }

        private void button2_Click(object sender, EventArgs e)//删除数据表
        {
            m_seqlist.MakeEmpty();
            string str = m_seqlist.MyPrint();
            richTextBox1.Text = str;
        }

        private void button3_Click(object sender, EventArgs e)//删除节点
        {
            int k;
            k = Convert.ToInt16(textBox3.Text);
 
            if (radioButton3.Checked == true)
                k = 1;
            else if (radioButton5.Checked == true)
                k = m_seqlist.DataSize + 1;
            if (m_seqlist.Delete(k))
            {
                string str = m_seqlist.MyPrint();
                richTextBox1.Text = str;
            }
            else
            {
                MessageBox.Show("插入的节点位置错误 !");
            }

        }

        private void button5_Click(object sender, EventArgs e)//在顺序表中插入数据
        {
            int k;
            k = Convert.ToInt16(textBox3.Text);
            int dt = Convert.ToInt16(textBox4.Text);
            if (radioButton3.Checked == true)
                k = 1;
            else if (radioButton5.Checked == true)
                k = m_seqlist.DataSize + 1;
            if (m_seqlist.Inset(k, dt))
            {
                string str = m_seqlist.MyPrint();
                richTextBox1.Text = str;
            }
            else
            {
                MessageBox.Show("插入的节点位置错误 !");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int k;
            k = Convert.ToInt16(textBox3.Text);
            int dt = Convert.ToInt16(textBox4.Text);
            if (radioButton3.Checked == true)
                k = 1;
            else if (radioButton5.Checked == true)
                k = m_seqlist.DataSize + 1;
            if (m_seqlist.Update(k, dt))
            {
                string str = m_seqlist.MyPrint();
                richTextBox1.Text = str;
            }
            else
            {
                MessageBox.Show("插入的节点位置错误 !");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sortSequenceTable()
        {
            for (int i = 0; i < m_seqlist.DataSize; i++)
            {
                int k = i;
                for (int j = i + 1; j < m_seqlist.DataSize; j++)
                {
                    if (m_seqlist.getData(i) > m_seqlist.getData(j))
                    {
                        m_seqlist.reverse(i, j);
                    }
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int dt = Convert.ToInt16(textBox4.Text);
            m_seqlist.Inset(1,dt);
            sortSequenceTable();
            string str = m_seqlist.MyPrint();
            richTextBox1.Text = str;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sortSequenceTable();
            string str = m_seqlist.MyPrint();
            richTextBox1.Text = str;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < m_seqlist.DataSize / 2 + 1; i++)
            {
                m_seqlist.reverse(i, m_seqlist.DataSize - i - 1);
            }
            string str = m_seqlist.MyPrint();
            richTextBox1.Text = str;
        }


    }
}
