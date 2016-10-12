﻿namespace Ethereum.Wallet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTxCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdAccounts = new System.Windows.Forms.ComboBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgSendTransactions = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSend = new System.Windows.Forms.Button();
            this.cmbSendUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtSendTo = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTransactionHash = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSendTransactions)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(2, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 384);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTxCount);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.lblPending);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cmdAccounts);
            this.tabPage1.Controls.Add(this.lblBalance);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(620, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Default";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTxCount
            // 
            this.lblTxCount.AutoSize = true;
            this.lblTxCount.Location = new System.Drawing.Point(67, 89);
            this.lblTxCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTxCount.Name = "lblTxCount";
            this.lblTxCount.Size = new System.Drawing.Size(13, 13);
            this.lblTxCount.TabIndex = 6;
            this.lblTxCount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Tx Count";
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.Location = new System.Drawing.Point(67, 54);
            this.lblPending.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(65, 13);
            this.lblPending.TabIndex = 4;
            this.lblPending.Text = "0.00000 Eth";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Pending";
            // 
            // cmdAccounts
            // 
            this.cmdAccounts.FormattingEnabled = true;
            this.cmdAccounts.Location = new System.Drawing.Point(16, 15);
            this.cmdAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAccounts.Name = "cmdAccounts";
            this.cmdAccounts.Size = new System.Drawing.Size(300, 21);
            this.cmdAccounts.TabIndex = 2;
            this.cmdAccounts.SelectedIndexChanged += new System.EventHandler(this.cmdAccounts_SelectedIndexChanged);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(67, 72);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(65, 13);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "0.00000 Eth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgSendTransactions);
            this.tabPage2.Controls.Add(this.btnSend);
            this.tabPage2.Controls.Add(this.cmbSendUnit);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtAmount);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.txtSendTo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(620, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Send";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgSendTransactions
            // 
            this.dgSendTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSendTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSendTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgSendTransactions.Location = new System.Drawing.Point(4, 93);
            this.dgSendTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.dgSendTransactions.Name = "dgSendTransactions";
            this.dgSendTransactions.RowTemplate.Height = 24;
            this.dgSendTransactions.Size = new System.Drawing.Size(612, 225);
            this.dgSendTransactions.TabIndex = 8;
            this.dgSendTransactions.Resize += new System.EventHandler(this.dgSendTransactions_Resize);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSend.Location = new System.Drawing.Point(4, 323);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 32);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cmbSendUnit
            // 
            this.cmbSendUnit.FormattingEnabled = true;
            this.cmbSendUnit.Location = new System.Drawing.Point(205, 59);
            this.cmbSendUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSendUnit.Name = "cmbSendUnit";
            this.cmbSendUnit.Size = new System.Drawing.Size(92, 21);
            this.cmbSendUnit.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(59, 59);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(142, 20);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pay to";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(59, 37);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(318, 20);
            this.textBox2.TabIndex = 1;
            // 
            // txtSendTo
            // 
            this.txtSendTo.Location = new System.Drawing.Point(59, 14);
            this.txtSendTo.Margin = new System.Windows.Forms.Padding(2);
            this.txtSendTo.Name = "txtSendTo";
            this.txtSendTo.Size = new System.Drawing.Size(318, 20);
            this.txtSendTo.TabIndex = 0;
            this.txtSendTo.Text = "0xa8c98594d716fed32366411457cc0ff803fcd845";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(620, 358);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Receive";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.txtTransactionHash);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(620, 358);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Transaction";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 21);
            this.button1.TabIndex = 5;
            this.button1.Text = "View Transaction";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tx Hash";
            // 
            // txtTransactionHash
            // 
            this.txtTransactionHash.Location = new System.Drawing.Point(60, 11);
            this.txtTransactionHash.Margin = new System.Windows.Forms.Padding(2);
            this.txtTransactionHash.Name = "txtTransactionHash";
            this.txtTransactionHash.Size = new System.Drawing.Size(318, 20);
            this.txtTransactionHash.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(630, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.accountsToolStripMenuItem.Text = "&Accounts";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 410);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Ethereum Wallet";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSendTransactions)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cmbSendUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtSendTo;
        private System.Windows.Forms.ComboBox cmdAccounts;
        private System.Windows.Forms.DataGridView dgSendTransactions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTransactionHash;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTxCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

