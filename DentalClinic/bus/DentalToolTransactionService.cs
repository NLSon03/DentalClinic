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
        public List<DentalToolTransaction> GetAllDentalToolTransaction(int facultyID)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactions.Where(p => p.TransactionID == facultyID).ToList();
        }

        public List<DentalToolTransaction> GetAllDentalToolTransactionThang(int thang, int nam)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactions.Where(p => p.TransactionDate.Value.Month == thang && p.TransactionDate.Value.Year == nam).ToList();
        }

        public List<DentalToolTransaction> GetAllDentalToolTransactionQuy1(int quy1, int nam)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactions.Where(p => p.TransactionDate.Value.Month >= 1 && p.TransactionDate.Value.Month <=4 && p.TransactionDate.Value.Year == nam).ToList();
        }

        public List<DentalToolTransaction> GetAllDentalToolTransactionQuy2(int quy2, int nam)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactions.Where(p => p.TransactionDate.Value.Month >= 5 && p.TransactionDate.Value.Month <= 8 && p.TransactionDate.Value.Year == nam).ToList();
        }

        public List<DentalToolTransaction> GetAllDentalToolTransactionQuy3(int quy3, int nam)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactions.Where(p => p.TransactionDate.Value.Month >= 9 && p.TransactionDate.Value.Month <= 12 && p.TransactionDate.Value.Year == nam).ToList();
        }

        public List<DentalToolTransaction> GetAllDentalToolTransactionNam( int nam)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactions.Where(p => p.TransactionDate.Value.Year == nam).ToList();
        }
    }
}
