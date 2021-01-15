/*
 * I, David Jule, 000792459 certify that this material is my original work. 
 * No other person's work has been used without due acknowledgement.
 * 
 * Author: David Jule.
 * Date: September 27th, 2020.
 * 
 * Create a view that will be displayed on the console using the information gathered from Employee and Lab1 classes.
 * This class contains mostly design and formatting for the date table that will be displayed in the console.
 * 
 * 
 */

using System;

namespace Lab1
{
    /// <summary>
    /// Represents the view and formatting of the program. 
    /// Information is taken from class Lab1 and Employee to perform different formatting actions. 
    /// </summary>
    class EmployeeView
    {
        private Employee[] employees;
        public EmployeeView(Employee[] employees)
        {
            this.employees = employees;
        }

       

        /// <summary>
        /// Read the user input on the console and execute an action based on it.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool ProcessUserSelection()
        {
            
            DisplayByName(employees);
            DisplayMenu();
            
            while (true)
            {
                string input = Console.ReadLine();
                Console.Clear();
                

                if ((int.TryParse(input, out int userSelection) == false) ||
                        userSelection < 1 || userSelection > 6)
                {
                    
                    DisplayEmployees(employees);
                    DisplayMenu();
                    Console.WriteLine("Bad Input!. Please enter a value between 1 and 6.");
                    continue;
                }

                switch (userSelection)
                {
                    case 1:
                        DisplayByName(employees);
                        DisplayMenu();
                        continue;
                    case 2:
                        DisplayByNumber(employees);
                        DisplayMenu();
                        continue;
                    case 3:
                        DisplayByPayRate(employees);
                        DisplayMenu();
                        continue;
                    case 4:
                        DisplayByHours(employees);
                        DisplayMenu();
                        continue;
                    case 5:
                        DisplayByGrossPayment(employees);
                        DisplayMenu();
                        continue;
                }

                if (userSelection == 6)
                {
                    Console.Clear();
                    Console.WriteLine("Closing program now....");
                    break;
                }
            }
            return true;
        }


        /// <summary>
        /// Contains the main menu displayed for user option selection.
        /// </summary>
        private void DisplayMenu()
        {
            Console.WriteLine("\n1.Sort by Employee Name");
            Console.WriteLine("2.Sort by Employee Number");
            Console.WriteLine("3.Sort by Employee Pay Rate");
            Console.WriteLine("4.Sort by Employee Hours");
            Console.WriteLine("5.Sort by Employee Gross Pay");
            Console.WriteLine("\n6.Exit");
            Console.WriteLine("\nEnter choice:");
        }

        /// <summary>
        /// Display the List of employees using String Formatting.
        /// </summary>
        private void DisplayEmployees(Employee[] employees)
        {
            //Using String formatting to make a table and display the employees.
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("{0,-15} {1,8} {2,8} {3,8} {4,10} {5,25}\n\n", "Employee",
                "Number", "Rate", "Hours", "Gross Pay", "David's Company"));
            for (int i = 0; i < employees.Length; i++)
                sb.Append(String.Format("{0,-15} {1,8} {2,8:C2} {3,8:F} {4,10:C2}\n", 
                    employees[i].GetEmployeeName(), employees[i].GetEmployeeNumber(),
                    employees[i].GetEmployeePayRate(), employees[i].GetEmployeeHours(),
                    employees[i].GetGrossPayment()));

            Console.WriteLine(sb);
        }


        /// <summary>
        /// Display Employees List in ascending order by Name.
        /// </summary>
        /// <param name="employees">Array list of Employees</param>
        private void DisplayByName(Employee[] employeesList)
        {
            Lab1.Sort(employeesList, 1);
            DisplayEmployees(employeesList);
        }

        /// <summary>
        /// Display Employees List in ascending order by ID Number.
        /// </summary>
        /// <param name="employeesList"></param>
        private void DisplayByNumber(Employee[] employeesList)
        {
            Lab1.Sort(employeesList, 2);
            DisplayEmployees(employeesList);
        }

        /// <summary>
        /// Display Employees List in descending order by Pay Rate.
        /// </summary>
        /// <param name="employeesList"></param>
        private void DisplayByPayRate(Employee[] employeesList)
        {
            Lab1.Sort(employeesList, 3);
            DisplayEmployees(employeesList);
        }

        /// <summary>
        /// Display Employees List in descending order by Hours Worked.
        /// </summary>
        /// <param name="employeesList"></param>
        private void DisplayByHours(Employee[] employeesList)
        {
            Lab1.Sort(employeesList, 4);
            DisplayEmployees(employeesList);
        }

        /// <summary>
        /// Display Employees List in descending order by Gross Payment.
        /// </summary>
        /// <param name="employeesList"></param>
        private void DisplayByGrossPayment(Employee[] employeesList)
        {
            Lab1.Sort(employeesList, 5);
            DisplayEmployees(employeesList);
        }


    }
}
