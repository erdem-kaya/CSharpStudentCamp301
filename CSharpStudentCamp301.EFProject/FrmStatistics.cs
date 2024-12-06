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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        StudentCampEfTravelDbEntities db = new StudentCampEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
             
            //Total Locations Count
            lblLocationCount.Text = db.Location.Count().ToString();

            //Total Location Capacity
            lblSumCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();

            //Total Guides Count
            lblGuideCount.Text = db.Guide.Count().ToString();

            //Avarage Location Capacity
            lblAvarageCapacity.Text = db.Location.Average(x => x.LocationCapacity).ToString();

            //Avarage Location Price
            lblAverageLocationPrice.Text = db.Location.Average(x => (decimal?)x.LocationPrice).Value.ToString("0.00") + " kr";

            //Last Country Added
            //OrderByDescending (x => x.LocationId) : Order by LocationId in descending order
            //FirstOrDefault() : Get the first record

            //lblLastCountryAdded.Text = db.Location.OrderByDescending(x => x.LocationId).FirstOrDefault().LocationCountry;
            //or
            int lastLocationId = db.Location.Max(x => x.LocationId);
            lblLastCountryAdded.Text = db.Location.Where(x => x.LocationId == lastLocationId).Select(y=> y.LocationCountry).FirstOrDefault();

            //Kapadokya location count
            lblKapadokyaCapacity.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(y => y.LocationCapacity).FirstOrDefault().ToString();

            //Turkey capacity average
            lblTurkiyeCapacityAverage.Text = db.Location.Where(x => x.LocationCountry == "Turkiye").Average(y => y.LocationCapacity).ToString();

            //Roma operation GuideName
            var GuideId = db.Location.Where(x => x.LocationCity == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomaGuideName.Text = db.Guide.Where(x => x.GuideId == GuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault();

            //Location with the highest capacity
            var maxCapacity = db.Location.Max(x => x.LocationCapacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity ).Select(y => y.LocationCity).FirstOrDefault();

            //Most Expensive Location
            var maxPrice = db.Location.Max(x => x.LocationPrice);
            lblMostExpensiveTour.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationCity).FirstOrDefault();

            //Guide Erdem Kaya tour Count
            var guideId = db.Guide.Where(x => x.GuideName == "Erdem" && x.GuideSurname == "Kaya").Select(y => y.GuideId).FirstOrDefault();
            lblErdemKayaTourCount.Text = db.Location.Where(x => x.GuideId == guideId).Count().ToString();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblAvarageCapacity_Click(object sender, EventArgs e)
        {

        }

        private void lblLastCountryAdded_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
