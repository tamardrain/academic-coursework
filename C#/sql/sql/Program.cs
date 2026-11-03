using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using sql;

namespace sql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("live in tel aviv: ");
            Functions_db.getByCity("Tel Aviv").ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));
            // Output:
            // live in tel aviv:
            // Yosef Levy
            // Gershon Chaviv
            // Natan Choen
            //--------------------
            // Retrieving the list of employee salaries
            Functions_db.getAll().ForEach(x => { Console.WriteLine(x.EmpId); });
            Console.WriteLine("Number of records: " + Functions_db.getAll().Count);
            // Deleting employees with NULL salary
            Functions_db.delete();
            // Output:
            // 036974101
            // 123456789
            // 301120514
            // 301120514
            // 654321987
            // 987654321
            // Number of records: 6
            // Retrieving the list of employee salaries again
            Functions_db.getAll().ForEach(x => { Console.WriteLine(x.EmpId); });
            Console.WriteLine("Number of records: " + Functions_db.getAll().Count);
            // Output:
            // 123456789
            // 301120514
            // 654321987
            // 987654321
            // Number of records: 4
            Functions_db.getAll().ForEach(x => { Console.WriteLine(x.EmpId + " " + x.Salary); });
            // Output:
            // 123456789 5000
            // 301120514 7000
            // 654321987 12000
            // 987654321 1500
            Functions_db.updateSalary();
            // Salary updated successfully!
            Functions_db.getAll().ForEach(x => { Console.WriteLine(x.EmpId + " " + x.Salary); });
            // Output:
            // 123456789 6000
            // 301120514 7000
            // 654321987 13000
            // 987654321 2500

            Functions_db.getName("Gidon").ForEach(x => Console.WriteLine(x.CustId));
            // Output:
            // 3

            // CarsTbl car = new CarsTbl
            // {
            //     // The ID field is not set to auto-increment in the database
            //     // What to do?
            //     Company = "Honda",
            //     Model = "civic",
            //     Seats = 5,
            //     PricePerMonth = 3900,
            //     PricePerKm = 0.9m
            // };
            // Console.WriteLine(Functions_db.addCar(car));
            // Output:
            // 104 Honda civic 5 3900 0.9

            Console.ReadLine();
        }
    }
}