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
    public partial class permutationAndCombinationForm : Form
    {
        public permutationAndCombinationForm()
        {
            InitializeComponent();
        }

        int[] m_percom_temp = new int[100];
        string m_strout = "";
        int count = 0;
        string Getstr_percom_temp(int m)
        {
            string str = "";
            str+="(\t"+(++count).ToString()+"\t)\t\t【";
            for (int i = 0; i < m; i++)
                str +="\t"+ m_percom_temp[i].ToString() ;
            str += "\t】\r\n";
            return str;
        }
        string Getstr_percom_temp1(int m)
        {
            string str = "";
            str += "(\t" + (++count).ToString() + "\t)\t\t【";
            for (int i = 1; i <= m; i++)
                str += "\t" + m_percom_temp[i].ToString();
            str += "\t】\r\n";
            return str;
        }
        string Getstr_percom_temp2(int m,int k)
        {
            string str = "";
            str += "(\t" + (++count).ToString() + "\t)\t\t【";
            for (int i = 0; i <= k; i++)
                str += "\t" + m_percom_temp[i].ToString();
            str += "\t】\r\n";
            return str;
        }
        public void Fun_Permute_Recursion(int n, int m, int k)
        {
            for (int i = 1; i <= n; i++)
            {
                bool tag = false;
                for (int j = 0; j <= k - 1; j++)
                {
                    if (i == m_percom_temp[j])
                    { tag = true; break; }
                }
                if (tag == false)
                {
                    m_percom_temp[k] = i;
                    if (k < m-1)
                        Fun_Permute_Recursion(n, m, k + 1);
                    else
                        m_strout += Getstr_percom_temp(m);
                }
            }
        }

        public void Fun_Permute_Recursion1(int n, int m, int k)
        {
            for (int i = 1; i <= n; i++)
            {
                bool tag = false;
                for (int j = 0; j <= k - 1; j++)
                {
                    if (i<=m_percom_temp[j])
                    { tag = true; break; }
                }
                if (tag == false)
                {
                    m_percom_temp[k] = i;
                    if (k < m - 1)
                        Fun_Permute_Recursion1(n, m, k + 1);
                    else
                        m_strout += Getstr_percom_temp(m);
                }
            }
        }

        public void Fun_Permute_Stack(int n, int m)
        {
            int[] s_no = new int[m + 1]; //存放栈顶次数的栈
            bool[] s_tag = new bool[n + 1];
            //存放下标是否在栈中的标记
            int top = 0;
            //第一个进栈
            top++;
            m_percom_temp[top] = 1;
            s_no[top] = 1;
            s_tag[1] = true;//在栈中
            //rTB_strout.Text = "";
            //栈不空时循环
            while (top > 0)
            {
                if (s_no[top] == 1) //查看栈顶标记
                {
                    s_no[top] = 2; //修改栈顶标记                    
                    if (top < m) //继续进栈
                    {
                        for (int i = 1; i <= n; i++)
                        {
                            if (s_tag[i] == false)
                            {
                                top++;
                                m_percom_temp[top] = i;
                                s_no[top] = 1;
                                s_tag[i] = true;//在栈中
                                break;
                            }
                        }
                    }
                    else
                        m_strout += Getstr_percom_temp1(m);
                }
                else if (s_no[top] == 2) //查看栈顶标记
                {                    
                    s_tag[m_percom_temp[top]] = false;//不在栈中了
                    top--; //出栈
                    //下一个进栈
                    for (int i = m_percom_temp[top + 1]+1; i <= n; i++)
                    {
                        if (s_tag[i] == false)
                        {
                                top++;
                                m_percom_temp[top] = i;
                                s_no[top] = 1;
                                s_tag[i] = true;//在栈中
                                break;
                        }
                    }
                }


            }
        }

        public void Fun_Permute_Stack1(int n, int m)
        {
            int[] s_no = new int[m + 1]; //存放栈顶次数的栈
            bool[] s_tag = new bool[n + 1];
            //存放下标是否在栈中的标记
            int top = 0;
            //第一个进栈
            top++;
            m_percom_temp[top] = 1;
            s_no[top] = 1;
            s_tag[1] = true;//在栈中
            //rTB_strout.Text = "";
            //栈不空时循环
            while (top > 0)
            {
                if (s_no[top] == 1) //查看栈顶标记
                {
                    s_no[top] = 2; //修改栈顶标记                    
                    if (top < m) //继续进栈
                    {
                        for (int i = m_percom_temp[top]+1; i <= n; i++)
                        {
                            if (s_tag[i] == false)
                            {
                                top++;
                                m_percom_temp[top] = i;
                                s_no[top] = 1;
                                s_tag[i] = true;//在栈中
                                break;
                            }
                        }
                    }
                    else
                        m_strout += Getstr_percom_temp1(m);
                }
                else if (s_no[top] == 2) //查看栈顶标记
                {
                    s_tag[m_percom_temp[top]] = false;//不在栈中了
                    top--; //出栈
                    //下一个进栈
                    for (int i = m_percom_temp[top + 1] + 1; i <= n; i++)
                    {
                        if (s_tag[i] == false)
                        {
                            top++;
                            m_percom_temp[top] = i;
                            s_no[top] = 1;
                            s_tag[i] = true;//在栈中
                            break;
                        }
                    }
                }


            }
        }

     
        public void Fun_Permute_Queue(int n, int m)
        {
            CQueue<int> m_cqueue = new CQueue<int>();
            int[] zijishulie = new int[n];
            for (int i = 0; i < n; i++) zijishulie[i] = i + 1;
            int i1 = 0;
            while(i1<n)
            {
                while(m_cqueue.Rear()-m_cqueue.Front()<m&&i1<n)
                {
                    m_cqueue.In(zijishulie[i1]);
                    i1++;
                }
                for (int j=0;j<m;j++)
                {
                    int[]k1=new int[m];
                    for (int i = 0; i < m; i++)
                        k1[i] = i1 - m + i + 1;
                    int count = 0;
                    int[,] k2 = new int[1000, 10];
                    for (int i = 0; i < m; i++)
                        k2[count, i] = i1 - m + i + 1;
                    for (int j1 = j + 1; j1 < m; j1++)
                    {
                        for (int j2 = 0; j2 <= count; j2++)
                        {
                            int count1 = 0;
                            int[] k3 = new int[10];
                            for (int i12 = 0; i12 < m; i12++)
                                k3[i12] = k2[j2, i12];
                                swap(k3, j, j1);
                                for (int i13 = 0; i13 < m; i13++)
                                    k2[count1++, i13] = k3[i13];
                                    for (int i = 0; i < m; i++) m_strout += Convert.ToString(k3[i]);
                            m_strout += "\r\n";
                            count = count1;                            
                        }
                                               
                    }
                }
                m_cqueue.Out();
            }


        }
        public void swap(int []k,int m,int n)
        {
            int k1 = k[m];
            k[m] = k[n];
            k[n] =k1;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int m = Convert.ToInt32(textBox1.Text);
            int n = Convert.ToInt32(textBox2.Text);
            m_strout = "";
            for (int i = 0; i < 100; i++) 
                m_percom_temp[i] = 0;
            count = 0;
            if (radioButton1.Checked == true)
                Fun_Permute_Recursion(m, n, 0);
            else if (radioButton2.Checked == true)
                Fun_Permute_Stack(m, n);
            else if (radioButton3.Checked == true)
                Fun_Permute_Queue(m, n );
            richTextBox1.Text = m_strout;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int m = Convert.ToInt32(textBox1.Text);
            int n = Convert.ToInt32(textBox2.Text);
            m_strout = "";
            for (int i = 0; i < 100; i++) m_percom_temp[i] = 0;
            count = 0;
            if (radioButton1.Checked == true)
                Fun_Permute_Recursion1(m, n, 0);
            else Fun_Permute_Stack1(m, n);
            richTextBox1.Text = m_strout;
        }


       
        private void button3_Click(object sender, EventArgs e)
        {
            int m = Convert.ToInt32(textBox1.Text);
            
            m_strout = "";
            for (int i = 0; i < 100; i++) m_percom_temp[i] = 0;
            count = 0;
            if (radioButton1.Checked == true)
                for (int i = 1; i <= m; i++)
                    Fun_Permute_Recursion1(m, i, 0);
            else if (radioButton2.Checked == true)
                for (int i = 1; i <= m; i++)
                    Fun_Permute_Stack1(m, i);
            else if (radioButton3.Checked == true)
                for (int i = 1; i < m; i++)
                    Fun_Permute_Queue(m,i);
                    richTextBox1.Text = m_strout;
        }
        
        struct m_class
        {
            public int number;
            public int label;
        }
        m_class[] number = new m_class[30];
        public void Fun_Permute_Recursion2(int n, int m, int k,int classroom1,int classroom2)
        {
            for (int i = 1; i <= n; i++)
            {
                bool tag = false;
                for (int j = 0; j <= k - 1; j++)
                {
                    if (i <= m_percom_temp[j])
                    { tag = true; break; }
                }
                if (tag == false)
                {
                    m_percom_temp[k] = i;
                    int count1 = 0;
                    for (int j1 = 0; j1<= k;j1 ++)
                        count1 += number[m_percom_temp[j1]-1].number;
                    int count2 = 0;
                    for (int j2=0;j2<m;j2++)
                        count2+=number[j2].number;
                    count2 -= count1;
                    if (k<m-1)
                        Fun_Permute_Recursion2(n, m, k + 1, classroom1,classroom2);
                    if(count1<=classroom1&&count2<=classroom2)
                        m_strout += Getstr_percom_temp2(m,k);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int classroom1 = Convert.ToInt16(textBox3.Text);
            int classroom2 = Convert.ToInt16(textBox4.Text);
            m_strout = "";
            for (int i = 0; i < 100; i++) m_percom_temp[i] = 0;
            count = 0;
            for (int i = 0; i < 30; i++) number[i] = new m_class();
            for (int i = 0; i < textBox5.Lines.Length; i++)
            {
                number[i].number = Convert.ToInt16(textBox5.Lines[i]);
                number[i].label = i + 1;
            }
            int classnumber = textBox5.Lines.Length;
            Fun_Permute_Recursion2(classnumber, classnumber, 0, classroom1,classroom2);
            richTextBox1.Text = m_strout;
        }
    }
}
