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
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(textBox1.Text);
            Calculator m_calculator = new Calculator(100);
            string strout = "";
            m_calculator.Run(str, out strout);
            richTextBox1.Text = strout;

        }
    }
}
