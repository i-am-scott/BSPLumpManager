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
            this.button_open = new MetroFramework.Controls.MetroButton();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.style_manager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.textbox_filepath = new MetroFramework.Controls.MetroTextBox();
            this.button_create = new MetroFramework.Controls.MetroButton();
            this.check_all = new MetroFramework.Controls.MetroCheckBox();
            this.loading = new MetroFramework.Controls.MetroProgressSpinner();
            this.link_github = new MetroFramework.Controls.MetroLink();
            this.list_ents = new System.Windows.Forms.ListView();
            this.col_checked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_hammerid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_viewmore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.style_manager)).BeginInit();
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
            this.list_ents.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.list_ents.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.list_ents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_ents.CheckBoxes = true;
            this.list_ents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_checked,
            this.col_hammerid,
            this.col_name,
            this.col_viewmore});
            this.list_ents.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.list_ents.HoverSelection = true;
            this.list_ents.Location = new System.Drawing.Point(23, 92);
            this.list_ents.MultiSelect = false;
            this.list_ents.Name = "list_ents";
            this.list_ents.ShowGroups = false;
            this.list_ents.ShowItemToolTips = true;
            this.list_ents.Size = new System.Drawing.Size(594, 297);
            this.list_ents.TabIndex = 6;
            this.list_ents.UseCompatibleStateImageBehavior = false;
            this.list_ents.View = System.Windows.Forms.View.Details;
            this.list_ents.Visible = false;
            this.list_ents.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.list_ents_ItemChecked);
            // 
            // col_checked
            // 
            this.col_checked.Text = "ID";
            this.col_checked.Width = 50;
            // 
            // col_name
            // 
            this.col_name.Text = "Class Name";
            this.col_name.Width = 110;
            // 
            // col_hammerid
            // 
            this.col_hammerid.Text = "Enitty ID";
            this.col_hammerid.Width = 57;
            // 
            // col_viewmore
            // 
            this.col_viewmore.Text = "View Raw";
            this.col_viewmore.Width = 360;
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
        private System.Windows.Forms.ListView list_ents;
        private System.Windows.Forms.ColumnHeader col_checked;
        private System.Windows.Forms.ColumnHeader col_name;
        private System.Windows.Forms.ColumnHeader col_hammerid;
        protected MetroFramework.Components.MetroStyleManager style_manager;
        private System.Windows.Forms.ColumnHeader col_viewmore;
    }
}