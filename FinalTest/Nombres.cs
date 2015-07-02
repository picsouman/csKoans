using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    public class Nombres
    {
        private IEnumerable<KeyValuePair<string, int>> _keys;

        public IEnumerable<int> NombresPairs
        {
            get {
                return (from k in _keys where k.Value % 2 == 0 select k.Value);
            }
        }

        public string TexteNombresImpairs
        {
            get
            {
                return (from k in _keys where k.Value % 2 == 1 orderby k.Value select k.Key).Aggregate((s, next) => s + ", " + next);
            }
        }

        public string PremierNombreDontLeTexteContientPlusDe5Caractères
        {
            get
            {
                return (from s in _keys where s.Key.Length > 5 select s.Key).FirstOrDefault();
            }
        }

        public IEnumerable<int> QuatreNombresSupérieursSuivant3
        {
            get
            {
                return (from k in _keys orderby k.Value where k.Value > 3 select k.Value).Take(4);
            }
        }


        public Nombres(IEnumerable<KeyValuePair<string, int>> keys)
        {
            this._keys = keys;
        }

    }
}
