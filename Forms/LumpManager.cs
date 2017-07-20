using BSPLumpManager.BSPReader;
using BSPLumpManager.KVP;
using System;
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
        }

        private void LumpManager_Load(object sender, EventArgs e)
        {
            list_ents.ForeColor = ForeColor;
            list_ents.BackColor = BackColor;
            open_file.FileOk += Open_file_FileOk;
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
            ListViewItem[] items = new ListViewItem[map.entities.Count];

            for (int i = 0; i < map.entities.Count; i++)
            {
                KeyValueGroup ent = map.entities[i];
                ent.enabled = check_all.Checked;

                ListViewItem item = new ListViewItem()
                {
                    Text = ent.id.ToString(),
                    Tag = ent,
                    ToolTipText = ent.raw.Replace("\\n", " "),
                    Checked = check_all.Checked
                };

                string hammerid = "UNKNOWN";
                ent.keys.TryGetValue("hammerid", out hammerid);
                item.SubItems.Add(hammerid);

                string name = "Unknown Name";
                ent.keys.TryGetValue("classname", out name);
                ent.keys.TryGetValue("targetname", out string target );
                
                item.SubItems.Add($"{name} ({ target ?? "no name"})");               
                items[i] = item;
            }

            Invoke(new Action(() =>
            {
                list_ents.Items.AddRange(items);
                loading.Visible = false;
                list_ents.Visible = true;
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

            list_ents.Items.Clear();
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
            for (int i = 0; i < list_ents.Items.Count; i++)
            {
                map.entities[i].enabled   = i == 0 ? true : check_all.Checked;
                list_ents.Items[i].Checked = map.entities[i].enabled;
            }
        }

        private void list_ents_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            KeyValueGroup ent = (KeyValueGroup)e.Item.Tag;
            if (ent.id == 0)
            {
                ent.enabled = true;
                e.Item.Checked = true;
                return;
            }

            ent.enabled = e.Item.Checked;
        }

        private void link_github_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/scottd564/BSPLumpManager");
        }
    }
}
