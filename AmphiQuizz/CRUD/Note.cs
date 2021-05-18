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
    /// Représente une note appliquée à un élève par un professeur
    /// </summary>
    public class Note : ICrud<Note>
    {
        /// <summary>
        /// La note de l'étudiant en question
        /// </summary>
        public int StudentNote { get; private set; }

        /// <summary>
        /// Date à laquelle la note a été crée
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Le professeur ayant appliqué une note à l'élève
        /// </summary>
        public Professeur Teacher { get; set; }

        /// <summary>
        /// Le libellé de la note
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// L'étudiant noté
        /// </summary>
        public Eleve Student { get; set; }

        /// <summary>
        /// Constructeur de la classe afin de procéder à l'insertion d'une note.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="studentNote"></param>
        /// <param name="teacher"></param>
        /// <param name="student"></param>
        public Note(DateTime date, int studentNote, Professeur teacher, Eleve student)
        {
            Date = date;
            StudentNote = studentNote;
            Student = student;
            Teacher = teacher;
        }

        /// <summary>
        /// Constructeur permettant d'afficher le libelle et l'indice de la note dans l'application WPF 
        /// </summary>
        /// <param name="noteMeaning">La signification de la note : Bonne réponse, mauvaise réponse ou élève absent</param>
        public Note(SignificationNote noteMeaning)
        {
            StudentNote = (int)noteMeaning;
            

            if (StudentNote == 0)
            {
                Comment = "élève absent";
            }

            else if (StudentNote == 1)
            {
                Comment = "réponse fausse";
            }

            else
            {
                Comment = "bonne réponse";
            }
        }

        /// <summary>
        /// Constructeur principal de la classe
        /// </summary>
        public Note() {}

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public void Create()
        {
            string insertQuery = $"INSERT INTO [IUT-ACY\\ancell].note VALUES ({Teacher.Number}, {Student.Number}, '{Date}', {StudentNote});";
            DataAccess dataAccess = new DataAccess();

            dataAccess.InsertData(insertQuery);
            dataAccess.CloseConnection();
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
        public List<Note> FindAll()
        {
            List<Note> notes = new List<Note>();
            DataAccess dataAccess = new DataAccess();

            SecureDataAccessReader secureDataAccess = new SecureDataAccessReader(dataAccess);
            SqlDataReader reader = secureDataAccess.GetSecureReaderFor("note");


            while (reader.Read())
            {
                Professeur professeurCRUD = new Professeur();
                Eleve eleveCRUD = new Eleve();
                Note note = new Note(reader.GetDateTime(2), reader.GetInt32(3), professeurCRUD.Find($"NUMERO_PROFESSEUR = {reader.GetInt32(0)}"), eleveCRUD.Find($"NUMERO_ELEVE = {reader.GetInt32(1)}"));
                notes.Add(note);
            }

            secureDataAccess.CloseAll();
            return notes;
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public List<Note> FindBySelection(string criteres)
        {
            List<Note> notes = new List<Note>();
            SecureDataAccessReader secureDataAccess = new SecureDataAccessReader(new DataAccess());
            SqlDataReader reader = secureDataAccess.GetSecureReaderFor("note", criteres);

           
            while (reader.Read())
            {
                Professeur professeurCRUD = new Professeur();
                Eleve eleveCRUD = new Eleve();
                Note note = new Note(reader.GetDateTime(2), reader.GetInt32(3), professeurCRUD.Find($"NUMERO_PROFESSEUR = {reader.GetInt32(3)}"), eleveCRUD.Find($"NUMERO_ELEVE = {reader.GetInt32(0)}"));

                notes.Add(note);
            }

            secureDataAccess.CloseAll();
            return notes;
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public Note Find(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
