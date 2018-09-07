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
            this.gridStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttUse = new System.Windows.Forms.ToolStripMenuItem();
            this.buttDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupAutoLoad.SuspendLayout();
            this.groupUserSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSorts)).BeginInit();
            this.gridStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupAutoLoad
            // 
            this.groupAutoLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAutoLoad.Controls.Add(this.checkLoadOnCreate);
            this.groupAutoLoad.Controls.Add(this.checkLoadOnInit);
            this.groupAutoLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupAutoLoad.Location = new System.Drawing.Point(3, 0);
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
            this.checkLoadOnCreate.CheckedChanged += new System.EventHandler(this.CheckLoadOnCreate_CheckedChanged);
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
            this.checkLoadOnInit.CheckedChanged += new System.EventHandler(this.CheckLoadOnInit_CheckedChanged);
            // 
            // groupUserSort
            // 
            this.groupUserSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupUserSort.Controls.Add(this.gridSorts);
            this.groupUserSort.Location = new System.Drawing.Point(3, 82);
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
            // OptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.ResumeLayout(false);

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
    }
}
