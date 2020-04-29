using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sale_Inventory_system
{
    class Myconnection
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection() { ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\Database.mdf'; Integrated Security = True" };
        }
    }
}
