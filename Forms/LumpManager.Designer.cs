namespace BSPLumpManager.Forms
{
    partial class LumpManager
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_open = new MetroFramework.Controls.MetroButton();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.style_manager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.textbox_filepath = new MetroFramework.Controls.MetroTextBox();
            this.button_create = new MetroFramework.Controls.MetroButton();
            this.check_all = new MetroFramework.Controls.MetroCheckBox();
            this.loading = new MetroFramework.Controls.MetroProgressSpinner();
            this.link_github = new MetroFramework.Controls.MetroLink();
            this.list_ents = new System.Windows.Forms.DataGridView();
            this.col_split = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_hid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_viewraw = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.style_manager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.list_ents)).BeginInit();
            this.SuspendLayout();
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(503, 63);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(114, 23);
            this.button_open.TabIndex = 0;
            this.button_open.Text = "Open Map";
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // open_file
            // 
            this.open_file.FileName = "Select BSP File";
            this.open_file.Filter = "Valve BSP File(.bsp)|*.bsp";
            // 
            // style_manager
            // 
            this.style_manager.Owner = this;
            this.style_manager.Style = MetroFramework.MetroColorStyle.Lime;
            this.style_manager.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // textbox_filepath
            // 
            this.textbox_filepath.Enabled = false;
            this.textbox_filepath.Location = new System.Drawing.Point(23, 63);
            this.textbox_filepath.Name = "textbox_filepath";
            this.textbox_filepath.Size = new System.Drawing.Size(474, 23);
            this.textbox_filepath.TabIndex = 1;
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(503, 395);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(114, 23);
            this.button_create.TabIndex = 2;
            this.button_create.Text = "Save Lump";
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // check_all
            // 
            this.check_all.AutoSize = true;
            this.check_all.Location = new System.Drawing.Point(391, 403);
            this.check_all.Name = "check_all";
            this.check_all.Size = new System.Drawing.Size(106, 15);
            this.check_all.TabIndex = 3;
            this.check_all.Text = "Toggle Selected";
            this.check_all.UseVisualStyleBackColor = true;
            this.check_all.CheckedChanged += new System.EventHandler(this.check_all_CheckedChanged);
            // 
            // loading
            // 
            this.loading.Location = new System.Drawing.Point(23, 395);
            this.loading.Maximum = 100;
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(23, 23);
            this.loading.Speed = 2F;
            this.loading.TabIndex = 2;
            this.loading.Value = 50;
            this.loading.Visible = false;
            // 
            // link_github
            // 
            this.link_github.FontWeight = MetroFramework.MetroLinkWeight.Light;
            this.link_github.Location = new System.Drawing.Point(532, 8);
            this.link_github.Name = "link_github";
            this.link_github.Size = new System.Drawing.Size(52, 16);
            this.link_github.TabIndex = 5;
            this.link_github.Text = "GitHub";
            this.link_github.Click += new System.EventHandler(this.link_github_Click);
            // 
            // list_ents
            // 
            this.list_ents.AllowUserToAddRows = false;
            this.list_ents.AllowUserToDeleteRows = false;
            this.list_ents.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.list_ents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.list_ents.BackgroundColor = System.Drawing.SystemColors.Control;
            this.list_ents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list_ents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_split,
            this.col_hid,
            this.col_name,
            this.col_viewraw});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.list_ents.DefaultCellStyle = dataGridViewCellStyle6;
            this.list_ents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.list_ents.GridColor = System.Drawing.Color.White;
            this.list_ents.Location = new System.Drawing.Point(23, 92);
            this.list_ents.MultiSelect = false;
            this.list_ents.Name = "list_ents";
            this.list_ents.ReadOnly = true;
            this.list_ents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.list_ents.RowHeadersVisible = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.list_ents.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.list_ents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.list_ents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.list_ents.ShowCellErrors = false;
            this.list_ents.ShowCellToolTips = false;
            this.list_ents.ShowEditingIcon = false;
            this.list_ents.ShowRowErrors = false;
            this.list_ents.Size = new System.Drawing.Size(594, 297);
            this.list_ents.TabIndex = 6;
            this.list_ents.Visible = false;
            // 
            // col_split
            // 
            this.col_split.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.col_split.DataPropertyName = "split";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.col_split.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_split.HeaderText = "Lump";
            this.col_split.Name = "col_split";
            this.col_split.ReadOnly = true;
            this.col_split.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_split.Width = 39;
            // 
            // col_hid
            // 
            this.col_hid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_hid.DataPropertyName = "hammerid";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.col_hid.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_hid.HeaderText = "Hammer ID";
            this.col_hid.Name = "col_hid";
            this.col_hid.ReadOnly = true;
            this.col_hid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_hid.Width = 85;
            // 
            // col_name
            // 
            this.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_name.DataPropertyName = "name";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.col_name.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_name.HeaderText = "Name";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            // 
            // col_viewraw
            // 
            this.col_viewraw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.col_viewraw.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_viewraw.HeaderText = "";
            this.col_viewraw.MinimumWidth = 100;
            this.col_viewraw.Name = "col_viewraw";
            this.col_viewraw.ReadOnly = true;
            this.col_viewraw.Text = "View Raw";
            this.col_viewraw.UseColumnTextForButtonValue = true;
            // 
            // LumpManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 441);
            this.Controls.Add(this.list_ents);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.link_github);
            this.Controls.Add(this.check_all);
            this.Controls.Add(this.textbox_filepath);
            this.Controls.Add(this.button_open);
            this.MaximizeBox = false;
            this.Name = "LumpManager";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Lump Manager";
            this.Load += new System.EventHandler(this.LumpManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.style_manager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.list_ents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton button_open;
        private System.Windows.Forms.OpenFileDialog open_file;
        private MetroFramework.Controls.MetroTextBox textbox_filepath;
        private MetroFramework.Controls.MetroButton button_create;
        private MetroFramework.Controls.MetroCheckBox check_all;
        private MetroFramework.Controls.MetroProgressSpinner loading;
        private MetroFramework.Controls.MetroLink link_github;
        protected MetroFramework.Components.MetroStyleManager style_manager;
        private System.Windows.Forms.DataGridView list_ents;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_split;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_hid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewButtonColumn col_viewraw;
    }
}