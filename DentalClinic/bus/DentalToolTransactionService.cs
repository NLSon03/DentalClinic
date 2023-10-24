using dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class DentalToolTransactionService
    {
        public DentalToolTransaction GetAllDentalToolTransaction(int ID)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactions.FirstOrDefault(p => p.TransactionID == ID);
        }

        public List<DentalToolTransaction> GetAllDentalToolTransactionThang(int thang, int nam)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactions.Where(p => p.TransactionDate.Value.Month == thang && p.TransactionDate.Value.Year == nam).ToList();
        }

        public void InsertUpdate(DentalToolTransaction s)
        {
            DentalModel context = new DentalModel();
            context.DentalToolTransactions.AddOrUpdate(s);
            context.SaveChanges();
        }
        
        
    }
}
