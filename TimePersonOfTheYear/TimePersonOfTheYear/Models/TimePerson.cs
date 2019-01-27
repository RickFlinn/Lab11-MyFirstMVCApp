using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace TimePersonOfTheYear.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }


        public TimePerson (string csvLine)
        {
            string[] columns = csvLine.Split(',');
            if (Int32.TryParse(columns[0], out int year))
            {
                Year = year;
            }
            Honor = columns[1];
            Name = columns[2];
            Country = columns[3];
            if (Int32.TryParse(columns[4], out int born))
            {
                BirthYear = born;
            }
            if (Int32.TryParse(columns[5], out int died))
            {
                DeathYear = died;
            }
            Title = columns[6];
            Category = columns[7];
            Context = columns[8];
        }

        /// <summary>
        ///     Static method that takes in a start and end year, reads the .csv file with the Time persons of the year,
        ///         generates a list of TimePerson objects using the data on each line, and then returns a filtered List
        ///         of all the TimePerson objects within the given year range.
        /// </summary>
        /// <param name="start"> Start of year search range </param>
        /// <param name="end"> End of year search range </param>
        /// <returns> List of TimePerson objects within given year search ranges </returns>
        public static List<TimePerson> GetPeople(int start, int end, string webRootPath)
        {
            List<TimePerson> peopleInRange = null;
            try
            {
                if (start < end)
                {
                    //string[] csvLines = File.ReadAllLines("webroot/personOfTheYear.csv");
                    string[] csvLines = File.ReadAllLines(webRootPath + "/personOfTheYear.csv");
                    string firstLine = csvLines[0];
                    peopleInRange = csvLines.Skip(1)
                                            .Select(line => new TimePerson(line))
                                            .Where(person => person.Year >= start && person.Year <= end)
                                            .ToList();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid search range.");
                }
            } catch (Exception e)
            {
                Console.WriteLine("Something went wrong getting our list of Time persons.");
                Console.WriteLine(e.Message);
            }
            return peopleInRange;
        }
    }
    
    


}
