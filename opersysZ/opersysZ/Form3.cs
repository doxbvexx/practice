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
    public partial class Form3 : Form
    {
        private SQLiteConnection DB;
        public Form3()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();

            string Login = textBox1.Text;
            string Password = textBox2.Text;
            string Role = "User";
            
            if(Login != "" && Password != "")
            {
                SQLiteCommand insert = new SQLiteCommand($"INSERT INTO [{Table_Users.main}] (Login, Password, Role)" + $"VALUES (@Login,@Password, @Role)", DB);
                insert.Parameters.AddWithValue("Login", Login);
                insert.Parameters.AddWithValue("Password", Password);
                insert.Parameters.AddWithValue("Role", Role);
                await insert.ExecuteNonQueryAsync();
                MessageBox.Show("Вы успешно зарегистрированы", "Регистрация", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 Авторизация = new Form2();
            Авторизация.Show();
            this.Hide();
        }
    }
}
