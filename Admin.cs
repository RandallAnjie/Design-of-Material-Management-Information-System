using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 大学实验材料管理信息系统数据库设计
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            SqlConnection conn = new();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            textBox1.Text = login.id;
            textBox2.Text = DateTime.Now.ToString("yyyy/MM/dd " + "ddd");
            SqlCommand com = new("select ADNA from AD where ADNO='" + login.id + "'", conn);
            conn.Open();
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            string hello = "欢迎您" + dr[0].ToString().Trim() + "!";
            label3.Text = hello;
            dr.Dispose();
            com.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login form1 = new();
            form1.Show();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            SqlDataAdapter sda = new("select MSNA AS 材料名称,MSNO AS 材料编号,MSLNA AS 实验室名称,MSLNO AS 实验室编号,MSNU AS 材料余量,MSDP AS 是否需要归还 from MS", conn);
            DataSet ds = new();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.RowHeadersVisible = true;
            SqlDataAdapter sda1 = new("select STNA AS 学生姓名,STNO AS 学号 from ST", conn);
            DataSet ds1 = new();
            sda1.Fill(ds1);
            dataGridView2.DataSource = ds1.Tables[0];
            dataGridView2.RowHeadersVisible = true;
            SqlDataAdapter sda2 = new("select STNO AS 学生学号,MSNO AS 材料编号,MSLNO AS 实验室编号,BONU AS 借用数量,BODA AS 借用日期,RTDA AS 预计归还日期,CODE AS 核验码 from BO", conn);
            DataSet ds2 = new();
            sda2.Fill(ds2);
            dataGridView3.DataSource = ds2.Tables[0];
            dataGridView3.RowHeadersVisible = true;
            SqlDataAdapter sda3 = new("select MSLNA AS 实验室名称,MSLNO AS 实验室编号,ADNA AS 管理员姓名,ADNO AS 管理员编号 from MSL", conn);
            DataSet ds3 = new();
            sda3.Fill(ds3);
            dataGridView4.DataSource = ds3.Tables[0];
            dataGridView4.RowHeadersVisible = true;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //实例化SqlConnection变量conn，连接数据库
            SqlConnection conn = new("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            //实例化SqlDataAdapter对象
            SqlDataAdapter sda = new("select MSNA AS 材料名称,MSNO AS 材料编号,MSLNA AS 实验室名称,MSLNO AS 实验室编号,MSNU AS 材料余量,MSDP AS 是否需要归还 from MS", conn);
            DataSet ds = new();//实例化DataSet对象
            sda.Fill(ds);//使用SqlDataAdapter对象的Fill方法填充DataSet            
            dataGridView1.DataSource = ds.Tables[0];//设置dataGridView1控件的数据源
            dataGridView1.RowHeadersVisible = true;//禁止显示行标题
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //实例化SqlConnection变量conn，连接数据库
            SqlConnection conn = new("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            //实例化SqlDataAdapter对象
            SqlDataAdapter sda = new("select STNA AS 学生姓名,STNO AS 学号 from ST", conn);
            DataSet ds = new();//实例化DataSet对象
            sda.Fill(ds);//使用SqlDataAdapter对象的Fill方法填充DataSet            
            dataGridView2.DataSource = ds.Tables[0];//设置dataGridView1控件的数据源
            dataGridView2.RowHeadersVisible = true;//禁止显示行标题
            conn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //实例化SqlConnection变量conn，连接数据库
            SqlConnection conn = conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            //实例化SqlDataAdapter对象
            SqlDataAdapter sda = new("select STNO AS 学生学号,MSNO AS 材料编号,MSLNO AS 实验室编号,BONU AS 借用数量,BODA AS 借用日期,RTDA AS 预计归还日期,CODE AS 核验码 from BO", conn);
            DataSet ds = new();//实例化DataSet对象
            sda.Fill(ds);//使用SqlDataAdapter对象的Fill方法填充DataSet            
            dataGridView3.DataSource = ds.Tables[0];//设置dataGridView1控件的数据源
            dataGridView3.RowHeadersVisible = true;//禁止显示行标题
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            SqlCommand cmd = new("select MSNA AS 材料名称,MSNO AS 材料编号,MSLNA AS 实验室名称,MSLNO AS 实验室编号,MSNU AS 材料余量,MSDP AS 是否需要归还 from MS", conn);
            SqlDataAdapter sda = new();
            sda.SelectCommand = cmd;
            DataSet ds = new();//实例化DataSet对象            
            sda.Fill(ds, "cs");
            DataTable dt = ds.Tables["cs"];
            DataRow dr = ds.Tables["cs"].NewRow();//新建一个数据行
            int r = dataGridView1.CurrentRow.Index;//获得当前行的索引
            //数据行赋值
            dr[0] = dataGridView1.Rows[r].Cells[0].Value;
            dr[1] = dataGridView1.Rows[r].Cells[1].Value;
            dr[2] = dataGridView1.Rows[r].Cells[2].Value;
            dr[3] = dataGridView1.Rows[r].Cells[3].Value;
            dr[4] = dataGridView1.Rows[r].Cells[4].Value;
            dr[5] = dataGridView1.Rows[r].Cells[5].Value;
            String str = this.dataGridView1.CurrentRow.Cells["材料编号"].Value.ToString();
            String sql1 = "delete from MS where MSNO ='" + str + "'";
            cmd = new SqlCommand(sql1, conn);
            cmd.ExecuteNonQuery();
            ds.Tables["cs"].Rows.Add(dr);
            //批量更新数据库
            SqlCommandBuilder cmdbuilder = new(sda);
            if (ds.Tables["cs"].GetChanges() != null)
            {
                sda.Update(ds, "cs");
                ds.AcceptChanges();
            }
            MessageBox.Show("修改成功！");
            conn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new();
            conn = new SqlConnection("server = 转接的电脑; Initial Catalog = 大学实验材料管理信息系统数据库; Integrated Security = True ");
            //判断用户是否选择一行数据，true为没选择，false为选择
            if (this.dataGridView3.Rows[this.dataGridView3.CurrentRow.Index].Cells["核验码"].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除！");
            }
            else
            {  //判断用户是否点击确定按钮，true为点击，false为没有点击
                if (MessageBox.Show("确认删除？", "提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    String str = this.dataGridView3.CurrentRow.Cells[6].Value.ToString();
                    String sql = "delete from BO where CODE ='" + str + "'";
                    SqlCommand cmd = new(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.dataGridView3.Rows.Remove(this.dataGridView3.CurrentRow);
                    MessageBox.Show("此行删除成功！");
                }
            }
            conn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            SqlCommand cmd = new("select STNO AS 学生学号,MSNO AS 材料编号,MSLNO AS 实验室编号,BONU AS 借用数量,BODA AS 借用日期,RTDA AS 预计归还日期,CODE AS 核验码 from BO", conn);
            SqlDataAdapter sda = new();
            sda.SelectCommand = cmd;
            DataSet ds = new();//实例化DataSet对象            
            sda.Fill(ds, "cs");
            DataTable dt = ds.Tables["cs"];
            DataRow dr = ds.Tables["cs"].NewRow();//新建一个数据行
            int r = dataGridView3.CurrentRow.Index;//获得当前行的索引
            //数据行赋值
            dr[0] = dataGridView3.Rows[r].Cells[0].Value;
            dr[1] = dataGridView3.Rows[r].Cells[1].Value;
            dr[2] = dataGridView3.Rows[r].Cells[2].Value;
            dr[3] = dataGridView3.Rows[r].Cells[3].Value;
            dr[4] = dataGridView3.Rows[r].Cells[4].Value;
            dr[5] = dataGridView3.Rows[r].Cells[5].Value;
            dr[6] = dataGridView3.Rows[r].Cells[6].Value;
            String str = this.dataGridView3.CurrentRow.Cells["核验码"].Value.ToString();
            String sql1 = "delete from BO where CODE ='" + str + "'";
            cmd = new SqlCommand(sql1, conn);
            cmd.ExecuteNonQuery();
            ds.Tables["cs"].Rows.Add(dr);
            //批量更新数据库
            SqlCommandBuilder cmdbuilder = new(sda);
            if (ds.Tables["cs"].GetChanges() != null)
            {
                sda.Update(ds, "cs");
                ds.AcceptChanges();
            }
            MessageBox.Show("修改成功！");
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new();
            conn = new SqlConnection("server = 转接的电脑; Initial Catalog = 大学实验材料管理信息系统数据库; Integrated Security = True ");
            //判断用户是否选择一行数据，true为没选择，false为选择
            if (this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["材料编号"].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除！");
            }
            else
            {  //判断用户是否点击确定按钮，true为点击，false为没有点击
                if (MessageBox.Show("确认删除？", "提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    String str = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    String sql = "delete from MS where MSNO ='" + str + "'";
                    SqlCommand cmd = new(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
                    MessageBox.Show("此行删除成功！");
                }
            }
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new();
            conn = new SqlConnection("server = 转接的电脑; Initial Catalog = 大学实验材料管理信息系统数据库; Integrated Security = True ");
            //判断用户是否选择一行数据，true为没选择，false为选择
            if (this.dataGridView2.Rows[this.dataGridView2.CurrentRow.Index].Cells["学号"].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除！");
            }
            else
            {  //判断用户是否点击确定按钮，true为点击，false为没有点击
                if (MessageBox.Show("确认删除？", "提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    String str = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    String sql = "delete from ST where STNO ='" + str + "'";
                    SqlCommand cmd = new(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.dataGridView2.Rows.Remove(this.dataGridView2.CurrentRow);
                    MessageBox.Show("此行删除成功！");
                }
            }
            conn.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new();
            conn = new("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            if (textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {
                SqlCommand cmd3 = new("select count(*) from AD where ADNO = '" + login.id + "'", conn);
                conn.Open();
                int b = (int)cmd3.ExecuteScalar();
                if (b == 1)
                {
                    SqlCommand cmd4 = new("select ADKE from AD where ADNO = '" + login.id + "'", conn);
                    string c = cmd4.ExecuteScalar().ToString().Trim();
                    string oldpwd = textBox3.Text.Trim();
                    string newpwd = textBox4.Text.Trim();
                    string dnewpwd = textBox5.Text.Trim();

                    if (newpwd == dnewpwd)
                    {
                        if (c == oldpwd)
                        {
                            if (oldpwd == newpwd)
                            {
                                SqlCommand cmd5 = new("update AD set ADKE = '" + newpwd + "'where ADNO = '" + login.id + "'", conn);
                                int k = (int)cmd5.ExecuteNonQuery();
                                if (k > 0)
                                {
                                    MessageBox.Show("密码修改成功，请重新登录！", "提示");
                                    this.Hide();
                                    login form1 = new();
                                    form1.Show();
                                }
                                else
                                {
                                    MessageBox.Show("密码修改失败！", "提示");
                                    textBox3.Text = "";
                                    textBox4.Text = "";
                                    textBox5.Text = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("新旧密码不能一样！", "提示");
                                textBox4.Text = "";
                                textBox5.Text = "";
                            }

                        }
                        else
                        {
                            MessageBox.Show("原密码填写错误！", "提示");
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("两次新密码不一致！", "提示");
                        textBox4.Text = "";
                        textBox5.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("用户名不存在请重新登录！", "提示");
                    this.Hide();
                    login form1 = new();
                    form1.Show();
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("密码不能为空！", "提示");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //实例化SqlConnection变量conn，连接数据库
            SqlConnection conn = conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            //实例化SqlDataAdapter对象
            SqlDataAdapter sda = new("select MSLNA AS 实验室名称,MSLNO AS 实验室编号,ADNA AS 管理员姓名,ADNO AS 管理员编号 from MSL", conn);
            DataSet ds = new();//实例化DataSet对象
            sda.Fill(ds);//使用SqlDataAdapter对象的Fill方法填充DataSet            
            dataGridView4.DataSource = ds.Tables[0];//设置dataGridView1控件的数据源
            dataGridView4.RowHeadersVisible = true;//禁止显示行标题
            conn.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SqlConnection conn = conn = new("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            SqlCommand cmd = new("select MSLNA AS 实验室名称,MSLNO AS 实验室编号,ADNA AS 管理员姓名,ADNO AS 管理员编号 from MSL", conn);
            SqlDataAdapter sda = new();
            sda.SelectCommand = cmd;
            DataSet ds = new();//实例化DataSet对象            
            sda.Fill(ds, "cs");
            DataTable dt = ds.Tables["cs"];
            DataRow dr = ds.Tables["cs"].NewRow();//新建一个数据行
            int r = dataGridView4.CurrentRow.Index;//获得当前行的索引
            //数据行赋值
            dr[0] = dataGridView4.Rows[r].Cells[0].Value;
            dr[1] = dataGridView4.Rows[r].Cells[1].Value;
            dr[2] = dataGridView4.Rows[r].Cells[2].Value;
            dr[3] = dataGridView4.Rows[r].Cells[3].Value;
            String str = this.dataGridView4.CurrentRow.Cells["实验室编号"].Value.ToString();
            String sql1 = "delete from MSL where MSLNO ='" + str + "'";
            cmd = new SqlCommand(sql1, conn);
            cmd.ExecuteNonQuery();
            ds.Tables["cs"].Rows.Add(dr);
            //批量更新数据库
            SqlCommandBuilder cmdbuilder = new(sda);
            if (ds.Tables["cs"].GetChanges() != null)
            {
                sda.Update(ds, "cs");
                ds.AcceptChanges();
            }
            MessageBox.Show("修改成功！");
            conn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new();
            conn = new("server = 转接的电脑; Initial Catalog = 大学实验材料管理信息系统数据库; Integrated Security = True ");
            //判断用户是否选择一行数据，true为没选择，false为选择
            if (this.dataGridView4.Rows[this.dataGridView4.CurrentRow.Index].Cells["实验室编号"].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除！");
            }
            else
            {  //判断用户是否点击确定按钮，true为点击，false为没有点击
                if (MessageBox.Show("确认删除？", "提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    String str = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
                    String sql = "delete from MSL where MSLNO ='" + str + "'";
                    SqlCommand cmd = new(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.dataGridView4.Rows.Remove(this.dataGridView4.CurrentRow);
                    MessageBox.Show("此行删除成功！");
                }
            }
            conn.Close();
        }
    }
}
