using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class MedicineService
    {
        public List<Medicine> GetAllMedicine()
        {
            DentalModel context = new DentalModel();
            return context.Medicine.ToList();
        }
    }
}
