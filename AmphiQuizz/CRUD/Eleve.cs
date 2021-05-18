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
    /// Représente un élève
    /// </summary>
    public class Eleve : Personne, ICrud<Eleve>
    {
        public List<Note> Notes { get; set; }
        public string ImagePath { get; set; }
        public Groupe Groupe { get; set; }

        /// <summary>
        /// Constructeur principal
        /// </summary>
        public Eleve() {}

        /// <summary>
        /// Constructeur de la classe permettant l'insertion des données dans la base de données
        /// </summary>
        /// <param name="numero">ID de l'élève dans la base de données</param>
        /// <param name="name">Prénom de l'élève</param>
        /// <param name="surname">Nom de l'élève</param>
        /// <param name="groupe">Groupe de l'élève</param>
        /// <param name="imagePath">Nom du fichier d'image de l'élève, typiquement : NMERO_ETUDIANT.jpg</param>
        public Eleve(int numero, string name, string surname, Groupe groupe, string imagePath) : base(name, surname, numero)
        {
            Groupe = groupe;
            ImagePath = imagePath;
            Notes = new List<Note>();
        }

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
        public List<Eleve> FindAll()
        {
            List<Eleve> studentList = new List<Eleve>();
            SecureDataAccessReader secureDataAccess = new SecureDataAccessReader(new DataAccess());
            SqlDataReader reader = secureDataAccess.GetSecureReaderFor("eleve");


            while (reader.Read())
            {
                Groupe groupeCRUD = new Groupe();
                Groupe groupe = groupeCRUD.Find($"N_GROUPE = {reader.GetInt32(1)}");

                Eleve eleve = new Eleve(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), groupe, reader.GetString(4));
                studentList.Add(eleve);
            }

            secureDataAccess.CloseAll();
            return studentList;
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public List<Eleve> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public Eleve Find(string criteres)
        {
            SecureDataAccessReader secureDataAccess = new SecureDataAccessReader(new DataAccess());
            SqlDataReader reader = secureDataAccess.GetSecureReaderFor("eleve", criteres);


            while (reader.Read())
            {
                Groupe groupeCRUD = new Groupe();
                Groupe groupe = groupeCRUD.Find($"N_GROUPE = {reader.GetInt32(1)}");

                Eleve student = new Eleve(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), groupe, reader.GetString(4));
                secureDataAccess.CloseAll();
                return student;
            }

            return null;
        }
    }
}
