using System.Data;

namespace Tepra_App
{
    
    public partial class Form1 : Form
    {
        SqlDb_TPiCSDB41 tpics = new();

        String[] args;
        String sql;
        DataTable dt;

        public Form1(String[] _args)
        {
            InitializeComponent();
            args = _args;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            if (args.Length != 0)
            {
                textBox1.Text = args[0].Replace("-","");
                Search(textBox1.Text);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter){
                //ïiî‘ÇÃíäèo 
                if (radioButton1.Checked)
                {
                    if (radioButton3.Checked) //çHíˆñæé¶
                    {
                        textBox1.Text = textBox1.Text.Substring(33, 10);
                    }
                    else //èoâ◊ñæé¶
                    {
                        //textBox1.Text = textBox1.Text.Substring(41, 10);
                        textBox1.Text = textBox1.Text.Replace(" ","").Substring(25, 10);
                    }
                }

                Search(textBox1.Text); 
            }
        }

        private void Search(String str)
        {
            sql = "select p.CODE,p.KCODE,h.NAME from TPiCSDB41.dbo.XPRTS p left join TPiCSDB41.dbo.XHEAD h on p.KCODE = h.CODE Where p.CODE = '" + str + "' and h.NAME like '%◊ÕﬁŸº∞Ÿ%' order by p.KCODE";
            dt = tpics.ExecuteSql(sql);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UC_tepra tepra = new(dt.Rows[i]["KCODE"].ToString(), dt.Rows[i]["NAME"].ToString());
                    flowLayoutPanel1.Controls.Add(tepra);
                }

                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("åüçıåãâ :0åè");
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            textBox1.Text = "";
            textBox1.Enabled = true;
            textBox1.Focus();
        }
    }
}