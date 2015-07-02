using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    public class CompteBancaire
    {
        public IEnumerable<IEvenementMetier> events;
        public string CurrentAccount;
        public Montant Montant;

        #region Constructors

        public CompteBancaire(params IEvenementMetier[] em)
        {
            this.Montant = new Montant(0);
            foreach(IEvenementMetier e in em)
            {
                events = em;

                // on traite certaines spécificités
                if(e.GetType().IsAssignableFrom(typeof(CompteCréé)))
                {
                    CurrentAccount = ((CompteCréé)e).Compte;
                }
                if(e.GetType().IsAssignableFrom(typeof(DépotRéalisé)))
                {
                    AddMontant(((DépotRéalisé)e).Montant, ((DépotRéalisé)e).Date);
                }
                if (e.GetType().IsAssignableFrom(typeof(RetraitRéalisé)))
                {
                    ((RetraitRéalisé)e).Montant.Value *= -1;
                    AddMontant(((RetraitRéalisé)e).Montant, ((RetraitRéalisé)e).dateRetrait);
                }
            }
        }

        #endregion


        #region WorkEvents

        public static IEnumerable<IEvenementMetier> Ouvrir(string compte, int value)
        {
            yield return new CompteCréé(compte, value);
        }

        public IEnumerable<IEvenementMetier> FaireUnDepot(Montant m, DateTime date)
        {
            yield return new DépotRéalisé(this.CurrentAccount, m, date);
            var balance = AddMontant(m, date);
            if(balance != null)
                yield return AddMontant(m, date);
        }

        public IEnumerable<IEvenementMetier> FaireUnRetrait(Montant montantRetrait, DateTime dateRetrait)
        {
            Montant nm = new Montant(montantRetrait.Value * -1);
            IEvenementMetier e = AddMontant(nm, dateRetrait);
            yield return new RetraitRéalisé(this.CurrentAccount, montantRetrait, dateRetrait);
            if (e != null) yield return e;
        }

        #endregion

        #region Methods

        private IEvenementMetier AddMontant(Montant m, DateTime date)
        {
            this.Montant.Value += m.Value;
            if (this.Montant.Value + m.Value < 0)
            {
                Montant nm = new Montant(this.Montant.Value + m.Value);
                return new BalanceNégativeDétectée(this.CurrentAccount, nm, date);
            }
            return null;
        }

        #endregion

    }
}
