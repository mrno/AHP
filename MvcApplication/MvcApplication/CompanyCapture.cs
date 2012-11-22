using System;
using System.Windows.Forms;
using FryHard.MvcApplication.Controller;
using FryHard.MvcApplication.Controller.Interfaces;
using FryHard.MvcApplication.Domain;
using FryHard.MvcApplication.Domain.Interfaces;

namespace FryHard.MvcApplication
{
    public partial class CompanyCapture : Form, ICompanyCapture
    {
        public CompanyCapture()
        {
            MyData = new Company();
            InitializeComponent();
        }

        public CompanyCapture(Company company) : this()
        {
            MyData = company;
        }

        public IBaseObject MyData { get; set; } 
        public ICaptureController MyController { get; set; }
        
        private void InitForm ()
        {
            bindingSource1.DataSource = MyData;
            MyController = new CompanyCaptureController(this);
            MyController.Load();
        }

        private void CompanyCapture_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "MVC Appliction", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyController.Save(MyData);
        }

        public void SaveComplete(IBaseObject savedItem)
        {
            // Update the view
            MessageBox.Show("Save successfull");
        }

        public void LoadComplete(IBaseObject loadItem)
        {
            // Update the view
            MyData = loadItem;
            bindingSource1.DataSource = MyData;
        }

        public void RefreshComplete(IBaseObject refreshItem)
        {
            // Update the view
            MyData = refreshItem;
            bindingSource1.DataSource = MyData;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                PersonCapture person = new PersonCapture((Person)dataGridView1.SelectedRows[0].DataBoundItem);
                person.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ((CompanyCaptureController)MyController).Refresh();
        }
    }
}
