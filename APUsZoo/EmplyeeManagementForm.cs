using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//By Ingeborg Asplund 2018
/// <summary>
/// This script handles the behind the scenes events for the GUI of employeemanagement form such as adding deleting and changing qualifications
/// </summary>
namespace APUsZoo
{
    public partial class EmplyeeManagementForm : Form
    {
        private Employee emp;
        private string qualify;
        /// <summary>
        /// Thi firt method creates a new employee in the event that tehre is no employee already existing when the form is opened.
        /// </summary>
        public EmplyeeManagementForm()
        {
            InitializeComponent();
            if (emp == null)
                emp = new Employee();
            InitGUI();
        }
        /// <summary>
        /// Public property for this class employee object accessed by methods within the class and by main form.
        /// </summary>
        public Employee Employee
        {
            get { return emp; }
            set { emp = value; }
        }
        /// <summary>
        /// Initialize GUI and make sure it i clean and that the change and deletebuttons are not clickable before anything is added to the list
        /// </summary>
        private void InitGUI()
        {
            lstQualifications.Items.Clear();
            txtEmployerName.Text = string.Empty;
            txtQualification.Text = string.Empty;
            btnChangeQual.Enabled = false;
            btnDeleteQual.Enabled = false;
  
        }
        /// <summary>
        /// Button for adding a qualification to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddQual_Click(object sender, EventArgs e)
        {
            qualify = txtQualification.Text;
            bool addable = ValidInput(qualify);
            if (addable)
            {
                Employee.Qualifications.Add(qualify);
                UpdateGUI();
            }
            else
                MessageBox.Show("Cannot add an empty qualification to an employees list of qualifications");
        }
        /// <summary>
        /// Button for changing a qualification for the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeQual_Click(object sender, EventArgs e)
        {
            qualify = txtQualification.Text;
            int indexToChange = lstQualifications.SelectedIndex;
            bool changeable = ValidInput(qualify);
            if (changeable)
            {
                Employee.Qualifications.Change(qualify, lstQualifications.SelectedIndex);
                UpdateGUI();
            }
            else
                MessageBox.Show("The qualification cannot be changed to an empty line");
        }
        /// <summary>
        /// Button for deleting a qualification from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteQual_Click(object sender, EventArgs e)
        {
            int deleteIndex = lstQualifications.SelectedIndex;
            if (deleteIndex != -1)
            {
                Employee.Qualifications.Delete(lstQualifications.SelectedIndex);
                UpdateGUI();

            }
            else
                MessageBox.Show("The item you want to delete do not exist in the current context");
        
        }        
        /// <summary>
        /// Event fired whenever the user selects an item in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstQualifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQualifications.SelectedIndex != -1)
            {
                qualify = lstQualifications.SelectedItem.ToString();
                txtQualification.Text = qualify;
                btnChangeQual.Enabled = true;
                btnDeleteQual.Enabled = true;
            }            
        }
        /// <summary>
        /// Button that adds that gives the output needed for adding the final employee to the listbox in main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string name = txtEmployerName.Text;
            bool validName = ValidInput(name);
            if (validName)
                Employee.Name = name;
            else
                MessageBox.Show("Make sure your employee has a name");
        }
        /// <summary>
        /// Function that hinder empty string from being entered
        /// </summary>
        /// <param name="checkMe"></param>
        /// <returns></returns>
        private bool ValidInput(string checkMe)
        {
            if (!string.IsNullOrEmpty(checkMe))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Function that updates the GUI after adding deleting or changing an item in the employee object
        /// </summary>
        private void UpdateGUI()
        {
            txtQualification.Text = String.Empty;
            btnChangeQual.Enabled = false;
            btnDeleteQual.Enabled = false;
            lstQualifications.Items.Clear();
            lstQualifications.Items.AddRange(Employee.Qualifications.PresentArray());
        }
    }
}
