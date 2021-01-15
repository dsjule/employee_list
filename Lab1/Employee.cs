/*
 * I, David Jule, 000792459 certify that this material is my original work. 
 * No other person's work has been used without due acknowledgement.
 * 
 * Author: David Jule.
 * Date: September 27th, 2020.
 * 
 * Create an object that contains information for an Employee
 * Attributes included in this program are: Name, ID, Payment Rate, Hours Worked.
 * 
 * Gross payment is calculated after object is created. It is not a parameter of the object.
 */


namespace Lab1
{
    /// <summary>
    /// Employee class . Contains: Name, ID Number, Payment Rate and Hours Worked.
    /// </summary>
    class Employee
    {
        private string name;
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;

        /// <summary>
        /// Create an object of type Employee.
        /// </summary>
        /// <param name="name">String value for Employee's name/param>
        /// <param name="number">Integer signed number for an Eployee's ID</param>
        /// <param name="rate">Decimal number for Payment rate</param>
        /// <param name="hours">Double number for Hours worked</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        /// <summary>
        /// Calculate gross payment from employee.
        /// </summary>
        /// <returns>decimal</returns>
        public decimal GetGrossPayment()
        {
            //Overtime
            if (hours > 40)
            {
                double extraHours = hours - 40;
                decimal grossExtraHours = ((decimal)extraHours*(rate*1.5M));
                decimal grossNormalHours = 40M * rate;
                decimal total = grossExtraHours + grossNormalHours;
                return total;

            }
            else
                gross = (decimal)hours * rate;

            return gross;
        }
        /// <summary>
        /// Get hours worked by Employee.
        /// </summary>
        /// <returns>Double</returns>
        public double GetEmployeeHours() { return hours; }

        /// <summary>
        /// Get the name of the Employee.
        /// </summary>
        /// <returns>String</returns>
        public string GetEmployeeName() { return name; }

        /// <summary>
        /// Get the ID number of the Employee.
        /// </summary>
        /// <returns>Integer</returns>
        public int GetEmployeeNumber() { return number; }

        /// <summary>
        /// Get the payment rate of the Employee
        /// </summary>
        /// <returns>Decimal</returns>
        public decimal GetEmployeePayRate() { return rate; }

        /// <summary>
        /// Set hours worked by Employee.
        /// </summary>
        /// <param name="hours">Double</param>
        public void SetWorkedHours(double hours) { this.hours = hours; }

        /// <summary>
        /// Set the name of the Employee.
        /// </summary>
        /// <param name="name">String</param>
        public void SetEmployeeName(string name) { this.name = name; }

        /// <summary>
        /// Set the ID number of the Employee.
        /// </summary>
        /// <param name="number">Integer</param>
        public void SetEmployeeNumber(int number) { this.number = number; }

        /// <summary>
        /// Se the payment rate of the Employee.
        /// </summary>
        /// <param name="rate">Decimal</param>
        public void SetPayRate(decimal rate) { this.rate = rate; }

        /// <summary>
        /// Return the values of the Employee in a formated String value.
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return $"{name},{number},{rate},{hours}";
        }

    }
}
