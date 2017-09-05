using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceAssessment
{
    public class Person : IPerson
    {
        public string Firstname { get ; set ; }
        public string Lastname { get ; set ; }
        public string Address { get ; set ; }
        public string PhoneNumber { get ; set ; }
        
        public string GetStreetName()
        {
            var tempArr = this.Address.Split(' ');
            return String.Format("{0} {1}", tempArr[1], tempArr[2]);
        }
        
    }
}
