using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapMaker
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(mapBox.TextLength == 0 || squadBox_X.TextLength == 0 || enemyBox1_X.TextLength == 0 || enemyBox2_X.TextLength == 0 || enemyBox3_X.TextLength == 0)
            {
                MessageBox.Show("Cannot have an empty field.", "Error", MessageBoxButtons.OK);
            }

                                 


            else
            {
                try
                {
                    StreamWriter sw = new StreamWriter(mapBox.Text + ".txt");
                    sw.WriteLine(squadBox_X.Text + "," + squadBox_Y.Text);
                    sw.WriteLine(enemyBox1_X.Text + "," + enemyBox1_Y.Text);
                    sw.WriteLine(enemyBox2_X.Text + "," + enemyBox2_Y.Text);
                    sw.WriteLine(enemyBox3_X.Text + "," + enemyBox3_Y.Text);
                    sw.Close();
                }

                catch(IOException ioe)
                { MessageBox.Show("Error writing file, try again.", "Error", MessageBoxButtons.OK); }
            }
        }
    }
}
