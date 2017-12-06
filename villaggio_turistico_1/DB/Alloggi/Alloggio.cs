using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ClassiVillaggioTuristico.db.Alloggi
{
    class Alloggio
    {
#region Static
        #region AddAlloggio
        /// <summary> 
        /// Aggiungere un nuovo alloggio
        /// al database
        /// </summary>
        public static bool AddAlloggio(MySqlConnection con , string nome , int tipo_id)
                {
                    try
                    {
                        new MySqlCommand( $"insert into alloggio(nome,tipo_id) VALUES ('{nome}','{tipo_id}') " , con ).ExecuteNonQuery();
                    }
                    catch
                    {
                        return false;
                    }

                    return true;
                }
                #endregion

        #region GetAlloggi
        ///<param>
        ///Restituisce la lista con tutti gli alloggi
        /// </param>
        public static List<Alloggio> GetAlloggi(MySqlConnection con)
        {
            List<Alloggio> alloggi = new List<Alloggio>();

            MySqlDataReader dr = new MySqlCommand("select alloggio.id as idalloggio, alloggio.nome as nomealloggio , tipo.* from alloggio inner join tipo on alloggio.tipo_id=tipo.id", con).ExecuteReader();
            while(dr.Read())
            {
                int alloggioid = (int)dr["idalloggio"];
                string nomealloggio = (string)dr["nomealloggio"];
                string nome = (string)dr["nome"];
                string costo = (string)dr["costo"];
                int posti = (int)dr["posti"];

                Tipo t = new Tipo(nome, costo, posti);
                alloggi.Add(new Alloggio(alloggioid, nomealloggio, t));
            }

            dr.Close();

            return alloggi;
        }
        #endregion
        #endregion

        string nome;
        Tipo type;
        int id;
        public string Nome { get { return nome; } }
        public Tipo Type { get { return type; } }

        public Alloggio(int id , string nome , Tipo type )
        {
            this.id = id;
            this.type = type;
            this.nome = nome;
        }
    }


    class Tipo
    {
#region static
        #region AddTipo
        /// <summary> 
        /// Aggiungere un nuovo tipo di alloggio
        /// al database
        /// </summary>
        public static bool AddTipo(MySqlConnection con, string nome, string costo, int posti)
        {
            try
            {
                new MySqlCommand($"insert into tipo(nome,costo,posti) VALUES ('{nome}','{costo}' , '{posti}') ", con).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        #endregion
        #region GetTipo
            public List<Tipo> GetTypes(MySqlConnection con)
            {
                List<Tipo> tipo = new List<Tipo>();
                MySqlDataReader dr = new MySqlCommand("select * from tipo", con).ExecuteReader();
                while(dr.Read())
                {
                    string nome = (string)dr["nome"];
                    string costo = (string)dr["costo"];
                    int posti = (int)dr["posti"];
                    tipo.Add(new Tipo(nome, costo, posti));
                }
                dr.Close();
            return tipo;
            }
            #endregion
#endregion

        string nome;
        string costo;
        int posti;
        public string Nome { get { return nome; } }
        public string Costo { get { return costo; } }
        public int Posti { get { return posti; } }

        public Tipo( string nome, string costo , int posti )
        {
            this.nome = nome;
            this.posti = posti;
            this.costo = costo;
        }
    }


}
