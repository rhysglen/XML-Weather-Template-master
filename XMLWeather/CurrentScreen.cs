using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {

        Pen drawPen = new Pen(Color.DarkSlateGray, 10);
        SolidBrush drawBrush = new SolidBrush(Color.DarkSlateGray);

        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityLabel.Text = Form1.days[0].location + " ,Ontario" ;
            currentLabel.Text = Form1.days[0].currentTemp;
            
            //cityOutput.Text = Form1.days[0].location;

            //tempLabel.Text = "Current Temp: " + Form1.days[0].currentTemp;
            //minOutput.Text = Form1.days[0].tempLow;
            //maxOutput.Text = Form1.days[0].tempHigh;

        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void CurrentScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(drawPen, 1, 1, 287, 497);
            e.Graphics.DrawArc(drawPen, 0, 200, 144, 144, 0, 180);
            e.Graphics.DrawArc(drawPen, 144, 200, 144, 144, 180, 180);

            Point point0 = new Point(0, 0);
            Point point1 = new Point(0, 200);
            Point point2 = new Point(7, 302);
            Point point3 = new Point(22, 323);
            Point point4 = new Point(90, 346);
            Point point5 = new Point(140, 292);
            Point point6 = new Point(145, 250);
            Point point7 = new Point(160, 222);
            Point point8 = new Point(180, 210);
            Point point9 = new Point(230, 200);
            Point point10 = new Point(250, 210);
            Point point11 = new Point(265, 220);
            Point point12 = new Point(290, 225);
            Point point13 = new Point(290, 0);

            Point[] points = { point0, point1, point2, point3, point4, point5, point6, point7, point8, point9,point10, point11, point12, point13};
           

            e.Graphics.FillClosedCurve(drawBrush, points);



        }
        public void FillClosedCurvePoint(PaintEventArgs e)
        {

          
        }
    }
}
