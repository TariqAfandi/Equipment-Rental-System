using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_system_frontend
{
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //making a new form object for AddCategory and showing it as a dialog
            AddCategory frmAddCategory = new AddCategory();
            frmAddCategory.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //making a new form objext for UpdateCategory and showing it as a dialog
            //also pass an object with all the information of the selected cell (ID and name)
            UpdateCategory frmUpdateCategory = new UpdateCategory();
            frmUpdateCategory.ShowDialog();
        }
    }
}
