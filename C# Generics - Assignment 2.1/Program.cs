using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2
{
    public class Program
    {

        string P_Type;
        double P_Price;
        string P_name;
        int P_Quantity;

        public string Name
        {
            get
            {
                return P_name;
            }
            set
            {
                P_name = value;
            }
        }
        public int Quantity
        {
            get
            {
                return P_Quantity;
            }
            set
            {
                P_Quantity = value;
            }
        }

        public string Type
        {
            get
            {
                return P_Type;
            }
            set
            {
                P_Type = value;
            }
        }
        public double Price
        {
            get
            {
                return P_Price;
            }
            set
            {
                P_Price = value;
            }
        }
        public override string ToString()
        {
            return "Name:-" + Name + " " + "Price:-" + Price + " RS" + " " + "Quantity:-" + Quantity + " " + "Type:-" + Type;
        }
        static List<Program> Raw_Data = new List<Program>();


        static void Main(string[] args)
        {

            List<Program> Raw_Data = new List<Program>()
            {
                 new Program(){ Name="lettuce", Price=10.5,Quantity=50,Type="Leafy green"},
                 new Program(){ Name="cabbage", Price=20,Quantity=100,Type="Cruciferous"},
                 new Program(){ Name="pumpkin", Price=30,Quantity=30,Type="Marrow"},
                 new Program(){ Name="cauliflower", Price=10,Quantity=25,Type="Cruciferous"},
                 new Program(){ Name="zucchini", Price=20.5,Quantity=50,Type="Marrow"},
                 new Program(){ Name="yam", Price=30,Quantity=50,Type="Root"},
                 new Program(){ Name="spinach", Price=10,Quantity=100,Type="Leafy green"},
                 new Program(){ Name="broccoli", Price=20.2 ,Quantity=75,Type="Cruciferous"},
                 new Program(){ Name="Garlic", Price=30 ,Quantity=20,Type="Leafy green"},
                 new Program(){ Name="silverbeet", Price=10,Quantity=50,Type="Marrow"}
            };

            /*priting total products*/
            Console.WriteLine("\nTotal number of products in the List :- {0} \n", Raw_Data.Count);


            Console.WriteLine("After adding new product");

            /* Adding potato*/
            Raw_Data.Add(new Program() { Name = "Potato", Price = 10, Quantity = 50, Type = "Root" });
            /*Calculating total number of Products after adding potatos*/
            Console.WriteLine(" Total number of Products in list:-{0}\n", Raw_Data.Count);


            /*foreach (var item in Raw_Data)
            { Console.WriteLine(item); }*/

            /* sorting leafy green type */
            Console.WriteLine("\nProducts having type Leafy Green:");

            foreach (var item in Raw_Data)
            {
                if (item.Type.Equals("Leafy green"))
                    Console.WriteLine(item);
            }

            /*Adding & deleting function called*/
            Add_delete(Raw_Data);


            /*purchase function*/
            double result = calculate_total(Raw_Data);
            Console.WriteLine("\nAfter purchasing 1 kg lettuce,2 kg zucchini, 1kg broccoli Rounded Value:-{0}", result);


        }

        /*function calculating  purchases of 1kg lettuce,2kg zucchini,1 kg broccoli*/
        private static double calculate_total(List<Program> Raw_Data)
        {
            double Cost = 0;
            double Cost_let = 0;
            double Cost_zuc = 0;
            double Cost_bro = 0;
            foreach (var item in Raw_Data)
            {
                if (item.Name.Equals("lettuce"))
                {
                    Cost_let = Cost_let + 1 * item.Price;
                }
                if (item.Name.Equals("zucchini"))
                {
                    Cost_zuc = Cost_zuc + 2 * item.Price;
                }
                if (item.Name.Equals("broccoli"))
                {
                    Cost_bro = Cost_bro + 1 * item.Price;
                }


            }
            Cost = Cost_let + Cost_zuc + Cost_bro;


            return Math.Round(Cost);

        }

        private static void Add_delete(List<Program> Raw_Data)
        /* sorting of leafy grean and removing garlic */
        {
            var itemToRemove = Raw_Data.Single(r => r.Name == "Garlic");
            Raw_Data.Remove(itemToRemove);
            Console.WriteLine("\nTotal number of Product after removing Garlic:-{0}", Raw_Data.Count);
            Console.WriteLine("Total number of cabbage after adding 50");


            /*Adding 50 more cabbage to cabbage */
            foreach (var item in Raw_Data)
            {
                if (item.Name.Equals("cabbage"))
                {
                    int a = item.Quantity + 50;
                    item.Quantity = a;
                    Console.WriteLine(item);
                }
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}