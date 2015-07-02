using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{


    public class DépotRéalisé : IEvenementMetier
    {

        public string Compte;
        public Montant Montant;
        public DateTime Date;

        public DépotRéalisé(string c, Montant m, DateTime d)
        {
            Compte = c;
            Montant = m;
            Date = d;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!obj.GetType().IsAssignableFrom(typeof(DépotRéalisé))) return false;
            var c = (DépotRéalisé)obj;
            return c.Montant.Value == this.Montant.Value &&
                    c.Date == this.Date &&
                    c.Compte == this.Compte;
        }
    }
}
