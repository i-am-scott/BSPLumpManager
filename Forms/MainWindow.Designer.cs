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
            this.SuspendLayout();
            // 
            // col_checked
            // 
            this.col_checked.Text = "Keep Id";
            // 
            // col_hammerid
            // 
            this.col_hammerid.Text = "Hammer ID";
            // 
            // col_name
            // 
            this.col_name.Text = "Name";
            // 
            // ent_list
            // 
            this.ent_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_checked,
            this.col_hammerid,
            this.col_name});
            this.ent_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ent_list.Location = new System.Drawing.Point(0, 0);
            this.ent_list.Name = "ent_list";
            this.ent_list.Size = new System.Drawing.Size(384, 511);
            this.ent_list.TabIndex = 0;
            this.ent_list.UseCompatibleStateImageBehavior = false;
            this.ent_list.View = System.Windows.Forms.View.Details;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 511);
            this.Controls.Add(this.ent_list);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BSPLump Editor";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader col_checked;
        private System.Windows.Forms.ColumnHeader col_hammerid;
        private System.Windows.Forms.ColumnHeader col_name;
        private System.Windows.Forms.ListView ent_list;
    }
}

