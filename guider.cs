using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 大学实验材料管理信息系统数据库设计
{
    public partial class guider : Form
    {
        public guider()
        {
            InitializeComponent();
            textBox2.Text = DateTime.Now.ToString("yyyy/MM/dd " + "ddd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login form1 = new login();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            SqlDataAdapter sda = new SqlDataAdapter("select MSNA AS 材料名,MSNO AS 材料编号,MSLNA AS 实验室名称,MSLNO AS 实验室编号,MSNU AS 材料余量 from MS", conn);
            DataSet ds = new DataSet();//实例化DataSet对象
            sda.Fill(ds);//使用SqlDataAdapter对象的Fill方法填充DataSet            
            dataGridView1.DataSource = ds.Tables[0];//设置dataGridView1控件的数据源
            dataGridView1.RowHeadersVisible = true;//显示行标题
            conn.Close();
        }

        private void guider_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
