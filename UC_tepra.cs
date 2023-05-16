using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tepra_App
{
    public partial class UC_tepra : UserControl
    {
        String kcode;

        public UC_tepra(String kcode, String name)
        {
            InitializeComponent();

            label2.Text = kcode;
            label4.Text = name;
        }


        public string Get_kcode()
        {
            return label2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*
            try
            {
                

                ProcessStartInfo startInfo = new(@"\\Server02\②　掲示板\27.   掲示板（営業・購買G)\テプラ\" + label2.Text + ".tpe");
               startInfo.UseShellExecute = true;
                Process.Start(startInfo);
               
            }
            catch
            {
                MessageBox.Show("該当ファイルが見つかりませんでした");
            }
            */

        }








    }




}
