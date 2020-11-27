using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TicariOtomasyon
{
    class SqlConnect_
    {
        public SqlConnection Connect_()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7DOUM90;Initial Catalog=DboTicariOtomasyon;Integrated Security=True");
            con.Open();
            return con;
        }
    }
}
