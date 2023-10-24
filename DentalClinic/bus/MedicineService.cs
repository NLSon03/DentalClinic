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
            return context.Medicines.ToList();
        }

        public Medicine GetIDByName(string name)
        {
            DentalModel context = new DentalModel();
            return context.Medicines.FirstOrDefault(p => p.MedicineName.ToString() == name);
        }
    }
}
