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

        public static List<TimePerson> GetPeople(int start, int end)
        {
            List<TimePerson> peopleInRange = null;
            try
            {
                if (start < end)
                {
                    string[] csvLines = File.ReadAllLines("../wwwroot/personOfTheYear.csv");
                    peopleInRange = csvLines.Skip(1)
                                            .Select(line => new TimePerson(line))
                                            .Where(person => person.Year > start && person.Year < end)
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
