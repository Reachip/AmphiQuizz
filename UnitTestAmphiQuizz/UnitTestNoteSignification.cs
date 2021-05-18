using AmphiQuizz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestAmphiQuizz
{
    /// <summary>
    /// Tests unitaires pour l'énumeration NoteSignification
    /// </summary>
    [TestClass]
    public class UnitTestNoteSignification
    {
        /// <summary>
        /// Test de la méthode NoteSignification en testant si les valeurs envoyées au niveau de la note
        /// correspondent bien aux valeurs demandés 
        /// </summary>
        [TestMethod]
        public void TestNoteSignificationEquality()
        {
            Assert.AreEqual(0, (int)SignificationNote.ABSENT);
            Assert.AreEqual(1, (int)SignificationNote.REPONSE_FAUSSE);
            Assert.AreEqual(2, (int)SignificationNote.BONNE_REPONSE);
        }
    }
}
