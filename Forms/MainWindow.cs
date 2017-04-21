using BSPLumpManager.BSPReader;
using BSPLumpManager.KVP;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace BSPLumpManager
{

    public partial class MainWindow : Form
    {

        public static BSP map;

        public MainWindow()
        {
            InitializeComponent();

            open_file.FileOk     += Open_file_FileOk;
            ent_list.ItemChecked += Ent_list_ItemChecked;
        }

        private void LoadMapData( string map_path )
        {
            try
            {
                map = new BSP(map_path);
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.Message, "Invalid BSP File");
                return;
            }

            map.GetEntities();
            ListViewItem[] items     = new ListViewItem[map.entities.Count];

            for (int i = 0; i < map.entities.Count; i++)
            {
                KeyValueGroup ent = map.entities[i];
                ent.enabled       = check_all.Checked;

                ListViewItem item = new ListViewItem()
                {
                    Text        = ent.id.ToString(),
                    Tag         = ent,
                    ToolTipText = ent.raw,
                    Checked     = check_all.Checked
                };

                string hammerid = "UNKNOWN";
                ent.keys.TryGetValue("hammerid", out hammerid);
                item.SubItems.Add(hammerid);

                string name = "Unknown Name";
                ent.keys.TryGetValue("classname", out name);
                item.SubItems.Add(name);

                items[i] = item;
            }

            Invoke(new Action(() =>
            {
                ent_list.Items.AddRange(items);
                ent_list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                ent_list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }));
        }


        private void SaveMapData()
        {
            if (map == null)
                return;

            Task.Run(() => {
                map.SplitEntities();
            });
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            SaveMapData();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            open_file.ShowDialog();
        }

        private void Open_file_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string file_path = open_file.FileName;
            if (string.IsNullOrEmpty(file_path) || Path.GetExtension(file_path) != ".bsp")
                return;

            textbox_filepath.Text = file_path;

            ent_list.Items.Clear();

            Task.Run(() => {
                LoadMapData(file_path);
            });
        }

        private void Ent_list_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            KeyValueGroup ent = (KeyValueGroup)e.Item.Tag;
            if(ent.id == 0)
            {
                ent.enabled = true;
                e.Item.Checked = true;
                return;
            }

            ent.enabled = e.Item.Checked;
        }

        private void check_all_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ent_list.Items.Count; i++)
            {
                map.entities[i].enabled   = i == 0 ? true : check_all.Checked;
                ent_list.Items[i].Checked = map.entities[i].enabled;
            }
        }
    }

}