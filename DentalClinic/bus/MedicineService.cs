using dal;
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
            DentalModel model = new DentalModel();
            return model.Medicines.ToList();
        }
    }
}
