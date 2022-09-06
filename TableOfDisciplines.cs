using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_posgrest
{
    public class TableOfDiscipline
    {
        public Guid Id { get; set; }

        public string Discipline { get; set; }

        public Guid IdKey { get; set; }

        public DateOfVisit? DateOfVisit { get; set; }
       

    }
}
