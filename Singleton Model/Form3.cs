using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2_Things
{
    public partial class Form3 : Form
    {
        private ObjectManager _singleton = ObjectManager.GetObjectManager;


        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (Tile t in _singleton.Tiles)
            {
                listBox1.Items.Add(t.TileID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _singleton.exampleString = textBox1.Text;
        }
    }
}
