using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class DentalToolTransactionDetailsService
    {
        public List<DentalToolTransactionsDetail> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactionsDetails.ToList();
        }

        public List<DentalToolTransactionsDetail> GetAllByType(bool type)
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactionsDetails.Where(p => p.DentalToolTransaction.TransactionType == type).ToList();
        }

        public List<DentalToolTransactionsDetail> GetAllBetweenDates(DateTime startDate, DateTime endDate, bool type)
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactionsDetails.Where(p => p.DentalToolTransaction.TransactionType == type && p.DentalToolTransaction.TransactionDate >= startDate && p.DentalToolTransaction.TransactionDate <= endDate).ToList();
        }
    }
}
