namespace LinearTable
{
    partial class mainMenu
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.linearTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单链表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.排列组合ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearTableToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // linearTableToolStripMenuItem
            // 
            this.linearTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sequenceTableToolStripMenuItem,
            this.单链表ToolStripMenuItem,
            this.排列组合ToolStripMenuItem,
            this.计算器ToolStripMenuItem});
            this.linearTableToolStripMenuItem.Name = "linearTableToolStripMenuItem";
            this.linearTableToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.linearTableToolStripMenuItem.Text = "线性表";
            // 
            // sequenceTableToolStripMenuItem
            // 
            this.sequenceTableToolStripMenuItem.Name = "sequenceTableToolStripMenuItem";
            this.sequenceTableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sequenceTableToolStripMenuItem.Text = "顺序表";
            this.sequenceTableToolStripMenuItem.Click += new System.EventHandler(this.sequenceTableToolStripMenuItem_Click);
            // 
            // 单链表ToolStripMenuItem
            // 
            this.单链表ToolStripMenuItem.Name = "单链表ToolStripMenuItem";
            this.单链表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.单链表ToolStripMenuItem.Text = "单链表";
            this.单链表ToolStripMenuItem.Click += new System.EventHandler(this.单链表ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 603);
            this.panel1.TabIndex = 1;
            // 
            // 排列组合ToolStripMenuItem
            // 
            this.排列组合ToolStripMenuItem.Name = "排列组合ToolStripMenuItem";
            this.排列组合ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.排列组合ToolStripMenuItem.Text = "排列组合";
            this.排列组合ToolStripMenuItem.Click += new System.EventHandler(this.排列组合ToolStripMenuItem_Click);
            // 
            // 计算器ToolStripMenuItem
            // 
            this.计算器ToolStripMenuItem.Name = "计算器ToolStripMenuItem";
            this.计算器ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.计算器ToolStripMenuItem.Text = "计算器";
            this.计算器ToolStripMenuItem.Click += new System.EventHandler(this.计算器ToolStripMenuItem_Click);
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 628);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainMenu";
            this.Text = "DataStructure Application";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem linearTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceTableToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 单链表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排列组合ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算器ToolStripMenuItem;
    }
}

