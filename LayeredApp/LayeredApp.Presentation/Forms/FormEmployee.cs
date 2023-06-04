using LayeredApp.Domain.Models;
using LayeredApp.Domain.ValueObjects;
using LayeredApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayeredApp.Presentation.Forms
{
    public partial class FormEmployee : Form
    {

        private readonly EmployeeModel _employeeModel = new EmployeeModel(); 

        public FormEmployee()
        {
            InitializeComponent();
            panel1.Enabled = false;
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            ListEmployees();
        }

        private void ListEmployees()
        {
            try
            {
                dataGridView1.DataSource = _employeeModel.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = _employeeModel.GetByPattern(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = _employeeModel.GetByPattern(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _employeeModel.Number = txtEmployeeNumber.Text.Trim();
            _employeeModel.Name = txtEmployeeName.Text.Trim();
            _employeeModel.Mail = txtEmployeeEmail.Text.Trim();
            _employeeModel.Birthday = dtpEmployeeBirthday.Value;

            bool isValid = new DataValidation(_employeeModel).Validate();
            if (isValid)
            {
                string result = _employeeModel.SaveChanges();
                MessageBox.Show(result);
                ListEmployees();
                Restart();
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            _employeeModel.State = EntityState.Added;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                panel1.Enabled = true;
                _employeeModel.State = EntityState.Modified;

                var currentRowCells = dataGridView1.CurrentRow.Cells;
                _employeeModel.EmployeeID = Convert.ToInt32(currentRowCells[0].Value); // First column
                txtEmployeeNumber.Text = currentRowCells[1].Value.ToString();
                txtEmployeeName.Text = currentRowCells[2].Value.ToString();
                txtEmployeeEmail.Text = currentRowCells[3].Value.ToString();
                dtpEmployeeBirthday.Value = Convert.ToDateTime(currentRowCells[4].Value);

                return;
            }

            MessageBox.Show("Select a row");
        }

        private void Restart()
        {
            txtEmployeeName.Text = string.Empty;
            txtEmployeeNumber.Text = string.Empty;
            dtpEmployeeBirthday.Value = DateTime.Now;
            txtEmployeeEmail.Text = string.Empty;

            panel1.Enabled = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _employeeModel.State = EntityState.Deleted;

                var currentRowCells = dataGridView1.CurrentRow.Cells;
                _employeeModel.EmployeeID = Convert.ToInt32(currentRowCells[0].Value); // First column
                string message = _employeeModel.SaveChanges();
                ListEmployees();
                MessageBox.Show(message);

                return;
            }

            MessageBox.Show("Select a row");
        }
    }
}
