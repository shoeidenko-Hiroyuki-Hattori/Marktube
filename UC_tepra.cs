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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Tepra_App
{
    public partial class UC_tepra : UserControl
    {
        SqlDb_ShoeiMySQLDB mysql = new(dbn: "marktv");
        String kcode;

        public UC_tepra(String kcode, String name)
        {
            InitializeComponent();

            label2.Text = kcode;
            label4.Text = name;
            GetData();

        }


        private void GetData()
        {
            //条件表の表示
            label8.Text = mysql.ExecuteScalar(string.Format("Select TV経 From ﾏｰｸtv条件表 Where Code ='{0}';", label2.Text));
            label6.Text = mysql.ExecuteScalar(string.Format("Select カット寸法 From ﾏｰｸtv条件表 Where Code ='{0}';", label2.Text));
            label4.Text = mysql.ExecuteScalar(string.Format("Select 印字内容 From ﾏｰｸtv条件表 Where Code ='{0}';", label2.Text));

        }

        public string Get_kcode()
        {
            return label2.Text;
        }


    }




}
