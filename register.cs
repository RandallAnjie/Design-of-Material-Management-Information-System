using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 大学实验材料管理信息系统数据库设计
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox8.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox8.Text)
            {
                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
                String sql = $"select count(*) from ST where STNO='{this.textBox2.Text}'";
                SqlCommand cmd1 = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd1;
                conn.Open();
                //查询返回结果
                int result = (int)cmd1.ExecuteScalar();
                if (result == 0)
                {
                    if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox8.Text.Trim() != "")   //判断文本框是否全部都是空
                    {
                        //插入文本框中输入的数据到数据库中
                        String sqlStr = "insert into ST(STNA,STNO,STKE) values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "')";
                        SqlCommand cmd = new SqlCommand(sqlStr, conn);
                        try//异常处理
                        {
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            if ((int)MessageBox.Show("注册成功，是否直接登录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == 1)
                            {
                                login.id = textBox2.Text.Trim();
                                this.Hide();
                                student form1 = new student();
                                form1.Show();
                            }
                            else
                            {
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox8.Text = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("注册失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("存在文本框为空！");
                    }
                }
                else
                {
                    if ((int)MessageBox.Show("学号已经存在，是否跳转登录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == 1)
                    {
                        login.id = textBox2.Text.Trim();
                        this.Hide();
                        login form1 = new login();
                        form1.Show();
                    }
                    else
                    {
                        textBox2.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("两次输入密码不一致！");
                textBox8.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim() == textBox9.Text.Trim())
            {
                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection("  Initial Catalog=大学实验材料管理信息系统数据库; Integrated Security=True ");
                String sql = $"select count(*) from ST where STNO='{this.textBox2.Text}'";
                SqlCommand cmd1 = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd1;
                conn.Open();
                //查询返回结果
                int result = (int)cmd1.ExecuteScalar();
                if (result == 0)
                {
                    if (textBox7.Text.ToString().Trim() == "admin")
                    {
                        if (textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox9.Text.Trim() != "")   //判断文本框是否全部都是空
                        {
                            //插入文本框中输入的数据到数据库中
                            String sqlStr = "insert into AD(ADNA,ADNO,ADKE) values ('" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "')";
                            SqlCommand cmd = new SqlCommand(sqlStr, conn);
                            try//异常处理
                            {
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                if ((int)MessageBox.Show("注册成功，是否直接登录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == 1)
                                {
                                    login.id = textBox5.Text.Trim();
                                    this.Hide();
                                    Admin form1 = new Admin();
                                    form1.Show();
                                }
                                else
                                {
                                    textBox4.Text = "";
                                    textBox5.Text = "";
                                    textBox6.Text = "";
                                    textBox7.Text = "";
                                    textBox9.Text = "";
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("注册失败！失败原因：" + ex.Message.ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("存在文本框为空！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("验证码错误！");
                    }
                }
                else
                {
                    if ((int)MessageBox.Show("工号已经存在，是否跳转登录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == 1)
                    {
                        login.id = textBox5.Text.Trim();
                        this.Hide();
                        login form1 = new login();
                        form1.Show();
                    }
                    else
                    {
                        textBox5.Text = "";
                    }
                }

            }
            else
            {
                MessageBox.Show("两次输入密码不一致！");
                textBox8.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            login form1 = new login();
            form1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            login form1 = new login();
            form1.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
