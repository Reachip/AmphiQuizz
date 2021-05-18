using System.Collections.Generic;

namespace AmphiQuizz
{
    /// <summary>
    /// L'interface ICrud permet de serializer ou de deserializer un objet
	/// vis à vis d'une base de données.
    /// </summary>
    internal interface ICrud<T>
    {
        /// <summary>
        /// Permet de d'insérer dans la base de données, l'objet qui implémente l'interface ICrud.
        /// </summary>
        void Create();

        /// <summary>
        /// Permet de lire depuis la base de données, l'objet qui implémente l'interface ICrud.
        /// </summary>
        void Read();

        /// <summary>
        /// Permet de modifier les données de l'objet qui implémente l'interface ICrud dans la base de données
        /// </summary>
        void Update();

        /// <summary>
        /// Permet de supprimer dans la base de données, l'objet qui implémente l'interface ICrud.
        /// </summary>
        void Delete();

        /// <summary>
        /// Permet de récupérer sous forme d'objet, tous les enregistrements de la table de cet objet dans la base de données.
        /// </summary>
        List<T> FindAll();

        /// <summary>
        /// Permet de récupérer sous forme d'objet, les enregistrements de la table de
		/// cet objet dans la base de données avec une expression de la clause where passé en paramètre.
        /// </summary>
        List<T> FindBySelection(string criteres);

        /// <summary>
        /// Permet de récupérer sous forme d'objet, le premier enregistrement de la table de
		/// cet objet dans la base de données avec une expression de la clause where passé en paramètre.
        /// </summary>
        T Find(string criteria);
    }
}