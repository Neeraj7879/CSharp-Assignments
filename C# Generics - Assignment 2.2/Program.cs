using System;
using System.Collections.Generic;
using System.Linq;

namespace C__Generics___Assignment_2._2
{
    public class Prime_Minister
    {
        string P_Name;
        int P_year;

        public string Name
        {
            get
            {
                return P_Name;
            }
            set
            {
                P_Name = value;
            }
        }

        public int Year
        {
            get
            {
                return P_year;
            }
            set
            {
                P_year = value;
            }
        }
        public override string ToString()
        {
            return "Name :- " + Name + " ,  " + "Year:" + Year;
        }
        public Prime_Minister(string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }
    }
    class Program
    {
        static Dictionary<string, Prime_Minister> Raw_Data = new Dictionary<string, Prime_Minister>();
        static void Main(string[] args)
        {
            try
            {

                Data_Prime_minister();

                /* Search for 2004 year prime minister */

                Console.WriteLine("\nPrime Minister in 2004 was :- ");
                foreach (var i in Raw_Data.Values)
                {
                    if (i.Year.Equals(2004))
                    {
                        Console.WriteLine(i);
                    }
                }

                /* enter current Prime minister */
                Console.WriteLine("\nAfter Adding current Prime Minister :- ");
                String Name_temp = Console.ReadLine();
                int Year_temp = Convert.ToInt32(Console.ReadLine());

                Add_sorting(Name_temp, Year_temp);
            }
            catch
            {
                Console.WriteLine("Enter Proper Year");
            }
        }

        private static void Data_Prime_minister()
        {
            Raw_Data.Add("1", new Prime_Minister("Atal Bihari Vajpayee      ", 1998));
            Raw_Data.Add("2", new Prime_Minister("Narendra Modi            ", 2014));
            Raw_Data.Add("3", new Prime_Minister("Manmohan Singh            ", 2004));
        }
        private static void Add_sorting(String Name_temp, int Year_temp)
        {
            /* Adding prime minister  */
            Name_temp = Name_temp + "           ";
            Raw_Data["4"] = new Prime_Minister(Name_temp, Year_temp);
            foreach (var i in Raw_Data.Values)
                Console.WriteLine(i);

            /* Sorting On basis of years value.Year */
            Console.WriteLine("\n List Sorted Order(by Year):-\n");
            Raw_Data = Raw_Data.OrderBy(r => r.Value.Year).ToDictionary(r => r.Key, r => r.Value);
            var sorteddict = new SortedDictionary<string, int>(Raw_Data.Values);
            foreach (var i in Raw_Data.Values)
                Console.WriteLine(i);

        }
    }
}
