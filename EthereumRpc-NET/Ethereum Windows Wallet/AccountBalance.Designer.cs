namespace Ethereum.Wallet
{
    partial class AccountBalance
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
            this.btnShowBalance = new System.Windows.Forms.Button();
            this.btAccountList = new System.Windows.Forms.Button();
            this.lstboxAccountList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowBalance
            // 
            this.btnShowBalance.Location = new System.Drawing.Point(324, 136);
            this.btnShowBalance.Name = "btnShowBalance";
            this.btnShowBalance.Size = new System.Drawing.Size(87, 23);
            this.btnShowBalance.TabIndex = 1;
            this.btnShowBalance.Text = "Show Balance";
            this.btnShowBalance.UseVisualStyleBackColor = true;
            this.btnShowBalance.Click += new System.EventHandler(this.btnShowBalance_Click);
            // 
            // btAccountList
            // 
            this.btAccountList.Location = new System.Drawing.Point(40, 13);
            this.btAccountList.Name = "btAccountList";
            this.btAccountList.Size = new System.Drawing.Size(75, 23);
            this.btAccountList.TabIndex = 2;
            this.btAccountList.Text = "ListAccount";
            this.btAccountList.UseVisualStyleBackColor = true;
            this.btAccountList.Click += new System.EventHandler(this.btAccountList_Click);
            // 
            // lstboxAccountList
            // 
            this.lstboxAccountList.FormattingEnabled = true;
            this.lstboxAccountList.Location = new System.Drawing.Point(132, 13);
            this.lstboxAccountList.Name = "lstboxAccountList";
            this.lstboxAccountList.Size = new System.Drawing.Size(279, 95);
            this.lstboxAccountList.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AccountBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstboxAccountList);
            this.Controls.Add(this.btAccountList);
            this.Controls.Add(this.btnShowBalance);
            this.Name = "AccountBalance";
            this.Text = "AccountBalance";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnShowBalance;
        private System.Windows.Forms.Button btAccountList;
        private System.Windows.Forms.ListBox lstboxAccountList;
        private System.Windows.Forms.Button button1;
    }
}