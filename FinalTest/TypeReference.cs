using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    public class TypeReference
    {
        public int valeur { get; set; }

        public TypeReference(int val)
        {
            valeur = val;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!obj.GetType().IsAssignableFrom(typeof(TypeReference))) return false;
            return ((TypeReference)obj).valeur.Equals(this.valeur);
        }
    }
}
