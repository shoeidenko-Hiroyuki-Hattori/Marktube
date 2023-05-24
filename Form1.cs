using System.Data;

namespace Tepra_App
{
    
    public partial class Form1 : Form
    {
        SqlDb_TPiCSDB41 tpics = new();
        String[] args;
        String sql;
        DataTable dt;

        String original = @"\\Server02\�A�@�f����\30.   �f���i���G�j\�}�[�N�`���[�u�󎚉摜";
        String to = @"D:";


        public Form1(String[] _args)
        {
            InitializeComponent();
            args = _args;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            if (args.Length == 0)
            {
                return;
            }

            textBox1.Text = args[0].Replace("-","");
            Search(textBox1.Text);

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Enter) {
                return;
            }

            //�i�Ԃ̒��o            (�o�ז����[�̏ꍇ) 
            textBox1.Text = textBox1.Text.Replace(" ", "").Substring(25, 10);
            Search(textBox1.Text); 

        }

        private void Search(String str)
        {
            sql = "select p.CODE,p.KCODE,h.NAME from TPiCSDB41.dbo.XPRTS p left join TPiCSDB41.dbo.XHEAD h on p.KCODE = h.CODE Where p.CODE = '" + str + "' and h.NAME like '%ϰ������%' order by p.KCODE";
            dt = tpics.ExecuteSql(sql);

            if (dt.Rows.Count == 0)
            {
                textBox1.Text = "";
                MessageBox.Show("��������:0��");
                return;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UC_tepra tepra = new(dt.Rows[i]["KCODE"].ToString(), dt.Rows[i]["NAME"].ToString());
                flowLayoutPanel1.Controls.Add(tepra);
            }

            textBox1.Enabled = false;
            publish();
           
        }

        private void Clear(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            textBox1.Text = "";
            textBox1.Enabled = true;
            textBox1.Focus();
        }






        public void publish()
        {
            try
            {
                Dlete_bmp_file();

                int i = 0;
                foreach (Object item in flowLayoutPanel1.Controls)
                {
                    UC_tepra uc;
                    uc = (UC_tepra)item;
                    Copy_bmp_file(uc.Get_kcode());
                    i++;
                }

                if (i >= 1)
                {
                    MessageBox.Show("�o�͊���");
                }


            }
            catch
            {
                MessageBox.Show("�G���[:�o�̓p�X���m�F���ĉ������B");
            }

        // Clear(null,null);

        }


 

        public void Dlete_bmp_file()
        {
            String[] strArrayFiles;
            strArrayFiles = System.IO.Directory.GetFiles(to, "*.bmp");
            foreach (string item in strArrayFiles)
            {
                System.IO.File.Delete(item);
            }
        }


        public void Copy_bmp_file(String kcode)
        {

            String[] strArrayFiles;
            strArrayFiles = System.IO.Directory.GetFiles(original, String.Format("*{0}.bmp", kcode));
            
            foreach (string item in strArrayFiles)
            {

                String[] str;
                str = item.Split(@"\");
                System.IO.File.Copy(item, to + @"\" + str[str.Length - 1]);

            }
        }

    }
}