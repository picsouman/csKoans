using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    public class CompteCréé : IEvenementMetier
    {
        public string Compte;
        public int Autorisation;

        public CompteCréé(string compte, int value)
        {
            this.Compte = compte;
            this.Autorisation = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!obj.GetType().IsAssignableFrom(typeof(CompteCréé))) return false;
            var c = (CompteCréé)obj;
            return this.Autorisation == c.Autorisation && this.Compte == c.Compte;
        }
    }
}
