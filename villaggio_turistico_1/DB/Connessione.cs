using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kone.DB
{
    /// <summary>
    /// Stabilisce connessione col DataBase -Godae
    /// </summary>
    public class Connessione
    {
        private SqlConnection myConn;

        /// <summary>
        /// Crea la SqlConnection
        /// </summary>
        /// <param name="strConnessione">Stringa di connessione completa</param>
        public Connessione(string strConnessione)
        {
            myConn = new SqlConnection(strConnessione);
        }

        /// <summary>
        /// Ritorna la SqlConnection
        /// </summary>
        public SqlConnection GetConnessione() => myConn;

        /// <summary>
        /// Apre la connessione
        /// </summary>
        /// <returns>Messaggio di errore ("ok" se tutto ok)</returns>
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

        /// <summary>
        /// Chiude la connessione
        /// </summary>
        public void Chiudi()
        {
            myConn.Close();
        }
    }
}
