namespace Tongfang.Simulator.Host
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMessage = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelContent = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textContent = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelContent = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnOpenWebBrowser = new System.Windows.Forms.Button();
            this.groupBoxState = new System.Windows.Forms.GroupBox();
            this.textState = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnShowError = new System.Windows.Forms.Button();
            this.btnCleanState = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textSend = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelLinkCount = new System.Windows.Forms.Label();
            this.linkLabelCount = new System.Windows.Forms.LinkLabel();
            this.btnSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxMessage.SuspendLayout();
            this.tableLayoutPanelContent.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBoxState.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxMessage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxState, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxMessage
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBoxMessage, 2);
            this.groupBoxMessage.Controls.Add(this.tableLayoutPanelContent);
            this.groupBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMessage.Location = new System.Drawing.Point(3, 115);
            this.groupBoxMessage.Name = "groupBoxMessage";
            this.groupBoxMessage.Size = new System.Drawing.Size(778, 330);
            this.groupBoxMessage.TabIndex = 1;
            this.groupBoxMessage.TabStop = false;
            this.groupBoxMessage.Text = "接收内容";
            // 
            // tableLayoutPanelContent
            // 
            this.tableLayoutPanelContent.ColumnCount = 1;
            this.tableLayoutPanelContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelContent.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanelContent.Controls.Add(this.flowLayoutPanel3, 0, 1);
            this.tableLayoutPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelContent.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanelContent.Name = "tableLayoutPanelContent";
            this.tableLayoutPanelContent.RowCount = 2;
            this.tableLayoutPanelContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelContent.Size = new System.Drawing.Size(772, 310);
            this.tableLayoutPanelContent.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textContent);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(766, 265);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文本";
            // 
            // textContent
            // 
            this.textContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textContent.Location = new System.Drawing.Point(3, 17);
            this.textContent.Name = "textContent";
            this.textContent.Size = new System.Drawing.Size(760, 245);
            this.textContent.TabIndex = 4;
            this.textContent.Text = "";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.labelContent);
            this.flowLayoutPanel3.Controls.Add(this.btnClean);
            this.flowLayoutPanel3.Controls.Add(this.btnOpenWebBrowser);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 274);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(766, 33);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // labelContent
            // 
            this.labelContent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(3, 8);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(47, 12);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "内容(0)";
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(56, 3);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(80, 23);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "清空内容";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnOpenWebBrowser
            // 
            this.btnOpenWebBrowser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpenWebBrowser.Location = new System.Drawing.Point(142, 3);
            this.btnOpenWebBrowser.Name = "btnOpenWebBrowser";
            this.btnOpenWebBrowser.Size = new System.Drawing.Size(140, 23);
            this.btnOpenWebBrowser.TabIndex = 6;
            this.btnOpenWebBrowser.Text = "用WebBrowser打开";
            this.btnOpenWebBrowser.UseVisualStyleBackColor = true;
            this.btnOpenWebBrowser.Click += new System.EventHandler(this.btnOpenWebBrowser_Click);
            // 
            // groupBoxState
            // 
            this.groupBoxState.Controls.Add(this.textState);
            this.groupBoxState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxState.Location = new System.Drawing.Point(3, 3);
            this.groupBoxState.Name = "groupBoxState";
            this.groupBoxState.Size = new System.Drawing.Size(621, 106);
            this.groupBoxState.TabIndex = 2;
            this.groupBoxState.TabStop = false;
            this.groupBoxState.Text = "状态信息";
            // 
            // textState
            // 
            this.textState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textState.Location = new System.Drawing.Point(3, 17);
            this.textState.Name = "textState";
            this.textState.Size = new System.Drawing.Size(615, 86);
            this.textState.TabIndex = 0;
            this.textState.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(630, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制按钮";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnStart);
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnShowError);
            this.flowLayoutPanel1.Controls.Add(this.btnCleanState);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(145, 86);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开启";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowError
            // 
            this.btnShowError.Location = new System.Drawing.Point(3, 61);
            this.btnShowError.Name = "btnShowError";
            this.btnShowError.Size = new System.Drawing.Size(75, 23);
            this.btnShowError.TabIndex = 2;
            this.btnShowError.Text = "显示异常";
            this.btnShowError.UseVisualStyleBackColor = true;
            this.btnShowError.Click += new System.EventHandler(this.btnShowError_Click);
            // 
            // btnCleanState
            // 
            this.btnCleanState.Location = new System.Drawing.Point(84, 61);
            this.btnCleanState.Name = "btnCleanState";
            this.btnCleanState.Size = new System.Drawing.Size(40, 23);
            this.btnCleanState.TabIndex = 4;
            this.btnCleanState.Text = "清空";
            this.btnCleanState.UseVisualStyleBackColor = true;
            this.btnCleanState.Click += new System.EventHandler(this.btnCleanState_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textSend);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 451);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 107);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送内容";
            // 
            // textSend
            // 
            this.textSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSend.Location = new System.Drawing.Point(3, 17);
            this.textSend.Name = "textSend";
            this.textSend.Size = new System.Drawing.Size(615, 87);
            this.textSend.TabIndex = 0;
            this.textSend.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelLinkCount);
            this.panel1.Controls.Add(this.linkLabelCount);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(630, 451);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 107);
            this.panel1.TabIndex = 5;
            // 
            // labelLinkCount
            // 
            this.labelLinkCount.AutoSize = true;
            this.labelLinkCount.Location = new System.Drawing.Point(50, 92);
            this.labelLinkCount.Name = "labelLinkCount";
            this.labelLinkCount.Size = new System.Drawing.Size(11, 12);
            this.labelLinkCount.TabIndex = 2;
            this.labelLinkCount.Text = "0";
            // 
            // linkLabelCount
            // 
            this.linkLabelCount.AutoSize = true;
            this.linkLabelCount.Location = new System.Drawing.Point(4, 92);
            this.linkLabelCount.Name = "linkLabelCount";
            this.linkLabelCount.Size = new System.Drawing.Size(53, 12);
            this.linkLabelCount.TabIndex = 1;
            this.linkLabelCount.TabStop = true;
            this.linkLabelCount.Text = "连接数：";
            this.linkLabelCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCount_LinkClicked);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(37, 49);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "SimulatorForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxMessage.ResumeLayout(false);
            this.tableLayoutPanelContent.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBoxState.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxMessage;
        private System.Windows.Forms.GroupBox groupBoxState;
        private System.Windows.Forms.RichTextBox textState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShowError;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox textSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.LinkLabel linkLabelCount;
        private System.Windows.Forms.Label labelLinkCount;
        private System.Windows.Forms.Button btnCleanState;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.Button btnOpenWebBrowser;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox textContent;
    }
}

