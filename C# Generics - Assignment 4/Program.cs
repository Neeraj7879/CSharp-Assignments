using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace ReadWriteASync
{
    class Program
    {
        static void Main(string[] args)
        {
            readtext();

        }
        static async void readtext()
        {
            try
            {
                Console.WriteLine("enter name of 1st file");
                string file1 = System.Console.ReadLine();
                string text = "n";
                if (File.Exists(file1))
                {
                    using (StreamReader reader = File.OpenText(file1))
                    {
                        text = await File.ReadAllTextAsync(file1);
                    }
                }
                else
                {
                    Console.WriteLine("Enter correct name of file");
                }

                Console.WriteLine("enter name of 2st file");
                string file2 = System.Console.ReadLine();
                if (File.Exists(file2))
                {
                    using (StreamWriter output = new StreamWriter(file2, true))
                    {
                        await output.WriteAsync(text);
                        System.Console.WriteLine("\nText Copied Sucessfully From {0} To {1}", file1, file2);
                    }
                }
                else
                {
                    Console.WriteLine("Enter correct name of file");
                }


            }
            catch (Exception ex)
            {
                System.Console.WriteLine(Environment.NewLine + ex.Message);
            }
        }


    }
}