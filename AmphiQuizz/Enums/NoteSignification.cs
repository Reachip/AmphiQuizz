using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmphiQuizz
{
    /// <summary>
    /// Nom des notes appliquées aux élèves (sous forme de d'entiers d'un point de vue de la BDD.
    /// Cette énumération est seuelement utilisée pour une meilleur lecture et compréhension du code.
    /// </summary>
    public enum SignificationNote
    {
        ABSENT = 0, // L'élève est noté absent
        REPONSE_FAUSSE = 1, // L'élève a répondu faux
        BONNE_REPONSE = 2 // L'élève a répondu juste
    }
}
