using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace EmployeeRecords
{
    public partial class formEmployeeDetails : Form
    {
        public formEmployeeDetails()
        {
            InitializeComponent();
        }


        List<Developer> myDev = new List<Developer>();

        private void btnRead_Click(object sender, EventArgs e)
        {
            string[] temp;

            if (File.Exists("..\\employeedata.txt"))
            {
                TextFieldParser parser = new TextFieldParser("..\\employeedata.txt");

                parser.Delimiters = new string[] { "," };
                int devCount = 0;
                int tempCount = 0;
                while (true)
                {
                    temp = parser.ReadFields();
                    if (temp == null)
                    {
                        break;
                    }

                    myDev.Add(new Developer());  //create class for dev record
                    myDev[devCount].firstName = temp[tempCount];
                    myDev[devCount].lastName = temp[tempCount + 1];
                    myDev[devCount].stAddr = temp[tempCount + 2];
                    myDev[devCount].city = temp[tempCount + 3];
                    myDev[devCount].state = temp[tempCount + 4];
                    myDev[devCount].zip = temp[tempCount + 5];
                    myDev[devCount].age = temp[tempCount + 6];

                    double devMonPay = Double.Parse(temp[tempCount + 7]);
                    myDev[devCount].grossMonPay = devMonPay;

                    myDev[devCount].deptID = temp[tempCount + 8];
                    myDev[devCount].devType = temp[tempCount + 9];
                    myDev[devCount].empType = temp[tempCount + 10];

                    devCount++;  //increment count for next loop
                }
            }

            else
            {
                lblDisplayText.Text = "File Unavailalbe";
            }

            lblDisplayText.Text = "All Records Have Been Read";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {

            pnlDisplay.Visible = true;

            foreach (Developer DevRec in myDev)
            {
                txtFirstName.Text = DevRec.firstName;
                txtLastName.Text = DevRec.lastName;
                txtStAddr.Text = DevRec.stAddr;
                txtCity.Text = DevRec.city;
                txtState.Text = DevRec.state;
                txtZip.Text = DevRec.zip;
                txtAge.Text = DevRec.age;
                txtMonGrossPay.Text = (DevRec.grossMonPay).ToString();
                txtDeptID.Text = DevRec.deptID;
                txtDevType.Text = DevRec.devType;
                txtEmpType.Text = DevRec.empType;

                double annualTax = DevRec.taxes(DevRec.grossMonPay);
                txtAnnTaxes.Text = annualTax.ToString();

                double annualIncome = DevRec.netPay(DevRec.grossMonPay, annualTax);
                txtAnnNetPay.Text = annualIncome.ToString();

                pnlDisplay.Refresh();

                Thread.Sleep(2000);
            }

            lblDisplayText.Text = "End of Records";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchResults = from item in myDev
                                where item.lastName == txtLastName.Text
                                select item;

            pnlDisplay.Visible = true;

            foreach (var item in searchResults)
            {
                txtFirstName.Text = item.firstName;
                txtLastName.Text = item.lastName;
                txtStAddr.Text = item.stAddr;
                txtCity.Text = item.city;
                txtState.Text = item.state;
                txtZip.Text = item.zip;
                txtAge.Text = item.age;
                txtMonGrossPay.Text = (item.grossMonPay).ToString();
                txtDeptID.Text = item.deptID;
                txtDevType.Text = item.devType;
                txtEmpType.Text = item.empType;

                double annualTax = item.taxes(item.grossMonPay);
                txtAnnTaxes.Text = annualTax.ToString();

                double annualIncome = item.netPay(item.grossMonPay, annualTax);
                txtAnnNetPay.Text = annualIncome.ToString();
            }

            lblDisplayText.Text = "Search Complete";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtStAddr.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtState.Text = String.Empty;
            txtZip.Text = String.Empty;
            txtAge.Text = String.Empty;
            txtMonGrossPay.Text = String.Empty;
            txtDeptID.Text = String.Empty;
            txtDevType.Text = String.Empty;
            txtEmpType.Text = String.Empty;
            txtAnnTaxes.Text = String.Empty;
            txtAnnNetPay.Text = String.Empty;

            lblDisplayText.Text = "";
        }

        //I can't figure out how to modify the list or file.
        //I have ideas, which would compare the new input to the existing record, but I can't figure out how to do that.
        //I think indexing is needed, but I must have skipped/missed that chapter, and am having some difficulty understanding that concept at this moment.
        /*
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] tempToJoin = { txtFirstName.Text, txtLastName.Text, txtStAddr.Text, txtCity.Text, txtState.Text, txtZip.Text, txtAge.Text,
                txtMonGrossPay.Text, txtDeptID.Text, txtDevType.Text, txtEmpType.Text };

            var joinString = string.Join(",", tempToJoin);



            lblDisplayText.Text = "The record has been updated";
        }
        */
    }
}
