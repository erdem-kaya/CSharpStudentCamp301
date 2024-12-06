using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpStudentCamp301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        StudentCampEfTravelDbEntities db = new StudentCampEfTravelDbEntities();

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                x.GuideId,
                GuideName = x.GuideName + " " + x.GuideSurname
            }).ToList();
            cmbGuide.DisplayMember = "GuideName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var location = new Location();
            location.LocationCity = txtLocationCity.Text;
            location.LocationCountry = txtLocationCountry.Text;
            location.LocationCapacity = Convert.ToByte(txtLocationCapacity.Text);
            location.LocationPrice = Convert.ToDecimal(txtLocationPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = Convert.ToInt32(cmbGuide.SelectedValue);

            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Location successfully added", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtLocationId.Text);
            var removeValue = db.Location.Find(id);
            db.Location.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Location successfully deleted", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtLocationId.Text);
            var updateValue = db.Location.Find(id);
            updateValue.LocationCity = txtLocationCity.Text;
            updateValue.LocationCountry = txtLocationCountry.Text;
            updateValue.LocationCapacity = Convert.ToByte(txtLocationCapacity.Text);
            updateValue.LocationPrice = Convert.ToDecimal(txtLocationPrice.Text);
            updateValue.DayNight = txtDayNight.Text;
            updateValue.GuideId = Convert.ToInt32(cmbGuide.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Location successfully updated", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtLocationId.Text);
            var getValue = db.Location.Where(x => x.LocationId == id).ToList();
            dataGridView1.DataSource = getValue;
            db.SaveChanges();
            
        }
    }
}
