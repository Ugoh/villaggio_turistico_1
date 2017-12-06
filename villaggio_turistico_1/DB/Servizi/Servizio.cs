using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ClassiVillaggioTuristico.db.Servizi
{
    class Servizio
    {
        #region Static
            #region AddServizio
        /// <summary>
        /// inserisce un servizio nel database
        /// </summary>
        /// <returns></returns>
            public static bool AddServizio(MySqlConnection con , string nome, string costo , string descrizione )
            {
                try
                {
                    new MySqlCommand($"insert into servizi(nome,costo,descrizione) values ('{nome}','{costo}','{descrizione}') ", con).ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            return true;
            }
        #endregion

        #region GetServizi
        /// <summary>
        /// Restituisce la lista con i servizi
        /// </summary>
        public static List<Servizio> GetServizi(MySqlConnection con)
        {
            List<Servizio> servizi = new List<Servizio>();

            MySqlDataReader dr = new MySqlCommand("select * from servizi",con).ExecuteReader();

            while(dr.Read())
            {
                servizi.Add(new Servizio((string)dr["nome"], (string)dr["costo"], (string)dr["descrizione"]));
            }

            dr.Close();

            return servizi;
        }
        #endregion
        #endregion

        string nome;
        string costo;
        string descrizione;
        public string Nome { get { return nome; } }
        public string Costo { get { return costo; } }
        public string Descrizione { get { return descrizione; } }
        public Servizio(string nome ,string costo, string descrizione)
        {
            this.nome = nome;
            this.costo = costo;
            this.descrizione = descrizione;
        }
    }
}
