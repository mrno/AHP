using System;
using System.Windows.Forms;
using FryHard.MvcApplication.Controller;
using FryHard.MvcApplication.Controller.Interfaces;
using FryHard.MvcApplication.Domain;
using FryHard.MvcApplication.Domain.Interfaces;

namespace FryHard.MvcApplication
{
    public partial class PersonCapture : Form, ICapture
    {
        public PersonCapture()
        {
            MyData = new Person();
            InitializeComponent();
        }

        public PersonCapture(Person person) : this()
        {
            MyData = person;
        }

        public IBaseObject MyData { get; set; }
        public ICaptureController MyController { get; set; }
        
        private void PersonCapture_Load(object sender, EventArgs e)
        {
            InitForm();
        } 

        private void InitForm ()
        {
            bindingSource1.DataSource = MyData;
            MyController = new PersonCaptureController(this);
        }

        public void SaveComplete(IBaseObject savedItem)
        {
            // Update the view
            MyData = savedItem;
            bindingSource1.DataSource = MyData;
            MessageBox.Show("Save successfull");
        }

        public void LoadComplete(IBaseObject loadItem)
        {
            // Update the view
            MyData = loadItem;
            bindingSource1.DataSource = MyData;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel?", "MVC Appliction", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyController.Save(MyData);
        }
    }
}
