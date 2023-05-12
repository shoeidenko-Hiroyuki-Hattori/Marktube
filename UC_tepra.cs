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

        private void button1_Click(object sender, EventArgs e)
        {

            Dlete_bmp_file();
            Copy_bmp_file();
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



        String original = @"\\Server02\②　掲示板\30.   掲示板（情報G）\マークチューブ印字画像";
        String to = @"D:";

        public void Dlete_bmp_file()
        {
            String[] strArrayFiles;
            strArrayFiles = System.IO.Directory.GetFiles(to, "*.bmp");
            foreach (string item in strArrayFiles)
            {

                MessageBox.Show(item);
                System.IO.File.Delete(item);
            }
        }
        public void Copy_bmp_file()
        {
            String[] strArrayFiles;
            strArrayFiles = System.IO.Directory.GetFiles(original, "*.bmp");
            foreach (string item in strArrayFiles)
            {

                String[] str;
                str = item.Split(@"\");
                System.IO.File.Copy(item, to + @"\" + str[str.Length-1] );
              
            }
        }







    }




}
