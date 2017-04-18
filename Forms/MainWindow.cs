using BSPLumpManager.BSPReader;
using BSPLumpManager.KVP;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BSPLumpManager
{

    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            BSP map        = new BSP("gm_flatgrass.bsp");
            Console.WriteLine(map);

            Console.WriteLine("Loading KeyValues");
            List<KeyValueGroup> ents = map.GetEntities();

            ent_list.CheckBoxes = true;

            foreach (KeyValueGroup ent in ents )
            {

                ListViewItem item = new ListViewItem() {
                    Text          = ent.id.ToString(),
                    Tag           = ent,
                    ToolTipText   = ent.raw,
                    Checked       = true
                };

                string hammerid = "UNKNOWN";
                ent.keys.TryGetValue("hammerid", out hammerid);
                item.SubItems.Add(hammerid);

                string name     = "Unknown Name";
                ent.keys.TryGetValue("classname", out name);
                item.SubItems.Add(name);

                var checkbox     = new CheckBox();
                checkbox.Name    = "check_" + hammerid;
                checkbox.Checked = true;

                Console.WriteLine("{0:D4}|\t{1}\t{2}", ent.id, hammerid, name);
                ent_list.Items.Add(item);
            }
        }
    }

}