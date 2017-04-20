namespace BSPLumpManager
{
    partial class MainWindow
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
            this.col_checked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_hammerid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ent_list = new System.Windows.Forms.ListView();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.textbox_filepath = new System.Windows.Forms.TextBox();
            this.button_open = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.check_all = new System.Windows.Forms.CheckBox();
            this.button_create = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // col_checked
            // 
            this.col_checked.Text = "ID";
            this.col_checked.Width = 38;
            // 
            // col_hammerid
            // 
            this.col_hammerid.Text = "Hammer ID";
            this.col_hammerid.Width = 87;
            // 
            // col_name
            // 
            this.col_name.Text = "Name";
            this.col_name.Width = 246;
            // 
            // ent_list
            // 
            this.ent_list.CheckBoxes = true;
            this.ent_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_checked,
            this.col_hammerid,
            this.col_name});
            this.ent_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ent_list.Location = new System.Drawing.Point(0, 0);
            this.ent_list.Name = "ent_list";
            this.ent_list.Size = new System.Drawing.Size(384, 502);
            this.ent_list.TabIndex = 0;
            this.ent_list.UseCompatibleStateImageBehavior = false;
            this.ent_list.View = System.Windows.Forms.View.Details;
            // 
            // open_file
            // 
            this.open_file.FileName = "Select BSP File";
            this.open_file.Filter = "Valve BSP File(.bsp)|*.bsp";
            // 
            // textbox_filepath
            // 
            this.textbox_filepath.Dock = System.Windows.Forms.DockStyle.Top;
            this.textbox_filepath.Location = new System.Drawing.Point(0, 0);
            this.textbox_filepath.Name = "textbox_filepath";
            this.textbox_filepath.ReadOnly = true;
            this.textbox_filepath.Size = new System.Drawing.Size(384, 20);
            this.textbox_filepath.TabIndex = 1;
            // 
            // button_open
            // 
            this.button_open.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_open.Location = new System.Drawing.Point(220, 20);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(164, 28);
            this.button_open.TabIndex = 2;
            this.button_open.Text = "Open Map";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_create);
            this.splitContainer1.Panel1.Controls.Add(this.check_all);
            this.splitContainer1.Panel1.Controls.Add(this.button_open);
            this.splitContainer1.Panel1.Controls.Add(this.textbox_filepath);
            this.splitContainer1.Panel1MinSize = 30;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ent_list);
            this.splitContainer1.Size = new System.Drawing.Size(384, 554);
            this.splitContainer1.SplitterDistance = 48;
            this.splitContainer1.TabIndex = 3;
            // 
            // check_all
            // 
            this.check_all.AutoSize = true;
            this.check_all.Checked = true;
            this.check_all.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_all.Location = new System.Drawing.Point(21, 26);
            this.check_all.Name = "check_all";
            this.check_all.Size = new System.Drawing.Size(70, 17);
            this.check_all.TabIndex = 3;
            this.check_all.Text = "Select All";
            this.check_all.UseVisualStyleBackColor = true;
            this.check_all.CheckedChanged += new System.EventHandler(this.check_all_CheckedChanged);
            // 
            // button_create
            // 
            this.button_create.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_create.Location = new System.Drawing.Point(133, 20);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(87, 28);
            this.button_create.TabIndex = 4;
            this.button_create.Text = "Split Lump";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 554);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BSPLump Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader col_checked;
        private System.Windows.Forms.ColumnHeader col_hammerid;
        private System.Windows.Forms.ColumnHeader col_name;
        private System.Windows.Forms.ListView ent_list;
        private System.Windows.Forms.OpenFileDialog open_file;
        private System.Windows.Forms.TextBox textbox_filepath;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox check_all;
        private System.Windows.Forms.Button button_create;
    }
}

