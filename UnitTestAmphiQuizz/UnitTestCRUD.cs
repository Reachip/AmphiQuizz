using AmphiQuizz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestAmphiQuizz
{

    /// <summary>
    /// test des class du CRUD
    /// <summary>
    [TestClass]
    public class UnitTestCRUD
    {
        Eleve eleve;
        Professeur professeur;
        Note note;
        Groupe groupe;

        /// <summary>
        /// Initialisation des classes
        /// </summary>

        [TestInitialize]
        public void TestInitialize()
        {
            eleve = new Eleve();
            professeur = new Professeur();
            note = new Note();
            groupe = new Groupe();

            
        }

        /// <summary>
        /// Test de la méthode Create en testant d'inserer une note
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethodCreateNullReferenceException() => note.Create();



        /// <summary>
        /// Test une exception de la Methode Create en testant si l'exception System.Data.SqlClient.SqlException a marché
        /// </summary>

        [TestMethod]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void TestMethodCreateNoteSqlException()
        {
            Professeur p1 = new Professeur(-5,"nom","prenom");
            Groupe g1 = new Groupe(-1, "GROUPE A");
            Eleve e1 = new Eleve(-15,"louis","ancel",g1,"test.png");

            Note note = new Note(DateTime.Now,5,p1,e1);
            note.Create();
        }

        /// <summary>
        /// Test de la methode FindBySelection en vérifiant que la séléction retourne au moins un élément si l'assertion SQL est correcte, puis
        /// vérifie que la sélection retourne aucun élément si l'assertion SQL n'est pas correcte
        /// </summary>
        [TestMethod]
        public void TestMethodeFindBySelection()
        {
            Assert.IsTrue(note.FindBySelection("numero_professeur='1'").Count > 0);
            Assert.IsFalse(note.FindBySelection("numero_professeur='-1'").Count > 0);
        }

        /// <summary>
        /// Test de la méthode Find pour voir si les éléments ajouté ont correctement été implanté
        /// </summary>
        [TestMethod]
        public void TestMethodeFind()
        {
            
            Professeur colin = new Professeur(1, "Colin", "Pascal");
            Groupe groupeA = new Groupe(1, "GROUPE A");
            Eleve ancel = new Eleve(16, "ANCEL", "LOUIS", groupeA, "52001363.jpg");

            Assert.AreEqual(groupeA, groupeA.Find("n_groupe=1"));
            Assert.AreEqual(ancel, ancel.Find("numero_eleve=16"));
            Assert.AreEqual(colin, colin.Find("numero_professeur=1"));
        }

        /// <summary>
        /// Test une exception de la methode Find en testant si l'exception NullReferenceException a été levée en passant une
        /// mauvaise assertion SQL
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethodCreateFindNullReferenceException()
        {
            professeur.Find("numero_elevee=''");
            eleve.Find("numero_elevee='-16'");
        }

        /// <summary>
        /// Test de la méthode FindAll pour tester si la méthode retourne plus d'un élément depuis la base de données
        /// </summary>
        [TestMethod]
        public void TestMethodFindAll() 
        {
            Assert.IsTrue(eleve.FindAll().Count > 0);
            Assert.IsTrue(professeur.FindAll().Count > 0); 
            Assert.IsTrue(note.FindAll().Count > 0);
            Assert.IsTrue(groupe.FindAll().Count > 0);
        }
    }
}
