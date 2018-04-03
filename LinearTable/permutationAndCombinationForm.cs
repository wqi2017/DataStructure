﻿using System;
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
            else Fun_Permute_Stack(m, n);
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
            richTextBox1.Text = Convert.ToString(m);
            m_strout = "";
            for (int i = 0; i < 100; i++) m_percom_temp[i] = 0;
            count = 0;
            if (radioButton1.Checked == true)
                for (int i = 1; i <= m; i++)
                    Fun_Permute_Recursion1(m, i, 0);
            else if (radioButton2.Checked == true)
                for (int i = 1; i <= m; i++)
                    Fun_Permute_Stack1(m, i);
                    richTextBox1.Text = m_strout;
        }
    }
}