using BSPLumpManager.BSPReader;
using BSPLumpManager.KVP;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSPLumpManager.Forms
{
    public partial class LumpManager : MetroFramework.Forms.MetroForm
    {
        public static BSP map;

        public LumpManager()
        {
            InitializeComponent();

            list_ents.ForeColor = ForeColor;
            list_ents.BackgroundColor = BackColor;
            list_ents.GridColor = BackColor;
            list_ents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            list_ents.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            list_ents.CellPainting += (object _, DataGridViewCellPaintingEventArgs e) => {
                e.CellStyle.BackColor = Color.White;
            };
        }

        private void LumpManager_Load(object sender, EventArgs e)
        {
            open_file.FileOk += Open_file_FileOk;
            list_ents.CellContentClick += List_ents_CellContentClick;
        }

        private void LoadMapData(string map_path)
        {
            try
            {
                map = new BSP(map_path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Invalid BSP File");
                return;
            }

            map.GetEntities();

            for (var i = 0; i < map.entities.Count; i++)
            {
                KeyValueGroup ent = map.entities[i];
                ent.split = check_all.Checked;
            }

            Invoke(new Action(async () =>
            {
                await Task.Delay(500);

                list_ents.Visible = true;
                list_ents.DataSource = map.entities;
                list_ents.PerformLayout();
                loading.Visible = false;
            }));
        }

        private void SaveMapData()
        {
            if (map == null)
                return;

            loading.Visible = true;

            Task.Run(() => {
                map.SplitEntities();
                Invoke(new Action(() =>
                {
                    loading.Visible = false;
                    MessageBox.Show("Lump splitting complete. Remember to rename both the lump and the new bsp to a new version and do not fastdl the lump file!");
                }));
            });
        }

        private void Open_file_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string file_path = open_file.FileName;
            if (string.IsNullOrEmpty(file_path) || Path.GetExtension(file_path) != ".bsp")
                return;

            loading.Visible = true;
            textbox_filepath.Text = file_path;

            if (map != null)
                map = null;

            list_ents.Rows.Clear();
            Task.Run(() => {
                LoadMapData(file_path);
            });
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            open_file.ShowDialog();
        }

        private void button_create_Click(object sender, EventArgs e)
            => SaveMapData();
 
        private void check_all_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < map.entities.Count; i++)
                map.entities[i].split = check_all.Checked;
        }

        private void List_ents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
                return;

            if (e.ColumnIndex == 0)
                MessageBox.Show(map.entities[e.RowIndex].raw, "Raw Entity Key Values");

            if (e.ColumnIndex == 1)
                map.entities[e.RowIndex].split = !map.entities[e.RowIndex].split;
        }

        private void link_github_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/scottd564/BSPLumpManager");
        }
    }
}
