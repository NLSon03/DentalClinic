using dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class DentalToolService
    {
        public List<DentalTool> GetAll()
        {
            DentalModel model = new DentalModel();
            return model.DentalTools.ToList();
        }
        public List<DentalTool> getAll()
        {
            DentalModel context = new DentalModel();
            return context.DentalTools.ToList();
        }

        public DentalTool findByID(int id)
        {
            DentalModel context = new DentalModel();
            return context.DentalTools.FirstOrDefault(p => p.ToolID == id);
        }

        public void InsertUpdate(DentalTool s)
        {
            DentalModel context = new DentalModel();
            context.DentalTools.AddOrUpdate(s);
            context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            using (DentalModel e = new DentalModel())
            {
                var dental = e.DentalTools.FirstOrDefault(p => p.ToolID == id);
                e.DentalTools.Remove(dental);
                e.SaveChanges();
            }
        }
    }
}
