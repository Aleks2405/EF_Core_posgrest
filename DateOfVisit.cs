using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_posgrest
{
    public class DateOfVisit
    {
        public Guid Id { get; set; }
        public string Visit { get; set; }
        public Guid IdKey { get; set; }

       
    }
}
