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
    public partial class Form4 : Form
    {
        private SQLiteConnection DB;
        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();

            string ItemName = textBox1.Text;
            string Login = textBox2.Text;
            string Phone = textBox3.Text;

            if (Login != "" && ItemName != "" && Phone != "")
            {
                SQLiteCommand insert = new SQLiteCommand($"INSERT INTO [{Table_Orders.main}] (ItemName, Login, Phone)" + $"VALUES (@ItemName,@Login, @Phone)", DB);
                insert.Parameters.AddWithValue("ItemName", ItemName);
                insert.Parameters.AddWithValue("Login", Login);
                insert.Parameters.AddWithValue("Phone", Phone);
                await insert.ExecuteNonQueryAsync();
                MessageBox.Show("Вы успешно оформили заказ", "Заказ", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Form4_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM Items", DB);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
