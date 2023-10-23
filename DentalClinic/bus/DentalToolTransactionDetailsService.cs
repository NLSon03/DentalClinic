using dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public DentalToolTransactionsDetail findById(int id)
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactionsDetails.FirstOrDefault(p => p.TransactionID == id);
        }

        public DentalToolTransactionsDetail findDentalToolTransactionDetails(int id, int idDentalTool)
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactionsDetails.FirstOrDefault(p => p.TransactionID == id && p.ToolID == idDentalTool);
        }

        public DentalToolTransactionsDetail findByIdTool(int id)
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactionsDetails.FirstOrDefault(p => p.ToolID == id);
        }

        public void DeleteById(int id, int idTool)
        {
            using (DentalModel e = new DentalModel())
            {
                var students = e.DentalToolTransactionsDetails.FirstOrDefault(p => p.TransactionID== id && p.ToolID == idTool);
                e.DentalToolTransactionsDetails.Remove(students);
                e.SaveChanges();
            }
        }

        public void InsertUpdate(DentalToolTransactionsDetail s)
        {
            DentalModel context = new DentalModel();
            context.DentalToolTransactionsDetails.AddOrUpdate(s);
            context.SaveChanges();
        }

        public List<DentalToolTransactionsDetail> GetAllBetweenDates(DateTime startDate, DateTime endDate, bool type)
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactionsDetails.Where(p => p.DentalToolTransaction.TransactionType == type && p.DentalToolTransaction.TransactionDate >= startDate && p.DentalToolTransaction.TransactionDate <= endDate).ToList();
        }

        public List<DentalToolTransactionsDetail> GetAllBetweenDates(DateTime startDate, DateTime endDate) 
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactionsDetails.Where(p => p.DentalToolTransaction.TransactionDate <= endDate && p.DentalToolTransaction.TransactionDate >= startDate).ToList();
        }
        public List<DentalToolTransactionsDetail> GetAllByid(int type)
        {
            DentalModel model = new DentalModel();
            return model.DentalToolTransactionsDetails.Where(p => p.TransactionID == type).ToList();
        }
    }
}
