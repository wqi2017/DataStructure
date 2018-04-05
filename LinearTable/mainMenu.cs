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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
         
      
        }

        private void Control_Add(Form form)//切换窗体
        {
            panel1.Controls.Clear();    //移除所有控件  
            form.TopLevel = false;      //设置为非顶级窗体  
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //设置窗体为非边框样式  
            form.Dock = System.Windows.Forms.DockStyle.Fill;                  //设置样式是否填充整个panel  
            panel1.Controls.Add(form);        //添加窗体  
            form.Show();                      //窗体运行  
        }   
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sequenceTableToolStripMenuItem_Click(object sender, EventArgs e)//顺序表
        {
            SequenceTable m_SequenceTable= new SequenceTable();
            Control_Add(m_SequenceTable);
        }

        private void 单链表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleList m_SingleList = new SingleList();
            Control_Add(m_SingleList);
        }

        private void 排列组合ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            permutationAndCombinationForm m_permutationAndCombinationForm = new permutationAndCombinationForm();
            Control_Add(m_permutationAndCombinationForm);
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculatorForm m_CalculatorForm = new CalculatorForm();
            Control_Add(m_CalculatorForm);
        }

        private void 分形树ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fractaltree m_fractaltree = new Fractaltree();
            Control_Add(m_fractaltree);
        }

        private void 迷宫1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Maze1 m_maze1 = new Maze1();
            Control_Add(m_maze1);
        }

      
    }
}
