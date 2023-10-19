using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class InventoryService
    {
        public List<Inventory> GetAll()
        {
            DentalModel model = new DentalModel();
            var slnhap = model.DentalToolTransactionsDetails.Where(x => x.DentalToolTransaction.TransactionType == false)
                                                            .GroupBy(x => x.ToolID)
                                                            .ToDictionary(group => group.Key, group => group.Sum(x => x.Quantity));
            var slxuat = model.DentalToolTransactionsDetails.Where(x => x.DentalToolTransaction.TransactionType == true)
                                                            .GroupBy(x => x.ToolID)
                                                            .ToDictionary(group => group.Key, group => group.Sum(x => x.Quantity));
            var list = model.DentalTools.ToList().Select(x =>
            {
                var quantityPurchased = slnhap.ContainsKey(x.ToolID) ? slnhap[x.ToolID] : 0;
                var quantitySold = slxuat.ContainsKey(x.ToolID) ? slxuat[x.ToolID] : 0;
                DateTime? lastUpdateDate = null;
                if (quantityPurchased != 0 || quantitySold != 0)
                {
                    lastUpdateDate = model.DentalToolTransactionsDetails.Where(a => a.ToolID == x.ToolID)
                                                                        .OrderByDescending(a => a.DentalToolTransaction.TransactionDate)
                                                                        .Select(a => a.DentalToolTransaction.TransactionDate)
                                                                        .FirstOrDefault()
                                                                        .GetValueOrDefault();
                }
                return new Inventory
                {
                    ToolName = x.ToolName,
                    QuantityPurchased = quantityPurchased,
                    QuantitySold = quantitySold,
                    RemainingQuantity = x.Quantity,
                    LastUpdateDate = lastUpdateDate
                };
            }).ToList();
            return list;
        }


        public List<Inventory> GetAllBetweenDates(DateTime startDate, DateTime endDate)
        {
            DentalModel model = new DentalModel();
            var slnhap = model.DentalToolTransactionsDetails.Where(x => x.DentalToolTransaction.TransactionType == false && x.DentalToolTransaction.TransactionDate >= startDate && x.DentalToolTransaction.TransactionDate <= endDate)
                                                            .GroupBy(x => x.ToolID)
                                                            .ToDictionary(group => group.Key, group => group.Sum(x => x.Quantity));
            var slxuat = model.DentalToolTransactionsDetails.Where(x => x.DentalToolTransaction.TransactionType == true && x.DentalToolTransaction.TransactionDate >= startDate && x.DentalToolTransaction.TransactionDate <= endDate)
                                                            .GroupBy(x => x.ToolID)
                                                            .ToDictionary(group => group.Key, group => group.Sum(x => x.Quantity));
            var list = model.DentalTools.ToList().Select(x =>
            {
                var quantityPurchased = slnhap.ContainsKey(x.ToolID) ? slnhap[x.ToolID] : 0;
                var quantitySold = slxuat.ContainsKey(x.ToolID) ? slxuat[x.ToolID] : 0;
                DateTime? lastUpdateDate = null;
                if (quantityPurchased != 0 || quantitySold != 0)
                {
                    lastUpdateDate = model.DentalToolTransactionsDetails.Where(a => a.ToolID == x.ToolID && a.DentalToolTransaction.TransactionDate >= startDate && a.DentalToolTransaction.TransactionDate <= endDate)
                                                                        .OrderByDescending(a => a.DentalToolTransaction.TransactionDate)
                                                                        .Select(a => a.DentalToolTransaction.TransactionDate)
                                                                        .FirstOrDefault();
                }
                return new Inventory
                {
                    ToolName = x.ToolName,
                    QuantityPurchased = quantityPurchased,
                    QuantitySold = quantitySold,
                    RemainingQuantity = x.Quantity,
                    LastUpdateDate = lastUpdateDate
                };
            }).ToList();
            return list;
        }



    }
}
