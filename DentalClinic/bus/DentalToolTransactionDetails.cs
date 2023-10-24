using dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class DentalToolTransactionDetails
    {
        public List<DentalToolTransactionsDetail> getAll()
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactionsDetails.ToList();
        }
        public DentalToolTransactionsDetail findByID(int id)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactionsDetails.FirstOrDefault(p => p.TransactionID == id);
        }

        public void InsertUpdate(DentalToolTransactionsDetail s)
        {
            DentalModel context = new DentalModel();
            context.DentalToolTransactionsDetails.AddOrUpdate(s);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            using (DentalModel e = new DentalModel())
            {
                var dental = e.DentalToolTransactionsDetails.FirstOrDefault(p => p.ToolID == id);
                e.DentalToolTransactionsDetails.Remove(dental);
                e.SaveChanges();
            }
        }

        public List<DentalToolTransactionsDetail> ThongKeMonth(int month, int year)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactionsDetails.Where(p => p.DentalToolTransaction.TransactionDate.Value.Month == month && p.DentalToolTransaction.TransactionDate.Value.Year == year).ToList();
            
        }

        public List<DentalToolTransactionsDetail> ThongKeQuy1(int month, int year)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactionsDetails.Where(p => p.DentalToolTransaction.TransactionDate.Value.Month >=1 && p.DentalToolTransaction.TransactionDate.Value.Month <=4 && p.DentalToolTransaction.TransactionDate.Value.Year == year).ToList();

        }

        public List<DentalToolTransactionsDetail> ThongKeQuy2(int month, int year)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactionsDetails.Where(p => p.DentalToolTransaction.TransactionDate.Value.Month >= 5 && p.DentalToolTransaction.TransactionDate.Value.Month <= 8 && p.DentalToolTransaction.TransactionDate.Value.Year == year).ToList();

        }

        public List<DentalToolTransactionsDetail> ThongKeQuy3(int month, int year)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactionsDetails.Where(p => p.DentalToolTransaction.TransactionDate.Value.Month >= 9 && p.DentalToolTransaction.TransactionDate.Value.Month <= 12 && p.DentalToolTransaction.TransactionDate.Value.Year == year).ToList();

        }

        public List<DentalToolTransactionsDetail> ThongKeYear(int month, int year)
        {
            DentalModel context = new DentalModel();
            return context.DentalToolTransactionsDetails.Where(p =>  p.DentalToolTransaction.TransactionDate.Value.Year == year).ToList();

        }
    }
}
