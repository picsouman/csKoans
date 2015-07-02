using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalTest
{
    public class Somme : IOperation
    {

        public bool PeutCalculer(string calcul)
        {
            Regex regex = new Regex("[0-9]+[+][0-9]+");
            return regex.Match(calcul).Success;
        }
        public int Calculer(string calcul)
        {
            string[] data = calcul.Split('+');
            if (data.Length != 2) return 0;
            int nb1, nb2;
            if (!int.TryParse(data[0], out nb1) || !int.TryParse(data[1], out nb2)) return 0;
            return nb1 + nb2;
        }


    }
}
