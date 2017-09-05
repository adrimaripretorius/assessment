using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceAssessment
{
    public class PeopleService
    {
        public Dictionary<string, int> GetOccurences(List<IPerson> people)
        {
            Dictionary<string, int> listToReturn = new Dictionary<string, int>();

            foreach(var person in people)
            {
                if (listToReturn.ContainsKey(person.Firstname))
                {
                    listToReturn[person.Firstname] += 1;

                }
                else
                {
                    listToReturn.Add(person.Firstname, 1);
                }

                if (listToReturn.ContainsKey(person.Lastname))
                {
                    listToReturn[person.Lastname] += 1;

                }
                else
                {
                    listToReturn.Add(person.Lastname, 1);
                }
            }
            return (listToReturn.OrderByDescending(x => x.Value).ThenBy(x => x.Key)).ToDictionary(x => x.Key, x => x.Value);
        }

        public List<string> GetSortedAddresses(List<IPerson> people)
        {
            return people.OrderBy(x => x.GetStreetName()).Select(x => x.Address).ToList();
        }
    }
}
