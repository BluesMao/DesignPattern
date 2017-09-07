using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Strategy
{
    /// <summary>
    /// 策略类
    /// </summary>
    public class CashContext
    {
        private CashSuper cs;

        public CashContext (CashSuper csuper)
        {
            this.cs = csuper;
        }

        public double GetResult(double money)
        {
            return cs.acceptCash(money);
        }
    }
}
