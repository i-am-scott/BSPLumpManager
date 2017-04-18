using BSPLumpManager.BSPReader;
using BSPLumpManager.KVP;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace BSPLumpManager
{

    public partial class MainWindow : Form
    {
        public static BSP map;

        public MainWindow()
        {
            InitializeComponent();
            ent_list.CheckBoxes = true;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Task.Run(() => {
                LoadMapData();
            });
        }

        private void LoadMapData( string map_path = "gm_flatgrass.bsp")
        {
            map = new BSP(map_path);

            Console.WriteLine(map);
            Console.WriteLine("Loading KeyValues");

            List<KeyValueGroup> ents = map.GetEntities();
            ListViewItem[] items     = new ListViewItem[ents.Count];

            for (int i = 0; i < ents.Count; i++)
            {
                KeyValueGroup ent = ents[i];
                ListViewItem item = new ListViewItem()
                {
                    Text        = ent.id.ToString(),
                    Tag         = ent,
                    ToolTipText = ent.raw,
                    Checked     = true
                };

                string hammerid = "UNKNOWN";
                ent.keys.TryGetValue("hammerid", out hammerid);
                item.SubItems.Add(hammerid);

                string name = "Unknown Name";
                ent.keys.TryGetValue("classname", out name);
                item.SubItems.Add(name);

                items[i] = item;

                Console.WriteLine("{0:D4}|\t{1}\t{2}", ent.id, hammerid, name);
            }

            Invoke(new Action(() =>
            {
                ent_list.Items.AddRange(items);
            }));
        }

    }

}