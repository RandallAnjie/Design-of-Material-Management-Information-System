using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 大学实验材料管理信息系统数据库设计
{
    public partial class student : Form
    {
        public student()
        {

            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            InitializeComponent();
            textBox1.Text = login.id;
            textBox2.Text = DateTime.Now.ToString("yyyy/MM/dd " + "ddd");
            SqlCommand com = new SqlCommand("select STNA from ST where STNO='" + login.id + "'", conn);
            conn.Open();
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            string hello = "欢迎您" + dr[0].ToString().Trim() + "!";
            label7.Text = hello;
            dr.Dispose();
            com.Dispose();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct MSLNO from MS ", conn);
            SqlDataAdapter db = new SqlDataAdapter("select distinct MSLNO from BO where STNO = '" + login.id + "'", conn);
            da.Fill(ds1);
            db.Fill(ds2);
            comboBox1.DataSource = ds1.Tables[0].DefaultView;
            comboBox1.DisplayMember = "MSLNO";
            comboBox3.DataSource = ds2.Tables[0].DefaultView;
            comboBox3.DisplayMember = "MSLNO";
            int count = comboBox1.Items.Count;//获取combobox1中所有行的数量
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            SqlDataAdapter sda = new SqlDataAdapter("select MSNA AS 材料名,MSNO AS 材料编号,MSLNA AS 实验室名称,MSLNO AS 实验室编号,MSNU AS 材料余量 from MS", conn);
            DataSet ds = new DataSet();//实例化DataSet对象
            sda.Fill(ds);//使用SqlDataAdapter对象的Fill方法填充DataSet
            dataGridView1.DataSource = ds.Tables[0];//设置dataGridView1控件的数据源
            dataGridView1.RowHeadersVisible = true;//显示行标题
            SqlCommand cmd6 = new SqlCommand("select count(*) from BO where (" + Convert.ToInt32(login.today) + "-RTDA)>='" + 0 + "' AND STNO = '" + login.id + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd6;
            int getw = (int)cmd6.ExecuteScalar();
            if (getw > 0)
            {
                MessageBox.Show("您有" + getw + "条已过期未还材料记录，请及时归还材料！", "提示");
            }
            conn.Close();
        }

        string returnday;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login form1 = new login();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            //或者conn = new SqlConnection("Data Source= . ; Initial Catalog=jxsk; Integrated Security=True ");
            SqlDataAdapter sda = new SqlDataAdapter("select MSNA AS 材料名,MSNO AS 材料编号,MSLNA AS 实验室名称,MSLNO AS 实验室编号,MSNU AS 材料余量 from MS", conn);
            DataSet ds = new DataSet();//实例化DataSet对象
            sda.Fill(ds);//使用SqlDataAdapter对象的Fill方法填充DataSet
            dataGridView1.DataSource = ds.Tables[0];//设置dataGridView1控件的数据源
            dataGridView1.RowHeadersVisible = true;//显示行标题
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            SqlDataAdapter sda = new SqlDataAdapter("select MSNO AS 材料编号,MSLNO AS 材料所属实验室,BONU AS 材料数量,BODA AS 借用日期,RTDA AS 预计归还日期 from BO WHERE STNO ='" + login.id + "'", conn);
            DataSet ds = new DataSet();//实例化DataSet对象
            sda.Fill(ds);//使用SqlDataAdapter对象的Fill方法填充DataSet
            dataGridView2.DataSource = ds.Tables[0];//设置dataGridView1控件的数据源
            dataGridView2.RowHeadersVisible = true;//显示行标题
            int n = dataGridView2.Rows.Count;
            for (int i = 0; i < n - 1; i++)
            {
                if (Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value) > Convert.ToInt32(login.today))
                {
                    dataGridView2.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.LightGreen;
                    dataGridView2.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.LightGreen;
                    dataGridView2.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.LightGreen;
                    dataGridView2.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.LightGreen;
                    dataGridView2.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value) == Convert.ToInt32(login.today))
                {
                    dataGridView2.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.Yellow;
                    dataGridView2.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.Yellow;
                    dataGridView2.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Yellow;
                    dataGridView2.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.Yellow;
                    dataGridView2.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    dataGridView2.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.Red;
                    dataGridView2.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.Red;
                    dataGridView2.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Red;
                    dataGridView2.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.Red;
                    dataGridView2.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Red;
                }
            }
            conn.Close();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void student_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            SqlDataAdapter sday = new SqlDataAdapter("select MSNO AS 材料编号,MSLNO AS 材料所属实验室,BONU AS 材料数量,BODA AS 借用日期,RTDA AS 归还日期 from RC WHERE STNO ='" + login.id + "'", conn);
            DataSet dsy = new DataSet();//实例化DataSet对象
            sday.Fill(dsy);//使用SqlDataAdapter对象的Fill方法填充DataSet            
            dataGridView2.DataSource = dsy.Tables[0];//设置dataGridView1控件的数据源
            dataGridView2.RowHeadersVisible = true;//显示行标题
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            if (textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {
                SqlCommand cmd3 = new SqlCommand("select count(*) from ST where STNO = '" + login.id + "'", conn);
                conn.Open();
                int b = (int)cmd3.ExecuteScalar();
                if (b == 1)
                {
                    SqlCommand cmd4 = new SqlCommand("select STKE from ST where STNO = '" + login.id + "'", conn);
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
                                SqlCommand cmd5 = new SqlCommand("update ST set STKE = '" + newpwd + "'where STNO = '" + login.id + "'", conn);
                                int k = (int)cmd5.ExecuteNonQuery();
                                if (k > 0)
                                {
                                    MessageBox.Show("密码修改成功，请重新登录！", "提示");
                                    this.Hide();
                                    login form1 = new login();
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
                    login form1 = new login();
                    form1.Show();
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("密码不能为空！", "提示");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            returnday = dateTimePicker1.Value.ToString("yyyyMMdd");
            textBox7.Text = dateTimePicker1.Value.ToString("D");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboBox2.DataSource = null;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            this.numericUpDown1.DecimalPlaces = 0;
            this.numericUpDown1.Value = Decimal.Round(1, 0);
            textBox7.Text = "";
            returnday = "";
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Checked = false;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("实验室编号，材料编号为空！", "提示");
            }
            else
            {
                if (comboBox2.Text.Trim() == "")
                {
                    MessageBox.Show("材料编号为空！", "提示");
                }
                else
                {
                    string labid = comboBox1.Text.Trim();//实验室编号
                    string material = comboBox2.Text.Trim();//材料编号
                    int num = Convert.ToInt32(numericUpDown1.Value.ToString().Trim());//材料数量
                    returnday = dateTimePicker1.Value.ToString("yyyyMMdd");//returnday返还日期
                    //获取材料数量
                    SqlCommand cmd4 = new SqlCommand("select MSNU from MS where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                    SqlCommand cmd5 = new SqlCommand("select MSDP from MS where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                    conn.Open();
                    int c = Convert.ToInt32(cmd4.ExecuteScalar().ToString());
                    int d = Convert.ToInt32(cmd5.ExecuteScalar().ToString());
                    conn.Close();
                    if (d == 1)
                    {
                        if (textBox7.Text.Trim() == "")
                        {
                            MessageBox.Show("该材料需要归还，请填写归还日期！", "提示");
                        }
                        else if (Convert.ToInt32(login.today.Trim()) > Convert.ToInt32(returnday))
                        {
                            MessageBox.Show("归还日期不能早于今天！", "提示");
                            textBox7.Text = "";
                            returnday = "";
                        }
                        else
                        {
                            if (c >= num)
                            {
                                SqlCommand cmd = new SqlCommand("insert into BO(STNO,MSLNO,MSNO,BONU,BODA,RTDA,CODE) values ('" + login.id + "','" + labid + "','" + material + "','" + num + "','" + login.today + "','" + returnday + "','" + login.GenerateRandom(10) + "')", conn);
                                SqlCommand cmd1 = new SqlCommand("insert into RC(STNO,MSLNO,MSNO,BONU,BODA) values ('" + login.id + "','" + labid + "','" + material + "','" + num + "','" + login.today + "')", conn);
                                try//异常处理
                                {
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    cmd1.ExecuteNonQuery();
                                    int res = c - num;
                                    if (res == 0)
                                    {
                                        SqlCommand cmd2 = new SqlCommand("delete from MS where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                                        try
                                        {
                                            cmd2.ExecuteNonQuery();
                                            MessageBox.Show("该材料需要归还，借用成功！");
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("删除原数据失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        SqlCommand cmd2 = new SqlCommand("update MS set MSNU = '" + res + "'where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                                        try
                                        {
                                            cmd2.ExecuteNonQuery();
                                            MessageBox.Show("该材料需要归还，借用成功！");
                                            this.Hide();
                                            student form1 = new student();
                                            form1.Show();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("删除原数据失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("借用失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("材料数量最多为" + c + "，请重新填写！", "提示");
                                numericUpDown1.Text = c.ToString();
                            }
                        }

                    }
                    else if (d == 0)
                    {
                        if (c >= num)
                        {
                            SqlCommand cmd1 = new SqlCommand("insert into RC(STNO,MSLNO,MSNO,BONU,BODA,RTDA) values ('" + login.id + "','" + labid + "','" + material + "','" + num + "','" + login.today + "','无需归还')", conn);
                            try//异常处理
                            {
                                conn.Open();
                                cmd1.ExecuteNonQuery();
                                int res = c - num;
                                if (res == 0)
                                {
                                    SqlCommand cmd2 = new SqlCommand("delete from MS where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                                    try
                                    {
                                        cmd2.ExecuteNonQuery();
                                        MessageBox.Show("该材料不需要归还，借用成功！");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("删除原数据失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    SqlCommand cmd2 = new SqlCommand("update MS set MSNU = '" + res + "'where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                                    try
                                    {
                                        cmd2.ExecuteNonQuery();
                                        MessageBox.Show("该材料不需要归还，借用成功！");
                                        this.Hide();
                                        student form1 = new student();
                                        form1.Show();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("删除原数据失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                conn.Close();
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("借用失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("材料数量最多为" + c + "，请重新填写！", "提示");
                            numericUpDown1.Text = c.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据库信息错误，请联系管理员！");
                    }
                }

            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = null;
            comboBox2.SelectedIndex = -1;
            comboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct MSNO from MS WHERE MSLNO = '" + comboBox1.Text + "'", conn);
            da.Fill(ds1);
            comboBox2.DataSource = ds1.Tables[0].DefaultView;
            comboBox2.DisplayMember = "MSNO";
            conn.Close();
            comboBox2.SelectedIndex = -1;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            if (comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("请选择材料！", "提示");
            }
            else
            {
                string labid = comboBox1.Text.Trim();//实验室编号
                string material = comboBox2.Text.Trim();//材料编号
                SqlCommand cmd5 = new SqlCommand("select MSDP from MS where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn); conn.Open();
                int d = Convert.ToInt32(cmd5.ExecuteScalar().ToString());
                conn.Close();
                if (d == 1)
                {
                    MessageBox.Show("材料" + comboBox2.Text.Trim() + "需要归还！", "提示");
                }
                else
                {
                    MessageBox.Show("材料" + comboBox2.Text.Trim() + "不需要归还！", "提示");
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.DataSource = null;
            comboBox4.SelectedIndex = -1;
            comboBox4.Items.Clear();
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            conn.Open();
            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct MSNO from BO WHERE MSLNO = '" + comboBox3.Text + "'", conn);
            da.Fill(ds1);
            comboBox4.DataSource = ds1.Tables[0].DefaultView;
            comboBox4.DisplayMember = "MSNO";
            conn.Close();
            comboBox4.SelectedIndex = -1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
            if (comboBox3.Text.Trim() == "")
            {
                MessageBox.Show("实验室编号为空！", "提示");
            }
            else
            {
                if (comboBox4.Text.Trim() == "")
                {
                    MessageBox.Show("材料编号为空！", "提示");
                }
                else
                {
                    string labid = comboBox3.Text.Trim();//实验室编号
                    string material = comboBox4.Text.Trim();//材料编号
                    int num = Convert.ToInt32(numericUpDown2.Value.ToString().Trim());//材料数量

                    //获取材料数量
                    SqlCommand cmd4 = new SqlCommand("select BONU from BO where MSNO = '" + material + "' AND MSLNO = '" + labid + "' AND STNO = '" + login.id + "'", conn);
                    SqlCommand cmd5 = new SqlCommand("select BODA from BO where MSNO = '" + material + "' AND MSLNO = '" + labid + "' AND STNO = '" + login.id + "'", conn);
                    SqlCommand cmd6 = new SqlCommand("select MSNU from MS where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                    SqlCommand cmd9 = new SqlCommand("select count(*) from MS where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                    SqlCommand cmd11 = new SqlCommand("select CODE from BO where MSNO = '" + material + "' AND MSLNO = '" + labid + "' AND STNO = '" + login.id + "'", conn);
                    conn.Open();
                    int orinum;
                    int b = (int)cmd9.ExecuteScalar();
                    string code = cmd11.ExecuteScalar().ToString();
                    SqlDataReader dr = cmd5.ExecuteReader();
                    dr.Read();
                    string borrday = dr[0].ToString().Trim();
                    dr.Dispose();
                    cmd5.Dispose();
                    int c = (int)cmd4.ExecuteScalar();
                    if (b == 0)
                    {
                        orinum = 0;
                    }
                    else
                    {
                        SqlDataReader dr1 = cmd6.ExecuteReader();
                        dr1.Read();
                        orinum = Convert.ToInt32(dr1[0].ToString());
                        dr1.Dispose();
                    }
                    conn.Close();
                    if (orinum > 0)
                    {
                        if (c >= num)
                        {
                            conn.Open();
                            int res = c - num;
                            if (res == 0)
                            {
                                int x = orinum + num;
                                SqlCommand cmd2 = new SqlCommand("delete from BO where MSNO = '" + material + "' AND MSLNO = '" + labid + "' AND BONU = '" + num + "' AND STNO = '" + login.id + "'AND CODE = '" + code + "'", conn);
                                SqlCommand cmd3 = new SqlCommand("update RC set RTDA ='" + login.today + "'where MSNO = '" + material + "' AND MSLNO = '" + labid + "' AND BONU = '" + num + "' AND STNO = '" + login.id + "'", conn);
                                SqlCommand cmd7 = new SqlCommand("update MS set MSNU = '" + x + "'where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                                try
                                {
                                    cmd2.ExecuteNonQuery();
                                    cmd3.ExecuteNonQuery();
                                    cmd7.ExecuteNonQuery();
                                    MessageBox.Show("材料归还成功！");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("操作失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                int x = orinum + num;
                                SqlCommand cmd2 = new SqlCommand("update BO set BONU = '" + res + "'where STNO = '" + login.id + "' AND MSLNO = '" + labid + "' AND BODA = '" + borrday + "' AND STNO = '" + login.id + "'AND CODE = '" + code + "'", conn);
                                SqlCommand cmd7 = new SqlCommand("update MS set MSNU = '" + x + "'where MSNO = '" + material + "' AND MSLNO = '" + labid + "'", conn);
                                try
                                {
                                    cmd2.ExecuteNonQuery();
                                    cmd7.ExecuteNonQuery();
                                    MessageBox.Show("部分材料归还成功！");
                                    this.Hide();
                                    student form1 = new student();
                                    form1.Show();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("操作失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("材料数量最多为" + c + "，请重新填写！", "提示");
                            numericUpDown2.Text = c.ToString();
                        }
                    }
                    else
                    {
                        if (c >= num)
                        {
                            conn.Open();
                            int res = c - num;
                            if (res == 0)
                            {
                                int x = orinum + num;
                                SqlCommand cmd2 = new SqlCommand("delete from BO where MSNO = '" + material + "' AND MSLNO = '" + labid + "' AND BONU = '" + num + "' AND STNO = '" + login.id + "'", conn);
                                SqlCommand cmd3 = new SqlCommand("update RC set RTDA ='" + login.today + "'where MSNO = '" + material + "' AND MSLNO = '" + labid + "' AND BONU = '" + num + "' AND STNO = '" + login.id + "'", conn);
                                SqlCommand cmd7 = new SqlCommand("insert into MS(MSNO,MSNU,MSLNO,MSDP) values ('" + material + "','" + x + "','" + labid + "','" + 1 + "')", conn);
                                try
                                {
                                    cmd2.ExecuteNonQuery();
                                    cmd3.ExecuteNonQuery();
                                    cmd7.ExecuteNonQuery();
                                    MessageBox.Show("材料归还成功！");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("操作失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                int x = orinum + num;
                                SqlCommand cmd2 = new SqlCommand("update BO set BONU = '" + res + "'where STNO = '" + login.id + "' AND MSLNO = '" + labid + "' AND BONU = '" + c + "' AND STNO = '" + login.id + "'", conn);
                                SqlCommand cmd3 = new SqlCommand("insert into RC(STNO,MSLNO,MSNO,BONU,BODA,RTDA) values ('" + login.id + "','" + labid + "','" + material + "','" + num + "','" + borrday + "','" + login.today + "')", conn);
                                SqlCommand cmd7 = new SqlCommand("insert into MS(MSNO,MSNU,MSLNO,MSDP) values ('" + material + "','" + x + "','" + labid + "','" + 1 + "')", conn);
                                try
                                {
                                    cmd2.ExecuteNonQuery();
                                    cmd3.ExecuteNonQuery();
                                    cmd7.ExecuteNonQuery();
                                    MessageBox.Show("部分材料归还成功！");
                                    this.Hide();
                                    student form1 = new student();
                                    form1.Show();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("操作失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("材料数量最多为" + c + "，请重新填写！", "提示");
                            numericUpDown2.Text = c.ToString();
                        }
                    }
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            comboBox4.DataSource = null;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            this.numericUpDown2.DecimalPlaces = 0;
            this.numericUpDown2.Value = Decimal.Round(1, 0);
            returnday = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");

            SqlCommand cmd6 = new SqlCommand("select count(*) from BO where (" + Convert.ToInt32(login.today) + "-RTDA)>='" + 0 + "' AND STNO = '" + login.id + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd6;
            int getw = (int)cmd6.ExecuteScalar();
            if (MessageBox.Show("确认删除？", "提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("最后一次确认删除？", "提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (getw > 0)
                    {
                        MessageBox.Show("您有" + getw + "条已过期未还材料记录，请及时归还材料后进行注销操作！", "提示");
                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("delete from ST where STNO = '" + login.id + "'", conn);
                        SqlCommand cmd2 = new SqlCommand("delete from BO where STNO = '" + login.id + "'", conn);
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("注销账户成功", "提示");
                        this.Hide();
                        login form1 = new login();
                        form1.Show();
                    }
                }
            }
            conn.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

    }
}