using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTest.DAO;

namespace WinFormsTest
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            IEmployeeDAO dao = new EmployeeDaoImpl();
            Employee employee = new Employee(txtLastName.Text,txtFirstName.Text, Convert.ToInt32(txtAge.Text),new Address(Convert.ToInt32(txtNum.Text), txtStreet.Text));
            dao.AddEmployee(employee);

            MessageBox.Show("Employé bien ajouté");
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
