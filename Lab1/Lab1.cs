/*
 * I, David Jule, 000792459 certify that this material is my original work. 
 * No other person's work has been used without due acknowledgement.
 * 
 * Author: David Jule.
 * Date: September 27th, 2020.
 * 
 * Main class of the program. 
 * Read, format, sort and create lists of employees from text files to create a data table.
 * 
 * 
 */

using System;
using System.IO;
using System.Linq;

namespace Lab1
{
    /// <summary>
    /// Main class of this program. Analyzes and structures the information retrieved from the files that will be used to create the view of the program.
    /// </summary>
    class Lab1
    {
        /// <summary>
        /// Main method used to generate a List of employees that will be used to be displayed in the console.
        /// Processes user selection and calls for EmployeeView class.
        /// </summary>
        /// <param name="args">Not used in this context.</param>
        static void Main(string[] args)
        {
            
            //Load Employees List
            Employee[] employeesList = Read();

            if (employeesList != null)
            {
                EmployeeView employeeView = new EmployeeView(employeesList);
                employeeView.ProcessUserSelection();
            }
            else
            {
                Console.WriteLine("Program Terminated due to exception. Click any key to exit.");
            }
        }


        /// <summary>
        /// Read the file containing the list of employees and create an array with them.
        /// </summary>
        /// <returns>Array of type Employee</returns>
        private static Employee[] Read()
        {
            int amountOfEmployees = GetAmountOfEmployees();
            Employee[] employees = GenerateEmployeesList(amountOfEmployees);
            return employees;
        }

        /// <summary>
        /// Compare the first letter of a String and assign a value from 0 to 26 (A-Z),
        /// depending on its position in the alphabet.
        /// </summary>
        /// <returns>Integer signed number</returns>
        private static int GetLetterValue(string employeeName)
        {
            //get character that will be compared.
            char comparison = employeeName.FirstOrDefault();
            int value = 'A'.CompareTo(comparison);

            return value;
        }


        /// <summary>
        /// Sort the list of employees: METHOD: 
        /// 1. for Name sort sort(default)(ascending). 
        /// 2. for ID sort.(ascending)
        /// 3. for Pay Rate sort(descending).
        /// 4. for Hours sort(descending).
        /// 5. for Gross Pay sort(descending).
        /// </summary>
        /// <param name="unsortedEmployeesList">List of object type Employee to be sorted</param>
        /// <param name="method">Sort method (Default to 1).</param>
        /// <returns></returns>
        public static Employee[] Sort(Employee[] employeesList, int method = 1)
        {
            switch (method)
            {
                case 1:
                    SortByName(employeesList);
                    return employeesList;
                case 2:
                    SortByNumber(employeesList);
                    return employeesList;
                case 3:
                    SortByPayRate(employeesList);
                    return employeesList;
                case 4:
                    SortByHoursWorked(employeesList);
                    return employeesList;
                case 5:
                    SortByGrossPayment(employeesList);
                    return employeesList;
            }
            return null;
        }

        /// <summary>
        /// Sort Employees' List by Name in ascending order.
        /// </summary>
        /// <param name="employeeList">Object array of type Employee</param>
        static void SortByName(Employee[] employeeList)
        {
            for (int i = 0; i < employeeList.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < employeeList.Length; j++)
                {
                    if (GetLetterValue(employeeList[j].GetEmployeeName()) > 
                        GetLetterValue(employeeList[min].GetEmployeeName()))
                    {
                        min = j;
                    }

                }
                Employee temp = employeeList[i];
                employeeList[i] = employeeList[min];
                employeeList[min] = temp;
            }
        }

        /// <summary>
        /// Sort Employees' List by ID Number in ascending order.
        /// </summary>
        /// <param name="employeeList">Object array of type Employee</param>
        static void SortByNumber(Employee[] employeeList)
        {
            for (int i = 0; i < employeeList.Length - 1; i++)
            {
                int min = i;
                for (int j = i+1; j < employeeList.Length; j++)
                {
                    if(employeeList[j].GetEmployeeNumber() < employeeList[min].GetEmployeeNumber())
                    {
                        min = j;
                    }

                }
                Employee temp = employeeList[i];
                employeeList[i] = employeeList[min];
                employeeList[min] = temp;
            }
        }

