using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Strategy
{
    public class CashRebate : CashSuper
    {
        private double moneyRebate = 1d;

        public CashRebate(string moenyRebate)
        {
            this.moneyRebate = double.Parse(moenyRebate);
        }

        public override double acceptCash(double money)
        {
            return money * moneyRebate;
        }
    }
}
