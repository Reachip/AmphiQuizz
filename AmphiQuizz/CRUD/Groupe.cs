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
    /// Représente un groupe ayant plusieurs élèves.
    /// </summary>
    public class Groupe : ICrud<Groupe>
    {
        /// <summary>
        /// Le numéro de groupe 
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Le libelle du groupe (ex: Groupe A)
        /// </summary>
        public string Libelle { get; private set; }

        /// <summary>
        /// Boolean indiquant si le groupe a été sélectionné par l'utilisateur via l'interface graphique
        /// </summary>
        public bool IsSelected { get;  set; }

        /// <summary>
        /// Liste des élèves appartenant à un groupe
        /// </summary>
        public List<Eleve> Eleves { get; private set; }

        /// <summary>
        /// Constructeur par défaut de la classe
        /// </summary>
        /// <param name="numero">Numéro de groupe</param>
        /// <param name="libelle">Libellé du groupe</param>
        public Groupe(int numero, string libelle)
        {
            Number = numero;
            Libelle = libelle;
            Eleves = new List<Eleve>();
        }

        public Groupe() {}

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
        public List<Groupe> FindAll()
        {
            List<Groupe> listeGroupes = new List<Groupe>();
            SecureDataAccessReader secureDataAccess = new SecureDataAccessReader(new DataAccess());
            SqlDataReader reader = secureDataAccess.GetSecureReaderFor("groupe");

            while (reader.Read())
            {
                Groupe unGroupe = new Groupe(reader.GetInt32(0), reader.GetString(1));
                listeGroupes.Add(unGroupe);
            }


            secureDataAccess.CloseAll();
            return listeGroupes;
        }


        /// <summary>
        /// Voir l'interface ICrud
        /// </summary> 
        public List<Groupe> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir l'interface ICrud
        /// </summary>
        public Groupe Find(string criteres)
        {
            SecureDataAccessReader secureDataAccess = new SecureDataAccessReader(new DataAccess());
            SqlDataReader reader = secureDataAccess.GetSecureReaderFor("groupe", criteres);

          
            while (reader.Read())
            {
                Groupe groupe = new Groupe(reader.GetInt32(0), reader.GetString(1));
                return groupe;
            }

            secureDataAccess.CloseAll();
            return null;
        }


        /// <summary>
        /// Test l'égalité entre deux groupes en fonction du numéro de groupe
        /// </summary>
        /// <param name="obj">Objet de type Groupe</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Groupe other = (Groupe)obj;

            if (other != null)
            {
                if (other.Number == Number)
                    return true;
            }

            return false;
        }
    }
}
