using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace opersysZ
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
    static class DataBase
    {
        public static string ConnectionString = @"Data Source=shop.db; Integrated Security=False; MultipleActiveResultSets=True";
    }

    static class Table_Items
    {
        public static string main = "Items";
        public static string ID = "ID";
        public static string ItemName = "ItemName";
        public static string Price = "Price";
    }
    static class Table_Orders
    {
        public static string main = "Orders";
        public static string ID = "ID";
        public static string ItemName = "ItemName";
        public static string Login = "Login";
        public static string Phone = "Phone";
    }
    static class Table_Storage
    {
        public static string main = "Storage";
        public static string ID = "ID";
        public static string ItemName = "ItemName";
        public static string Amount = "Amount";
    }
    static class Table_Users
    {
        public static string main = "Users";
        public static string ID = "ID";
        public static string Login = "Login";
        public static string Password = "Password";
        public static string Role = "Role";
    }
}
