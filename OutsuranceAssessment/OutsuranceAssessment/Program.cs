using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceAssessment
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the filepath for the CSV file:");
            string filepath = Console.ReadLine();

            while (!File.Exists(filepath) || Path.GetExtension(filepath) != ".csv")
            {
                Console.WriteLine("Enter a valid file of type CSV:");
                filepath = Console.ReadLine();
            }

            try
            {
                List<IPerson> allPersonData = new List<IPerson>();

                //Read data from CSV file and populate List of People
                CsvToPersonList(filepath, ref allPersonData);

                PeopleService peopleService = new PeopleService();
                //Get sorted list of firstname and lastname occurences
                Dictionary<string, int> nameOcuurrences = peopleService.GetOccurences(allPersonData);

                //Get sorted List of addresses
                List<string> sortedAddresses = peopleService.GetSortedAddresses(allPersonData);

                //Write the results to text files
                WriteTextFile(nameOcuurrences.Select(x => $"{x.Key}, {x.Value}").ToList(), Path.GetDirectoryName(filepath) + @"\ResultOne.txt");
                WriteTextFile(sortedAddresses, Path.GetDirectoryName(filepath) + @"\ResultTwo.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred. Could not process the request.");
            }
            Console.WriteLine("Output text files have been written to: " + Path.GetDirectoryName(filepath));
            Console.Read();
        }

        static void CsvToPersonList(string filePath, ref List<IPerson> personList)
        {
            using (var reader = new StreamReader(filePath))
            {
                personList = (from line in File.ReadAllLines(filePath).Skip(1)
                              let columns = line.Split(',')
                              select new Person
                              {
                                  Firstname = columns[0],
                                  Lastname = columns[1],
                                  Address = columns[2],
                                  PhoneNumber = columns[3]
                              }).ToList<IPerson>();
            }
        }

        static void WriteTextFile(List<string> lines, string location)
        {
            using (StreamWriter writetext = new StreamWriter(location))
            {
                foreach (var line in lines)
                {
                    writetext.WriteLine(line);
                }
            }
        }
    }
}
