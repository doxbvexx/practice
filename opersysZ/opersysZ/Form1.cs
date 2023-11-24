using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace opersysZ
{
    public partial class Form1 : Form
    {
        private SQLiteConnection DB;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM Items", DB);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM Orders", DB);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM Storage", DB);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string Price = textBox2.Text;

            if (ID != "" && Price != "")
            {
                SQLiteCommand update = new SQLiteCommand($"UPDATE Items SET Price = '{Price}' WHERE ID = '{ID}'", DB);
                await update.ExecuteNonQueryAsync();
                MessageBox.Show("Обновлено");
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT UserID,MAX(PricePerOne) FROM Resources", DB);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string ItemAmount = textBox2.Text;

            if (ID != "" && ItemAmount != "")
            {
                SQLiteCommand update = new SQLiteCommand($"UPDATE Storage SET Amount = '{ItemAmount}' WHERE ID = '{ID}'", DB);
                await update.ExecuteNonQueryAsync();
                MessageBox.Show("Обновлено");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT NameProcess,Priority,Resource\r\nFROM Processes, Task \r\nWHERE Priority > 2\r\nGROUP BY NameProcess,Priority,Resource", DB);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit ();
        }
    }
}
