using dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
namespace bus
{
    public class AccountService
    {
        public Account findByID(string tk, string mk)
        {
            DentalModel context = new DentalModel();
            return context.Accounts.FirstOrDefault(a => a.AccountName == tk 
            && a.Password == mk);
        }
    }
}
