using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceAssessment
{
    public interface IPerson
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }

        string GetStreetName();
    }
}
