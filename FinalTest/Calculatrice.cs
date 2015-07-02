using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    public class Calculatrice
    {
        private IOperation[] _op;


        public Calculatrice(IOperation[] op)
        {
            this._op = op;
        }

        public int Calculer(string calcul)
        {
            if (_op == null) return 0;
            foreach(IOperation o in this._op)
            {
                if(o.PeutCalculer(calcul))
                {
                    return o.Calculer(calcul);
                }
            }
            return 0;
        }

    }
}
