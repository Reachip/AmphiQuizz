
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmphiQuizz
{
    /// <summary>
    /// Représente une personne tel qu'un élève ou un professeur (voir les classes Professeur et Eleve)
    /// </summary>
    #pragma warning disable CS0659 // Le type se substitue à Object.Equals(object o) mais pas à Object.GetHashCode()
    public abstract class Personne
    #pragma warning restore CS0659 // Le type se substitue à Object.Equals(object o) mais pas à Object.GetHashCode()
    {
        /// <summary>
        /// Nom de la personne
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identifiant de la personne dans la base de données
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Nom de famille de la personne
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="number"></param>
        public Personne(string name, string surname, int number)
        {
            Number = number;
            Name = name;
            Surname = surname;
        }

        public Personne() {}

        /// <summary>
        /// Compare deux personnes en fonction du nom et du prénom
        /// </summary>
        /// <param name="obj">Un objet qui hérite de Personne</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            try
            {
                Personne personne = (Personne)obj;

                if (personne != null && personne.Surname != null && personne.Name != null)
                    return personne.Name == Name && personne.Surname == Surname;

                return false;
            }

            catch(Exception)
            {
                return false;
            }
        }
    }
}
