using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchModuleAPI.Enum
{
    public sealed class FunctionalCodeError
    {
        public static readonly FunctionalCodeError NoMatch = new FunctionalCodeError("Aucun message fonctionnel associé");
        public static readonly FunctionalCodeError Sql = new FunctionalCodeError("Erreur au niveau de la couche d'accès aux données");
        public static readonly FunctionalCodeError ErrorOrGetProduct = new FunctionalCodeError("Aucun produit n'a pu être récupéré");
        public static readonly FunctionalCodeError ErrorOrGetCategorie = new FunctionalCodeError("No categorie retrieve");

        private FunctionalCodeError(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}