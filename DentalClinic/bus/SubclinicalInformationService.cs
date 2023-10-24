using dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    public class SubClinicalInformationService
    {
        public SubClinicalInformation GetById(string id)
        {
            DentalModel context = new DentalModel();
            return context.SubClinicalInformations.FirstOrDefault(p => p.PatientID.ToString() == id);
        }

        public void Insert(string id)
        {
            var context = new DentalModel();
            context.SubClinicalInformations.Add(new SubClinicalInformation() {
                PatientID = Convert.ToInt32(id),
                BloodPressure = null,
                PulseRate = null,
                BloodSugarLevel = null,
                BloodCoagulation = null,
                CongenitalHeartDisease = null,
                IntellectualDisability = null,
                XRayFilm = null,
                WarrantyID = null,
                LaboName = null,
                Other = null
            });
            context.SaveChanges();
        }

        public void Update(SubClinicalInformation inf)
        {
            var context = new DentalModel();
            context.SubClinicalInformations.AddOrUpdate(inf);
            context.SaveChanges();
        }
    }
}
