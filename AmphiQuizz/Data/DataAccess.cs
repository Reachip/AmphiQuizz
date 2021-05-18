﻿using System;
using System.Data.SqlClient;

namespace AmphiQuizz
{
    /// <summary>
    /// DataAccess permet d'accéder aux données de la BDD via une requête SQL.
    /// </summary>
    public class DataAccess
    {

        /// <summary>
        /// L'interface de communication avec la base de données Microsoft
        /// </summary>
        public SqlConnection Connection { get; private set; }

        /// <summary>
        /// Constructeur principal de classe
        /// </summary>
        public DataAccess() {
            Connection = new SqlConnection();
            Connection.ConnectionString = "Data Source=srv-jupiter.iut-acy.local; Initial Catalog=BT10; Integrated Security=SSPI;";
        }

        /// <summary>
        /// Ouvre une connexion à la BDD.
        /// </summary>
        public bool OpenConnection()
        {  
            Connection.Open();

            if (Connection.State.Equals(System.Data.ConnectionState.Open))
            {
                Connection.Close();
                return true;
            }

            return false;
        }


        /// <summary>
        /// Récupère le résultat d'une requête SQL passée en paramètre.
        /// </summary>
        public SqlDataReader GetData(string queryString)
        {
            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Connection.Open();
            command.CommandTimeout = 120;

            return command.ExecuteReader();
        }

        /// <summary>
        /// Insère des données une fonctions d'une requête SQL passée en paramètre.
        /// </summary>
        public void InsertData(string queryString)
        {
            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
        
        /// <summary>
        /// Ferme la connexion à la BDD.
        /// </summary>
        public void CloseConnection() => Connection.Close();
    }
}