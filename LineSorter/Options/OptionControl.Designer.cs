namespace LineSorter.Options
{
    partial class OptionControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupAutoLoad = new System.Windows.Forms.GroupBox();
            this.checkLoadOnCreate = new System.Windows.Forms.CheckBox();
            this.checkLoadOnInit = new System.Windows.Forms.CheckBox();
            this.groupUserSort = new System.Windows.Forms.GroupBox();
            this.gridSorts = new System.Windows.Forms.DataGridView();
            this.ColumnGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttUse = new System.Windows.Forms.ToolStripMenuItem();
            this.buttDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupLines = new System.Windows.Forms.GroupBox();
            this.checkAsMask = new System.Windows.Forms.RadioButton();
            this.checkAsLine = new System.Windows.Forms.RadioButton();
            this.checkRemove = new System.Windows.Forms.RadioButton();
            this.buttDonate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupAutoLoad.SuspendLayout();
            this.groupUserSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSorts)).BeginInit();
            this.gridStrip.SuspendLayout();
            this.groupLines.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupAutoLoad
            // 
            this.groupAutoLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAutoLoad.Controls.Add(this.checkLoadOnCreate);
            this.groupAutoLoad.Controls.Add(this.checkLoadOnInit);
            this.groupAutoLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupAutoLoad.Location = new System.Drawing.Point(3, 136);
            this.groupAutoLoad.Name = "groupAutoLoad";
            this.groupAutoLoad.Size = new System.Drawing.Size(332, 79);
            this.groupAutoLoad.TabIndex = 5;
            this.groupAutoLoad.TabStop = false;
            this.groupAutoLoad.Text = "Автозагрузка";
            // 
            // checkLoadOnCreate
            // 
            this.checkLoadOnCreate.AutoSize = true;
            this.checkLoadOnCreate.Location = new System.Drawing.Point(6, 47);
            this.checkLoadOnCreate.Name = "checkLoadOnCreate";
            this.checkLoadOnCreate.Size = new System.Drawing.Size(332, 19);
            this.checkLoadOnCreate.TabIndex = 1;
            this.checkLoadOnCreate.Text = "Загружать пользовательские сортировки при создании";
            this.checkLoadOnCreate.UseVisualStyleBackColor = true;
            this.checkLoadOnCreate.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // checkLoadOnInit
            // 
            this.checkLoadOnInit.AutoSize = true;
            this.checkLoadOnInit.Location = new System.Drawing.Point(6, 22);
            this.checkLoadOnInit.Name = "checkLoadOnInit";
            this.checkLoadOnInit.Size = new System.Drawing.Size(323, 19);
            this.checkLoadOnInit.TabIndex = 0;
            this.checkLoadOnInit.Text = "Загружать пользовательские сортировки при запуске";
            this.checkLoadOnInit.UseVisualStyleBackColor = true;
            this.checkLoadOnInit.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // groupUserSort
            // 
            this.groupUserSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupUserSort.Controls.Add(this.gridSorts);
            this.groupUserSort.Location = new System.Drawing.Point(3, 221);
            this.groupUserSort.Name = "groupUserSort";
            this.groupUserSort.Size = new System.Drawing.Size(332, 64);
            this.groupUserSort.TabIndex = 6;
            this.groupUserSort.TabStop = false;
            this.groupUserSort.Text = "Пользовательские сортировки";
            // 
            // gridSorts
            // 
            this.gridSorts.AllowUserToAddRows = false;
            this.gridSorts.AllowUserToDeleteRows = false;
            this.gridSorts.AllowUserToResizeColumns = false;
            this.gridSorts.AllowUserToResizeRows = false;
            this.gridSorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSorts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSorts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridSorts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridSorts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSorts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSorts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnGuid,
            this.ColumnSort});
            this.gridSorts.ContextMenuStrip = this.gridStrip;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSorts.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSorts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSorts.EnableHeadersVisualStyles = false;
            this.gridSorts.GridColor = System.Drawing.SystemColors.Control;
            this.gridSorts.Location = new System.Drawing.Point(6, 19);
            this.gridSorts.MultiSelect = false;
            this.gridSorts.Name = "gridSorts";
            this.gridSorts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSorts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSorts.RowHeadersVisible = false;
            this.gridSorts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSorts.Size = new System.Drawing.Size(320, 36);
            this.gridSorts.TabIndex = 0;
            this.gridSorts.Leave += new System.EventHandler(this.GridSorts_Leave);
            this.gridSorts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridSorts_MouseDown);
            // 
            // ColumnGuid
            // 
            this.ColumnGuid.HeaderText = "Guid";
            this.ColumnGuid.Name = "ColumnGuid";
            this.ColumnGuid.ReadOnly = true;
            // 
            // ColumnSort
            // 
            this.ColumnSort.HeaderText = "Name";
            this.ColumnSort.Name = "ColumnSort";
            this.ColumnSort.ReadOnly = true;
            // 
            // gridStrip
            // 
            this.gridStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttUse,
            this.buttDelete});
            this.gridStrip.Name = "gridStrip";
            this.gridStrip.Size = new System.Drawing.Size(152, 48);
            this.gridStrip.Opening += new System.ComponentModel.CancelEventHandler(this.GridStrip_Opening);
            // 
            // buttUse
            // 
            this.buttUse.Name = "buttUse";
            this.buttUse.Size = new System.Drawing.Size(151, 22);
            this.buttUse.Text = "Использовать";
            this.buttUse.Click += new System.EventHandler(this.ButtUse_Click);
            // 
            // buttDelete
            // 
            this.buttDelete.Name = "buttDelete";
            this.buttDelete.Size = new System.Drawing.Size(151, 22);
            this.buttDelete.Text = "Удалить";
            this.buttDelete.Click += new System.EventHandler(this.ButtDelete_Click);
            // 
            // groupLines
            // 
            this.groupLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupLines.Controls.Add(this.checkAsMask);
            this.groupLines.Controls.Add(this.checkAsLine);
            this.groupLines.Controls.Add(this.checkRemove);
            this.groupLines.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupLines.Location = new System.Drawing.Point(3, 32);
            this.groupLines.Name = "groupLines";
            this.groupLines.Size = new System.Drawing.Size(332, 98);
            this.groupLines.TabIndex = 6;
            this.groupLines.TabStop = false;
            this.groupLines.Text = "Обработка пустых строк";
            // 
            // checkAsMask
            // 
            this.checkAsMask.AutoSize = true;
            this.checkAsMask.Location = new System.Drawing.Point(7, 73);
            this.checkAsMask.Name = "checkAsMask";
            this.checkAsMask.Size = new System.Drawing.Size(283, 19);
            this.checkAsMask.TabIndex = 2;
            this.checkAsMask.TabStop = true;
            this.checkAsMask.Text = "Использовать как маску (неподвижный якорь)";
            this.checkAsMask.UseVisualStyleBackColor = true;
            this.checkAsMask.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // checkAsLine
            // 
            this.checkAsLine.AutoSize = true;
            this.checkAsLine.Location = new System.Drawing.Point(7, 48);
            this.checkAsLine.Name = "checkAsLine";
            this.checkAsLine.Size = new System.Drawing.Size(221, 19);
            this.checkAsLine.TabIndex = 1;
            this.checkAsLine.TabStop = true;
            this.checkAsLine.Text = "Обрабатывать как обычные строки";
            this.checkAsLine.UseVisualStyleBackColor = true;
            this.checkAsLine.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // checkRemove
            // 
            this.checkRemove.AutoSize = true;
            this.checkRemove.Location = new System.Drawing.Point(7, 23);
            this.checkRemove.Name = "checkRemove";
            this.checkRemove.Size = new System.Drawing.Size(151, 19);
            this.checkRemove.TabIndex = 0;
            this.checkRemove.TabStop = true;
            this.checkRemove.Text = "Удалять пустые строки";
            this.checkRemove.UseVisualStyleBackColor = true;
            this.checkRemove.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // buttDonate
            // 
            this.buttDonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttDonate.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttDonate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttDonate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttDonate.Location = new System.Drawing.Point(252, 3);
            this.buttDonate.Name = "buttDonate";
            this.buttDonate.Size = new System.Drawing.Size(83, 23);
            this.buttDonate.TabIndex = 7;
            this.buttDonate.Text = "Donate";
            this.buttDonate.UseVisualStyleBackColor = false;
            this.buttDonate.Click += new System.EventHandler(this.ButtDonate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Help LineSorter become better!)";
            // 
            // OptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttDonate);
            this.Controls.Add(this.groupLines);
            this.Controls.Add(this.groupUserSort);
            this.Controls.Add(this.groupAutoLoad);
            this.Name = "OptionControl";
            this.Size = new System.Drawing.Size(338, 497);
            this.VisibleChanged += new System.EventHandler(this.OptionControl_VisibleChanged);
            this.groupAutoLoad.ResumeLayout(false);
            this.groupAutoLoad.PerformLayout();
            this.groupUserSort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSorts)).EndInit();
            this.gridStrip.ResumeLayout(false);
            this.groupLines.ResumeLayout(false);
            this.groupLines.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupAutoLoad;
        private System.Windows.Forms.CheckBox checkLoadOnCreate;
        private System.Windows.Forms.CheckBox checkLoadOnInit;
        private System.Windows.Forms.GroupBox groupUserSort;
        private System.Windows.Forms.DataGridView gridSorts;
        private System.Windows.Forms.ContextMenuStrip gridStrip;
        private System.Windows.Forms.ToolStripMenuItem buttUse;
        private System.Windows.Forms.ToolStripMenuItem buttDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSort;
        private System.Windows.Forms.GroupBox groupLines;
        private System.Windows.Forms.RadioButton checkAsMask;
        private System.Windows.Forms.RadioButton checkAsLine;
        private System.Windows.Forms.RadioButton checkRemove;
        private System.Windows.Forms.Button buttDonate;
        private System.Windows.Forms.Label label1;
    }
}
