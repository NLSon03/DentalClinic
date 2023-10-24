using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class DentalToolTransactionService
    {
        public List<DentalToolTransaction> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactions.ToList();
        }
    }
}
