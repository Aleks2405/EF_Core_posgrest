using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_posgrest
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DataPosechenia { get; set; }
    }
}
