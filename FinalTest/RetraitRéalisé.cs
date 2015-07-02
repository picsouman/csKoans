using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    public class RetraitRéalisé : IEvenementMetier
    {

        public Montant Montant;
        public string Compte;
        public DateTime dateRetrait;

        public RetraitRéalisé(string p, Montant Montant, DateTime dateRetrait)
        {
            this.Compte = p;
            this.Montant = Montant;
            this.dateRetrait = dateRetrait;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!obj.GetType().IsAssignableFrom(typeof(RetraitRéalisé))) return false;
            var c = (RetraitRéalisé)obj;
            return c.Montant.Value == this.Montant.Value &&
                    c.dateRetrait == this.dateRetrait &&
                    c.Compte == this.Compte;
        }

    }
}
