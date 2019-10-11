using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS
{
    public partial class Form1 : Form
    {

        protected PictureBox[,] _GridArrayPlayable = new PictureBox[19, 39];


        protected int[,] _GridLayout = new int[4, 4];



        public Form1()
        {

            InitializeComponent();

        }




        private void Form1_Load(object sender, EventArgs e)
        {

            Grid _Grid = new Grid(this);
            
        }
    }
}