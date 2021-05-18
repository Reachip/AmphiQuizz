using AmphiQuizz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestAmphiQuizz
{
    /// <summary>
    /// Description résumée pour UnitTestApplicationData
    /// </summary>
    [TestClass]
    public class UnitTestApplicationData
    {

        /// <summary>
        /// Test de la méthode LoadApplicationData pour vérifier que les listes de chargement des données possèdent au moins un élément 
        /// </summary>
        [TestMethod]
        public void TestStaticMethodLoadApplicationData()
        {
            ApplicationData.LoadApplicationData();
            Assert.AreEqual(3, ApplicationData.ListeNotes.Count);
            Assert.IsTrue(ApplicationData.ListeEleves.Count > 0);
            Assert.IsTrue(ApplicationData.ListeGroupes.Count > 0);
            Assert.IsTrue(ApplicationData.ListeNotesEleves.Count > 0);
            Assert.IsTrue(ApplicationData.ListeProfesseurs.Count > 0);
        }
    }
}
