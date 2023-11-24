using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opersysZ
{
    public partial class Form2 : Form
    {
        private SQLiteConnection DB;
        public Form2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();

            string Login = textBox1.Text;
            string Password = textBox2.Text;

            if (Login != "" && Password != "")
            {
                SQLiteDataReader read;
                SQLiteCommand commandRead = new SQLiteCommand($"SELECT * FROM [{Table_Users.main}] WHERE {Table_Users.Login}=@Login AND {Table_Users.Password}=@Password", DB);
                commandRead.Parameters.AddWithValue("Login", Login);
                commandRead.Parameters.AddWithValue("Password", Password);
                read = (SQLiteDataReader)await commandRead.ExecuteReaderAsync();
                if (await read.ReadAsync())
                {
                    if (read[$"{Table_Users.Role}"].ToString() == "Admin")
                    {
                        Form1 Главное = new Form1();
                        Главное.Show();
                        this.Hide();
                    }
                    if (read[$"{Table_Users.Role}"].ToString() == "User")
                    {
                        Form4 Главное = new Form4();
                        Главное.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                read.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 Регистрация = new Form3();
            Регистрация.Show();
            this.Hide();
        }
    }
}
