using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Entities
{
    public class Revenue
    {
        public DateTime Ngay { get; set; }
        public decimal TienThu { get; set; }
        public decimal TienChi { get; set; }
        public decimal Tong { get { return TienThu - TienChi; } }
    }
}
