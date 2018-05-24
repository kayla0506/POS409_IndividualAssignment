using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords
{
    public abstract class Employee //this information will not change.  all employees will have this info.
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string stAddr { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string age { get; set; }
        public double grossMonPay;
        public string deptID { get; set; }
        public string empType;

        public virtual double taxes(double grossMonPay)
        {
            if (empType == "W2")
            {
                double annual = (grossMonPay * 12) * 0.30;
                return annual;
            }

            else
            {
                return 0;
            }
            
        }

        public virtual double netPay(double grossMonPay, double taxes)
        {
            double netPay = (grossMonPay * 12) - taxes;
            return netPay;
        }
    }

    public class Developer : Employee  //this information will change
    {
        public string devType { get; set; }
    }
}
