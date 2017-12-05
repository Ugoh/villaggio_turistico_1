using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kone
{
    public class Connessione
    {
        private SqlConnection myConn;

        public Connessione(string strConnessione)
        {
            myConn = new SqlConnection(strConnessione);
        }

        public SqlConnection GetConnessione() => myConn;

        public string Apri()
        {
            try
            {
                myConn.Open();
                return "ok";
            }
            catch (SqlException ex)
            {
                return ex.ToString();
            }
        }

        public void Chiudi()
        {
            myConn.Close();
        }
    }
}
