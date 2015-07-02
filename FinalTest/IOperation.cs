using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    public interface IOperation
    {
        bool PeutCalculer(string calcul);
        int Calculer(string calcul);
    }
}
