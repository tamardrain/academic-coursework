using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sql
{
    public static class Functions_db
    {
        private static RentalDbContext dbContext = new RentalDbContext();

        // Retrieve employees residing in Tel-Aviv (or a specified city)
        public static List<EmployeeTbl> getByCity(string s)
        {
            return dbContext.EmployeeTbls.Where(c => c.City.Equals(s)).ToList();
        }

        // Delete employees whose salary is NULL
        public static List<EmployeePayTbl> delete()
        {
            List<EmployeePayTbl> e = dbContext.EmployeePayTbls.Where(x => x.Salary == null).ToList();
            dbContext.RemoveRange(e);
            dbContext.SaveChanges();
            return getAll();
        }

        // Retrieve all employee pay records
        public static List<EmployeePayTbl> getAll()
        {
            return dbContext.EmployeePayTbls.ToList();
        }

        // Raise salary for employees working at the company for over 20 years
        public static void updateSalary()
        {
            // Create a variable to calculate the year difference
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly twentyYearsAgo = today.AddYears(-20);

            List<EmployeePayTbl> emp = dbContext.EmployeePayTbls.Where(x => x.HireDate != null && x.HireDate <= twentyYearsAgo).ToList();
            emp.ForEach(e => e.Salary += 1000);
            dbContext.SaveChanges();
            Console.WriteLine("Salary updated successfully!");
        }

        // Add a car to the cars table
        //public static string addCar(CarsTbl c)
        //{
        //    dbContext.CarsTbls.Add(c);
        //    dbContext.SaveChanges();
        //    return c.CarId + " " + c.Company + " " + c.Model + " " + c.Seats + " " + c.PricePerMonth + " " + c.PricePerKm;
        //}

        public static List<RentalsTbl> getName(string name)
        {
            return dbContext.RentalsTbls.Include(i => i.Cust).Where(x => x.Cust != null && x.Cust.CustName == name).ToList();
        }
    }
}