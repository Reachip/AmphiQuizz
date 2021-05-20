using System;
using System.Data.SqlClient;

namespace AmphiQuizz.data
{
    /// <summary>
    /// SecureDataAccessReader fournit une couche supplémentaire à
	/// DataAccess afin de fournir des méthodes qui assure la sécurité
	/// des transactions avec la base de données.
    /// </summary>
    public class SecureDataAccessReader
    {
        /// <summary>
        /// Une instance de DataAccess
        /// </summary>
        public DataAccess DataAccess { get; }

        /// <summary>
        /// L'objet chargé de lire les données retournées par DataAccess.GetData dans la méthode GetSecureReaderFor
        /// </summary>
        public SqlDataReader Reader { get; }


        /// <summary>
        /// Constructeur principal de classe
        /// </summary>
        /// <param name="dataAccess">Instance de DataAccess</param>
        public SecureDataAccessReader(DataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        /// <summary>
        /// Récupère une instance de SqlDataReader permettant de lire les
        /// données du table passé en paramètre avec une expression dans la
        /// clause where de la requête SQL.
        ///
        /// Cette méthode tente préalablement une ouverture sécurisé de la connection.
        /// Si cela n'est pas possible, la méthode retourne une exception de type
        /// OpenConnectionFailureException.
        /// </summary>
        /// <param name="table">Table dont on souhaite récupérer le lecteur</param>
        /// <param name="whereClause">Clause where de la requête</param>
        /// <returns>Retourne un objet chargé de lire la requête SQL ou null si la requête est incorrecte</returns>
        /// <exception cref="OpenConnectionFailureException">Invoqué si la connexion n'a pas pu s'ouvrir</exception>
        /// <exception cref="InvalidOperationException">Invoqué si la requête SQL est incorrecte</exception>
        public SqlDataReader GetSecureReaderFor(string table, string whereClause=null)
        {
            
            if (DataAccess.OpenConnection())
            {
                string query = $"select * from [IUT-ACY\\ancell].{table};";

                if (whereClause != null)
                    query = $"select * from [IUT-ACY\\ancell].{table} where {whereClause};";

                try
                {
                    SqlDataReader Reader = DataAccess.GetData(query);
                    return Reader;
                }

                catch (Exception)
                {
                    return null;
                }
                
            }

            else
                throw new OpenConnectionFailureException("");
        }

        /// <summary>
        /// Ferme toutes les connexions à la base de données.
        /// </summary>
        public void CloseAll()
        {
            if (Reader != null)
                Reader.Close();

            DataAccess.CloseConnection();
        }
    }


    /// <summary>
    /// Exception personnalisé permettant d'indiquer qu'on ne peut pas continuer, 
    /// étant donné que la connexion n'a pas été correctement ouverte.
    /// </summary>
    [Serializable]
    class OpenConnectionFailureException : Exception
    {
        /// <summary>
        /// Constrcuteur principal de l'exception
        /// </summary>
        public OpenConnectionFailureException() {}


        /// <summary>
        /// Constructeur de l'exception avec possibilité de fournir le nom de l'exception
        /// </summary>
        /// <param name="name">Nom de l'exception</param>
        public OpenConnectionFailureException(string name) : base($"Impossible d'ouvrir une connexion à la base de données: {name}") {}
    }
}
