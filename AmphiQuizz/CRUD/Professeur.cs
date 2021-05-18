using AmphiQuizz.data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmphiQuizz
{
    /// <summary>
    /// Représente un professeur
    /// </summary>
    public class Professeur : Personne, ICrud<Professeur>
    {
        public bool IsSelected { get; set; }

        /// <summary>
        /// Constructeur principal de la classe
        /// </summary>
        public Professeur() {}


        /// <summary>
        /// Constructeur de la classe afin de procéder à l'insertion d'un professeur.
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        public Professeur(int numero, string nom, string prenom) : base(nom, prenom, numero) {}

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public void Create()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public void Delete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public Professeur Find(string criteres)
        {
            SecureDataAccessReader secureDataAccess = new SecureDataAccessReader(new DataAccess());
            SqlDataReader reader = secureDataAccess.GetSecureReaderFor("professeur", criteres);

           
            while (reader.Read())
            {
                Professeur professeur = new Professeur(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                return professeur;
            }

            secureDataAccess.CloseAll();
            return null;
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public List<Professeur> FindAll()
        {
            List<Professeur> listeProfesseur = new List<Professeur>();
            SecureDataAccessReader secureDataAccess = new SecureDataAccessReader(new DataAccess());
            SqlDataReader reader = secureDataAccess.GetSecureReaderFor("professeur");

           
            while (reader.Read())
            {
                Professeur professeur = new Professeur(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)); 
                listeProfesseur.Add(professeur);
            }

            secureDataAccess.CloseAll();
            return listeProfesseur;
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public List<Professeur> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public void Read()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
