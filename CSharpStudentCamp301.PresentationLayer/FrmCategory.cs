using CSharpStudentCamp301.BusinessLayer.Abstract;
using CSharpStudentCamp301.BusinessLayer.Concrete;
using CSharpStudentCamp301.DataAccessLayer.EntityFramework;
using CSharpStudentCamp301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpStudentCamp301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnShowList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            {
                category.CategoryName = txtCategoryName.Text;
                category.CategoryStatus = true;
                _categoryService.TInsert(category);
                MessageBox.Show("Category Added!");
            };
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(txtCategoryID.Text);
            var deletedValues = _categoryService.TGetById(categoryId);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Category Deleted!");


        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(txtCategoryID.Text);
            var categoryValues = _categoryService.TGetById(categoryId);
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int categoryId = int.Parse(txtCategoryID.Text);
            var updatedValues = _categoryService.TGetById(categoryId);
            updatedValues.CategoryName = txtCategoryName.Text;
            updatedValues.CategoryStatus = true;
            _categoryService.TUpdate(updatedValues);
            MessageBox.Show("Category Updated!");
        }
    }
}
