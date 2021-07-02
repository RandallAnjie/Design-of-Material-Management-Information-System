using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace 大学实验材料管理信息系统数据库设计
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public static string id;
        public static string today = DateTime.Now.ToString("yyyyMMdd");
        private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new(62);
            Random rd = new();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";//清空文本框内容
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";//清空文本框内容
            textBox4.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String UserName, Password;
            UserName = textBox1.Text;
            Password = textBox2.Text;
            SqlConnection conn = new();
            conn = new("Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            //姓名登录
            if (this.radioButton1.Checked)
            {
                String sql = $"select count(*) from ST where STNA='{this.textBox1.Text}' and STKE = '{this.textBox2.Text}'";
                SqlCommand cmd = new(sql, conn);
                SqlDataAdapter adapter = new();
                adapter.SelectCommand = cmd;
                conn.Open();
                //查询返回结果
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    MessageBox.Show("登录成功！");
                    SqlCommand com = new("select STNO from ST where STNA='" + textBox1.Text.Trim() + "'", conn);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        id = dr[0].ToString().Trim();
                    }
                    else
                    {
                        id = "none";
                    }
                    dr.Dispose();
                    com.Dispose();
                    this.Hide();
                    student form1 = new();
                    form1.Show();
                }
                else if (result == 0)
                {
                    MessageBox.Show("用户名/密码错误！");
                }
                else
                {
                    MessageBox.Show("存在重名，请使用学号登录！");
                }
                conn.Close();
            }
            //学号登录
            else if (this.radioButton2.Checked)
            {
                String sql = $"select count(*) from ST where STNO='{this.textBox1.Text}' and STKE = '{this.textBox2.Text}'";
                SqlCommand cmd = new(sql, conn);
                SqlDataAdapter adapter = new();
                adapter.SelectCommand = cmd;
                conn.Open();
                //查询返回结果
                int result = (int)cmd.ExecuteScalar();
                conn.Close();
                if (result == 1)
                {
                    MessageBox.Show("登录成功。");
                    id = this.textBox1.Text.Trim();
                    this.Hide();
                    student form1 = new();
                    form1.Show();
                }
                else if (result == 0)
                {
                    MessageBox.Show("学号/密码错误！");
                }
                else
                {
                    MessageBox.Show("数据库信息错误，请联系管理员！");
                }
            }
            //游客登录
            else if (this.radioButton3.Checked)
            {
                MessageBox.Show("登陆成功！", "提示", MessageBoxButtons.OK);
                this.Hide();
                guider form1 = new();
                form1.Show();
            }
            else
            {
                MessageBox.Show("请选择登录方式！", "提示", MessageBoxButtons.OK);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            register form1 = new();
            form1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            register form1 = new();
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String UserName, Password;
            UserName = textBox3.Text;
            Password = textBox4.Text;
            SqlConnection conn = new();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            //姓名登录
            if (this.radioButton4.Checked)
            {
                String sql = $"select count(1) from AD where ADNA='{this.textBox3.Text}' and ADKE = '{this.textBox4.Text}'";
                SqlCommand cmd = new(sql, conn);
                SqlDataAdapter adapter = new();
                adapter.SelectCommand = cmd;
                conn.Open();
                //查询返回结果
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    MessageBox.Show("登录成功！");
                    SqlCommand com = new("select ADNO from AD where ADNA='" + textBox3.Text.Trim() + "'", conn);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        id = dr[0].ToString().Trim();
                    }
                    else
                    {
                        id = "none";
                    }
                    dr.Dispose();
                    com.Dispose();
                    this.Hide();
                    Admin form1 = new();
                    form1.Show();
                }
                else
                    MessageBox.Show("用户名/密码错误！");
                conn.Close();
            }
            //工号登录
            else if (this.radioButton5.Checked)
            {
                String sql = $"select count(1) from AD where ADNO='{this.textBox3.Text}' and ADKE = '{this.textBox4.Text}'";
                SqlCommand cmd = new(sql, conn);
                SqlDataAdapter adapter = new();
                adapter.SelectCommand = cmd;
                conn.Open();
                //查询返回结果
                int result = (int)cmd.ExecuteScalar();
                conn.Close();
                if (result == 1)
                {
                    MessageBox.Show("登录成功！");
                    id = this.textBox3.Text.Trim();
                    this.Hide();
                    Admin form1 = new();
                    form1.Show();
                }
                else
                    MessageBox.Show("用户名/密码错误！");
            }
            else
            {
                MessageBox.Show("请选择登录方式！", "提示", MessageBoxButtons.OK);
            }
        }
    }
}
