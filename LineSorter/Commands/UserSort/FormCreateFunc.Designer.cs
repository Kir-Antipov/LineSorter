﻿namespace LineSorter.Commands.UserSort
{
    partial class FormCreateFunc
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
            this.comboLang = new System.Windows.Forms.ComboBox();
            this.comboFunc = new System.Windows.Forms.ComboBox();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.labelLang = new System.Windows.Forms.Label();
            this.labelFunc = new System.Windows.Forms.Label();
            this.labelT = new System.Windows.Forms.Label();
            this.buttCancel = new System.Windows.Forms.Button();
            this.buttCompile = new System.Windows.Forms.Button();
            this.panelBack = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelEmpty = new System.Windows.Forms.Label();
            this.comboLines = new System.Windows.Forms.ComboBox();
            this.textAfter = new LineSorter.Commands.UserSort.LangBox();
            this.textBefore = new LineSorter.Commands.UserSort.LangBox();
            this.textMain = new LineSorter.Commands.UserSort.LangBox();
            this.SuspendLayout();
            // 
            // comboLang
            // 
            this.comboLang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLang.DisplayMember = "1";
            this.comboLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboLang.FormattingEnabled = true;
            this.comboLang.Items.AddRange(new object[] {
            "C#",
            "Visual Basic"});
            this.comboLang.Location = new System.Drawing.Point(101, 12);
            this.comboLang.Name = "comboLang";
            this.comboLang.Size = new System.Drawing.Size(399, 23);
            this.comboLang.TabIndex = 0;
            this.comboLang.SelectedIndexChanged += new System.EventHandler(this.RefreshSettings);
            // 
            // comboFunc
            // 
            this.comboFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFunc.DisplayMember = "1";
            this.comboFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFunc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboFunc.FormattingEnabled = true;
            this.comboFunc.Items.AddRange(new object[] {
            "Comparer (Func<T, T, int>)",
            "Full implementation (Func<IEnumerable<T>, IEnumerable<T>>)"});
            this.comboFunc.Location = new System.Drawing.Point(101, 41);
            this.comboFunc.Name = "comboFunc";
            this.comboFunc.Size = new System.Drawing.Size(399, 23);
            this.comboFunc.TabIndex = 1;
            this.comboFunc.SelectedIndexChanged += new System.EventHandler(this.RefreshSettings);
            // 
            // comboType
            // 
            this.comboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboType.DisplayMember = "1";
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "string",
            "Row"});
            this.comboType.Location = new System.Drawing.Point(101, 70);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(399, 23);
            this.comboType.TabIndex = 2;
            this.comboType.SelectedIndexChanged += new System.EventHandler(this.RefreshSettings);
            // 
            // labelLang
            // 
            this.labelLang.AutoSize = true;
            this.labelLang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelLang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelLang.Location = new System.Drawing.Point(12, 15);
            this.labelLang.Name = "labelLang";
            this.labelLang.Size = new System.Drawing.Size(62, 15);
            this.labelLang.TabIndex = 3;
            this.labelLang.Text = "Language:";
            // 
            // labelFunc
            // 
            this.labelFunc.AutoSize = true;
            this.labelFunc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelFunc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFunc.Location = new System.Drawing.Point(12, 44);
            this.labelFunc.Name = "labelFunc";
            this.labelFunc.Size = new System.Drawing.Size(83, 15);
            this.labelFunc.TabIndex = 4;
            this.labelFunc.Text = "Function type:";
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelT.Location = new System.Drawing.Point(12, 73);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(34, 15);
            this.labelT.TabIndex = 5;
            this.labelT.Text = "`T` is:";
            // 
            // buttCancel
            // 
            this.buttCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttCancel.Location = new System.Drawing.Point(379, 476);
            this.buttCancel.Name = "buttCancel";
            this.buttCancel.Size = new System.Drawing.Size(121, 23);
            this.buttCancel.TabIndex = 7;
            this.buttCancel.Text = "Cancel";
            this.buttCancel.UseVisualStyleBackColor = true;
            this.buttCancel.Click += new System.EventHandler(this.ButtCancel_Click);
            // 
            // buttCompile
            // 
            this.buttCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttCompile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttCompile.Location = new System.Drawing.Point(252, 476);
            this.buttCompile.Name = "buttCompile";
            this.buttCompile.Size = new System.Drawing.Size(121, 23);
            this.buttCompile.TabIndex = 6;
            this.buttCompile.Text = "Compile";
            this.buttCompile.UseVisualStyleBackColor = true;
            this.buttCompile.Click += new System.EventHandler(this.ButtCompile_Click);
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.Color.White;
            this.panelBack.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.panelBack.Location = new System.Drawing.Point(15, 172);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(485, 282);
            this.panelBack.TabIndex = 11;
            this.panelBack.Click += new System.EventHandler(this.PanelBack_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelName.Location = new System.Drawing.Point(12, 131);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(42, 15);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Name:";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textName.Location = new System.Drawing.Point(101, 128);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(399, 23);
            this.textName.TabIndex = 4;
            // 
            // labelEmpty
            // 
            this.labelEmpty.AutoSize = true;
            this.labelEmpty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelEmpty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelEmpty.Location = new System.Drawing.Point(12, 102);
            this.labelEmpty.Name = "labelEmpty";
            this.labelEmpty.Size = new System.Drawing.Size(74, 15);
            this.labelEmpty.TabIndex = 15;
            this.labelEmpty.Text = "Empty Lines:";
            // 
            // comboLines
            // 
            this.comboLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLines.DisplayMember = "1";
            this.comboLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLines.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboLines.FormattingEnabled = true;
            this.comboLines.Items.AddRange(new object[] {
            "Depends on global settings",
            "Remove",
            "As ordinary strings",
            "As mask"});
            this.comboLines.Location = new System.Drawing.Point(101, 99);
            this.comboLines.Name = "comboLines";
            this.comboLines.Size = new System.Drawing.Size(399, 23);
            this.comboLines.TabIndex = 3;
            // 
            // textAfter
            // 
            this.textAfter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAfter.AutoHeight = true;
            this.textAfter.BackColor = System.Drawing.Color.White;
            this.textAfter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textAfter.ClassColor = System.Drawing.Color.MediumTurquoise;
            this.textAfter.CommentColor = System.Drawing.Color.YellowGreen;
            this.textAfter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textAfter.Freezed = false;
            this.textAfter.Interval = 1000;
            this.textAfter.KeywordColor = System.Drawing.Color.SteelBlue;
            this.textAfter.Location = new System.Drawing.Point(15, 454);
            this.textAfter.Name = "textAfter";
            this.textAfter.NumericColor = System.Drawing.Color.SpringGreen;
            this.textAfter.ReadOnly = true;
            this.textAfter.Size = new System.Drawing.Size(485, 15);
            this.textAfter.StringColor = System.Drawing.Color.Firebrick;
            this.textAfter.TabIndex = 8;
            this.textAfter.TabSize = 4;
            this.textAfter.Text = "}";
            // 
            // textBefore
            // 
            this.textBefore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBefore.AutoHeight = true;
            this.textBefore.BackColor = System.Drawing.Color.White;
            this.textBefore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBefore.ClassColor = System.Drawing.Color.MediumTurquoise;
            this.textBefore.CommentColor = System.Drawing.Color.YellowGreen;
            this.textBefore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBefore.Freezed = false;
            this.textBefore.Interval = 1000;
            this.textBefore.KeywordColor = System.Drawing.Color.SteelBlue;
            this.textBefore.Location = new System.Drawing.Point(15, 157);
            this.textBefore.Name = "textBefore";
            this.textBefore.NumericColor = System.Drawing.Color.SpringGreen;
            this.textBefore.ReadOnly = true;
            this.textBefore.Size = new System.Drawing.Size(485, 15);
            this.textBefore.StringColor = System.Drawing.Color.Firebrick;
            this.textBefore.TabIndex = 7;
            this.textBefore.TabSize = 4;
            this.textBefore.Text = "public int Compare(string a, string b) {";
            // 
            // textMain
            // 
            this.textMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textMain.AutoHeight = false;
            this.textMain.BackColor = System.Drawing.Color.White;
            this.textMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textMain.ClassColor = System.Drawing.Color.LightSeaGreen;
            this.textMain.CommentColor = System.Drawing.Color.YellowGreen;
            this.textMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textMain.Freezed = false;
            this.textMain.Interval = 1000;
            this.textMain.KeywordColor = System.Drawing.Color.SteelBlue;
            this.textMain.Location = new System.Drawing.Point(35, 172);
            this.textMain.MaximumSize = new System.Drawing.Size(465, 300);
            this.textMain.MinimumSize = new System.Drawing.Size(465, 17);
            this.textMain.Name = "textMain";
            this.textMain.NumericColor = System.Drawing.Color.MediumSeaGreen;
            this.textMain.Size = new System.Drawing.Size(465, 282);
            this.textMain.StringColor = System.Drawing.Color.Firebrick;
            this.textMain.TabIndex = 5;
            this.textMain.TabSize = 4;
            this.textMain.Text = "// Your code here :)";
            this.textMain.TextChanged += new System.EventHandler(this.TextMain_TextChanged);
            this.textMain.Enter += new System.EventHandler(this.TextMain_Enter);
            this.textMain.Leave += new System.EventHandler(this.TextMain_Leave);
            // 
            // FormCreateFunc
            // 
            this.AcceptButton = this.buttCompile;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttCancel;
            this.ClientSize = new System.Drawing.Size(512, 511);
            this.Controls.Add(this.labelEmpty);
            this.Controls.Add(this.comboLines);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttCompile);
            this.Controls.Add(this.buttCancel);
            this.Controls.Add(this.textAfter);
            this.Controls.Add(this.textBefore);
            this.Controls.Add(this.textMain);
            this.Controls.Add(this.labelT);
            this.Controls.Add(this.labelFunc);
            this.Controls.Add(this.labelLang);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.comboFunc);
            this.Controls.Add(this.comboLang);
            this.Controls.Add(this.panelBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormCreateFunc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creating a custom sort";
            this.Load += new System.EventHandler(this.FormCreateFunc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboLang;
        private System.Windows.Forms.ComboBox comboFunc;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label labelLang;
        private System.Windows.Forms.Label labelFunc;
        private System.Windows.Forms.Label labelT;
        private LangBox textMain;
        private LangBox textBefore;
        private LangBox textAfter;
        private System.Windows.Forms.Button buttCancel;
        private System.Windows.Forms.Button buttCompile;
        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelEmpty;
        private System.Windows.Forms.ComboBox comboLines;
    }
}