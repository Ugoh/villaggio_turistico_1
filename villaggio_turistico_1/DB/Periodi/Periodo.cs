using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ClassiVillaggioTuristico.db.Periodi
{
    class Periodo
    {
        #region Static
        /// <summary>
        /// Inserisce un periodo nel database
        /// Version 0.1
        /// </summary>
        /// <param name="nome"> dare un nome al periodo es.:Alta stagione </param>
        /// <param name="inizio">Mese in numero di inizio es.: 04 </param>
        /// <param name="fine"> Mese in numero di fine es.: 08 </param>
        /// <param name="aumento"> percentuale di aumento dei prezzi</param>
        public static bool AddPeriodo(MySqlConnection con, string nome, string inizio, string fine, string aumento)
        {
            try
            {
                new MySqlCommand($"insert into periodo(nome , inizio, fine , aumento) values('{nome}','{inizio}','{fine}','{aumento}')", con).ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Metodo per scaricare i periodi dal database
        /// version 0.1
        /// </summary>
        /// <param name="con"></param>
        /// <returns>Lista di Periodo</returns>
        public static List<Periodo> GetPeriodi(MySqlConnection con)
        {
            List<Periodo> periodi = new List<Periodo>();
            var dr = new MySqlCommand("select * from periodo",con).ExecuteReader();

            while(dr.Read())
            {
                periodi.Add(new Periodo((string)dr["nome"] , (string) dr["inizio"] , (string)dr["fine"] , (string)dr["aumento"] ));
            }

            return periodi;
        }
        #endregion

        string nome;
        string inizio;
        string fine;
        string aumento;

        public string Nome { get { return nome; } }
        public string Inizio { get { return inizio; } }
        public string Fine { get { return fine; } }
        public string Aumento { get { return aumento; } }

        public Periodo(string nome , string inizio , string fine , string aumento)
        {
            this.aumento = aumento;
            this.nome = nome;
            this.inizio = inizio;
            this.fine = fine;
        }
    }
}
