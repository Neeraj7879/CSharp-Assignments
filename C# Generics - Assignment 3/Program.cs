using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class Program
{
    IList<Employee> employeeList;
    IList<Salary> salaryList;

    public Program()
    {
        employeeList = new List<Employee> {
                new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
                new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
                new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
                new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
                new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
                new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
                new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
            };

        salaryList = new List<Salary> {
                new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
                new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},

                new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},

                new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},

                new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},

                new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
                new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},

                new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},

                new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
            };
    }

    public static void Main()
    {
        Program program = new Program();


        program.Task1();
        program.Task2();
        program.Task3();
    }


    public void Task1()
    {
        /* print total Salary in ascending order of all the employee in with there name */
        var Query_temp = from emp in employeeList
                         join sal in salaryList
                         on emp.EmployeeID equals sal.EmployeeID into employee_temp
                         select new
                         {
                             Name = emp.EmployeeFirstName + emp.EmployeeLastName,
                             Total_Salary = employee_temp.Sum(s => s.Amount)
                         };
        var Query_temp1 = from emp in Query_temp orderby emp.Total_Salary select emp;

        Console.WriteLine("Total salary Of All The Employee with their salary with Name: \n ");
        foreach (var emp in Query_temp1)
        {
            Console.WriteLine("Name : {0} \t Total Salary : {1}", emp.Name, emp.Total_Salary);

        }
        Console.WriteLine();
    }

    public void Task2()
    {
        /* print 2nd oldest employee with total monthly salary. */
        var Query_temp = from emp in employeeList
                         join salary in salaryList
                         on emp.EmployeeID equals salary.EmployeeID
                         where salary.Type == SalaryType.Monthly
                         orderby emp.Age descending
                         select new
                         {
                             emp,
                             salary
                         } into result
                         group result by result.emp.EmployeeID;

        Console.WriteLine("Employee details of 2nd oldest employee");
        foreach (var emp in Query_temp.Take(2).Skip(1))
        {

            foreach (var emp1 in emp)
            {
                Console.WriteLine();
                Console.WriteLine("Id: {0} Name: {1} {2} Age: {3} Monthly Salary: {4}", emp1.emp.EmployeeID
                , emp1.emp.EmployeeFirstName, emp1.emp.EmployeeLastName, emp1.emp.Age, emp1.salary.Amount
                );

            }
        }
        Console.WriteLine();
    }

    public void Task3()
    {
        /*Print mean of monthly, performance and bonus salary of all the employees where age is greater than 30*/
        var Query_temp3 = from emp in employeeList
                          where emp.Age > 30
                          join sal in salaryList
                          on emp.EmployeeID equals sal.EmployeeID into employee_temp
                          select new
                          {
                              EmployeeId = emp.EmployeeID,
                              EmployeeName = emp.EmployeeFirstName + emp.EmployeeLastName,
                              EmployeeAge = emp.Age,
                              AverageSalary = employee_temp.Average(s => s.Amount)

                          };


        Console.WriteLine("Mean of Monthly, Performance, Bonus salary of employees whose age is greater than 30");
        foreach (var emp in Query_temp3)
        {
            Console.WriteLine();
            Console.WriteLine($"Name : {emp.EmployeeName} \t Age :{emp.EmployeeAge} \t Average Salary: {emp.AverageSalary}");

        }
    }
}

public enum SalaryType
{
    Monthly,
    Performance,
    Bonus
}

public class Employee
{
    public int EmployeeID { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public int Age { get; set; }
}

public class Salary
{
    public int EmployeeID { get; set; }
    public int Amount { get; set; }
    public SalaryType Type { get; set; }
}