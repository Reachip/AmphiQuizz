using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmphiQuizz
{
    /// <summary>
    /// ApplicationData récupère l'ensemble des données
	/// essentiel au bon fonctionnement de l'application.
    /// </summary>
    public class ApplicationData
    {
        /// <summary>
        /// L'ensemble des élèves
        /// </summary>
        public static List<Eleve> ListeEleves { get; internal set; }
        /// <summary>
        /// L'ensemble des professeurs
        /// </summary>
        public static List<Professeur> ListeProfesseurs { get; internal set; }

        /// <summary>
        /// L'ensemble des groupes
        /// </summary>
        public static List<Groupe> ListeGroupes { get; internal set; }

        /// <summary>
        /// L'ensemble des notes des élèves
        /// </summary>
        public static List<Note> ListeNotesEleves { get; internal set; }

        /// <summary>
        /// L'ensemble des notes que peuvent appliquer les professeurs à un élève
        /// </summary>
        public static List<Note> ListeNotes { get; internal set; }

        /// <summary>
        /// LoadApplicationData charge en mémoire
		/// l'ensemble des données se trouvant dans
		/// la base de données dans les propriétées
		/// statiques de la classe.
        /// </summary>
        public static void LoadApplicationData()
        {   
            Eleve eleve = new Eleve();
            Professeur professeur = new Professeur();
            Groupe groupe = new Groupe();
            Note note = new Note();

            ListeEleves = eleve.FindAll();
            ListeProfesseurs = professeur.FindAll();
            ListeGroupes = groupe.FindAll();
            ListeNotesEleves = note.FindAll();
            ListeNotes = new List<Note> {
                new Note(SignificationNote.ABSENT),
                new Note(SignificationNote.REPONSE_FAUSSE),
                new Note(SignificationNote.BONNE_REPONSE),
            };
        }
    }
}