        /// <summary>
        /// Sort Employees' List by Pay Rate in descending order.
        /// </summary>
        /// <param name="employeeList">Object array of type Employee</param>
        static void SortByPayRate(Employee[] employeeList)
        {
            for (int i = 0; i < employeeList.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < employeeList.Length; j++)
                {
                    if(employeeList[j].GetEmployeePayRate() > employeeList[min].GetEmployeePayRate())
                    {
                        min = j;
                    }

                }
                Employee temp = employeeList[i];
                employeeList[i] = employeeList[min];
                employeeList[min] = temp;
            }
        }

        /// <summary>
        /// Sort Employees' List by Hours Worked in descending order.
        /// </summary>
        /// <param name="employeeList">Object array of type Employee</param>
        static void SortByHoursWorked(Employee[] employeeList)
        {
            for (int i = 0; i < employeeList.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < employeeList.Length; j++)
                {
                    if (employeeList[j].GetEmployeeHours() > employeeList[min].GetEmployeeHours())
                    {
                        min = j;
                    }

                }
                Employee temp = employeeList[i];
                employeeList[i] = employeeList[min];
                employeeList[min] = temp;
            }
        }

        /// <summary>
        /// Sort Employees' List by Gross Payment in descending order.
        /// </summary>
        /// <param name="employeeList">Object array of type Employee</param>
        static void SortByGrossPayment(Employee[] employeeList)
        {
            for (int i = 0; i < employeeList.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < employeeList.Length; j++)
                {
                    if (employeeList[j].GetGrossPayment() > employeeList[min].GetGrossPayment())
                    {
                        min = j;
                    }

                }
                Employee temp = employeeList[i];
                employeeList[i] = employeeList[min];
                employeeList[min] = temp;
            }
        }


        /// <summary>
        /// Generate an Array of type Employee based on the data retrieved from a text file.
        /// If not file is found "null" will be returned.
        /// </summary>
        /// <param name="amountOfEmployees"></param>
        /// <returns>Array of Type Employee, null</returns>
        private static Employee[] GenerateEmployeesList(int amountOfEmployees)
        {
            int count = 0;
            FileStream fs = null;
            StreamReader sr = null;
            //Flag to stop the program if the process of getting employees' number was not successful
            if (amountOfEmployees > 0)
            {
                //Create a list of employees with a range based on the file lines found.
                Employee[] employeesList = new Employee[amountOfEmployees];
                try
                {

                    fs = new FileStream(@"..\..\employees.txt", FileMode.Open);
                    sr = new StreamReader(fs);

                    //Loop though the list and parse the respective values. Then, create an object and store it in an array.
                    while (!sr.EndOfStream && count < employeesList.Length)
                    {
                        string line = sr.ReadLine();

                        string[] elements = line.Split(',');
                        string name = elements[0];
                        if (elements.Length > 4)
                        {
                            Console.WriteLine($"!Failed to process all of the the employee {elements[0]}'s properties from the file as it contains more than 4 values.\n");
                        }
                        if (int.TryParse(elements[1], out int number) == false)
                            Console.WriteLine("!Failed to parse the employee number from the file");
                        if (decimal.TryParse(elements[2], out decimal rate) == false)
                            Console.WriteLine("!Failed to parse the pay rate from the file");
                        if (double.TryParse(elements[3], out double hours) == false)
                            Console.WriteLine("!Failed to parse the hours worked from the file");

                        employeesList[count] = new Employee(name, number, rate, hours);
                        count++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"!Exception loading Employees from file due to: {ex.Message}");
                    return null;
                }
                //Close the streams 
                finally
                {
                    if (fs != null)
                        fs.Close();
                    if (sr != null)
                        sr.Close();
                }
                return employeesList;
            }
            else
            {
                Console.WriteLine("\n-The program was not able to begin properly." +
                    "\n-Please check the errors mentioned above and try again.");
                return null;
            }
        }

        /// <summary>
        /// Read a file line by line to determine the amount of employees in the file.
        /// The number of Employees cannot exceed 100.
        /// If the process is completed succesfully, a value greater than 0 will be returned.
        /// </summary>
        /// <returns>Integer signed value</returns>
        private static int GetAmountOfEmployees()
        {
            int lineCount;
            try
            {
                //Count how many employees are listed in the file by reading each line
                lineCount = File.ReadLines(@"..\..\employees.txt").Count();
                
                //Set flag for a limit of how many employees can be created.
                if(lineCount == 0)
                {
                    Console.WriteLine("!Could not create an employee list as the number of employees is not greater than 0");
                    return 0;
                }
                else if(lineCount > 100)
                {
                    Console.WriteLine("!Could not create an employee list as the number of employees is greater than 100");
                    return 0;
                }
                else { return lineCount; }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"!Exception reading number of employees from file due to: {ex.Message}");
                return 0;
            }
        }
    }
}
