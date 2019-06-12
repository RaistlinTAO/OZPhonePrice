namespace OZPhonePrice.Views
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdSearch = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvResult = new System.Windows.Forms.ListView();
            this.colIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdClose = new System.Windows.Forms.Label();
            this.prgrsCheck = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(632, 59);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 0;
            this.cmdSearch.Text = "&Check";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(29, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(255, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "OZ Phone Price Checker";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // lsvResult
            // 
            this.lsvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIndex,
            this.colName,
            this.colPrice,
            this.colSource});
            this.lsvResult.FullRowSelect = true;
            this.lsvResult.GridLines = true;
            this.lsvResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvResult.Location = new System.Drawing.Point(29, 97);
            this.lsvResult.Name = "lsvResult";
            this.lsvResult.Size = new System.Drawing.Size(678, 494);
            this.lsvResult.TabIndex = 3;
            this.lsvResult.UseCompatibleStateImageBehavior = false;
            this.lsvResult.View = System.Windows.Forms.View.Details;
            // 
            // colIndex
            // 
            this.colIndex.Text = "Index";
            // 
            // colName
            // 
            this.colName.Text = "Phone Name";
            this.colName.Width = 420;
            // 
            // colPrice
            // 
            this.colPrice.Text = "Phone Price";
            this.colPrice.Width = 100;
            // 
            // colSource
            // 
            this.colSource.Text = "Source";
            // 
            // cmdClose
            // 
            this.cmdClose.AutoSize = true;
            this.cmdClose.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmdClose.Location = new System.Drawing.Point(713, 9);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(14, 13);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "X";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // prgrsCheck
            // 
            this.prgrsCheck.Location = new System.Drawing.Point(29, 597);
            this.prgrsCheck.Name = "prgrsCheck";
            this.prgrsCheck.Size = new System.Drawing.Size(678, 10);
            this.prgrsCheck.TabIndex = 5;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(739, 631);
            this.Controls.Add(this.prgrsCheck);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lsvResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmdSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OZ Phone Price Checker";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvResult;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colSource;
        private System.Windows.Forms.Label cmdClose;
        private System.Windows.Forms.ProgressBar prgrsCheck;
    }
}