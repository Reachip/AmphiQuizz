using AmphiQuizz;
using AmphiQuizz.data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace UnitTestAmphiQuizz
{
    /// <summary>
    /// Description résumée pour UnitTestSecureDataAccessReader
    /// </summary>
    [TestClass]
    public class UnitTestSecureDataAccessReader
    {
        public SecureDataAccessReader SecureDataAccess { get; set; }


        /// <summary>
        /// Initiasise uen SecureDataAccessReader
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            SecureDataAccess = new SecureDataAccessReader(new DataAccess());
        }


        /// <summary>
        /// Test de la méthode GetSecureReaderFor en testant si la méthode retourne null si l'assertion SQL 
        /// et incorrecte et un objet de type SqlDataReader si l'assertion SQL est correcte
        /// </summary>
        [TestMethod]
        public void TestMethodGetSecureReaderFor()
        {
           SqlDataReader reader;

           reader = SecureDataAccess.GetSecureReaderFor("note", "champ_inconnu=-404");
           Assert.AreEqual(null, reader);

            SecureDataAccess.CloseAll();

            reader = SecureDataAccess.GetSecureReaderFor("professeur", "NUMERO_PROFESSEUR=1");
            Assert.IsTrue(reader is SqlDataReader);
        }

        /// <summary>
        /// Test de la méthode GetSecureReader dans le cas ou l'assertion SQL est incorrecte
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethodGetSecureReaderForNotClosed()
        {
            SecureDataAccess.GetSecureReaderFor("note", "champ_inconnu=-404");
            SecureDataAccess.GetSecureReaderFor("professeur", "NUMERO_PROFESSEUR=1");
        }
    }
}
