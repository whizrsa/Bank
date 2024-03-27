using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPCA_CT._2022.Y2M9F2_Claremont_Elvis_Chimuse
{
    interface IUserTransaction
    {
        void DisplayBalance(Accounts User);
        void DepositFunds(Accounts User, double balance);
        void WithDrawFunds(Accounts User, double balance);
        void TransferFunds(Accounts User, double balance);

    }
}
