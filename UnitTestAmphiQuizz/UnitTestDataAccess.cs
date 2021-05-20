using AmphiQuizz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace UnitTestAmphiQuizz
{
    /// <summary>
    /// Description résumée pour UnitTestDataAccess
    /// </summary>
    [TestClass]
    public class UnitTestDataAccess
    {
        DataAccess DataAccess;

        /// <summary>
        /// Test en initialisant une DataAccess
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            DataAccess = new DataAccess();
        }

        /// <summary>
        /// Test de la méthode OpenConnection pour tester si la connexion a bien été effectuée 
        /// </summary>
        [TestMethod]
        public void TestOpenConnection()
        {
            Assert.IsTrue(DataAccess.OpenConnection());
        }

        /// <summary>
        /// Test de la méthode GetData pour tester si l'on a accès en lecture à la base de données 
        /// </summary>
        [TestMethod]
        public void TestGetData()
        {
            var tables = new string[] { "eleve", "professeur", "groupe", "note" };

            foreach (string table in tables)
            {
                DataAccess = new DataAccess();
                SqlDataReader reader = DataAccess.GetData($"select * from [IUT-ACY\\ancell].{table}");
                Assert.IsTrue(reader.Read());


                DataAccess.CloseConnection();
                reader.Close();
            }
        }

        /// <summary>
        /// Test de la méthode CloseConnection pour tester si l'on arrive bien à se déconnecter de la base de données
        /// </summary>
        [TestMethod]
        public void TestCloseConnection()
        {
            DataAccess.CloseConnection();
            Assert.AreEqual("Closed", $"{DataAccess.Connection.State}");
        }
    }
}
