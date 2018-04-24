using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // TODO: create list to hold day objects
        public static List<Day> days = new List<Day>();
        Day d = new Day();

        public Form1()
        {
            InitializeComponent();
            GetData();
            ExtractCurrent();
            ExtractForecast();

            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        private static void GetData()
        {
            WebClient client = new WebClient();

            // one day forecast
            client.DownloadFile("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0", "WeatherData.xml");
            // mulit day forecast
            client.DownloadFile("http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0", "WeatherData7Day.xml");
        }

        private void ExtractCurrent()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData.xml");

            XmlNode city = doc.SelectSingleNode("current/city");
            XmlNode temp = doc.SelectSingleNode("current/temperature");
            XmlNode windSpeed = doc.SelectSingleNode("current/wind/speed");
            XmlNode windDirection = doc.SelectSingleNode("current/wind/direction");
            XmlNode precipitation = doc.SelectSingleNode("current/precipitation");
            XmlNode conditions = doc.SelectSingleNode("current/weather");
            XmlNode sunset = doc.SelectSingleNode("current/city/sun");
            XmlNode sunrise = doc.SelectSingleNode("current/city/sun");
            XmlNode humidity = doc.SelectSingleNode("current/humidity");

            Day d = new Day();

            d.location = city.Attributes["name"].Value;
            d.currentTemp = temp.Attributes["value"].Value;
            d.tempHigh = temp.Attributes["max"].Value;
            d.tempLow = temp.Attributes["min"].Value;
            d.condition = conditions.Attributes["value"].Value;
            d.sunRise = sunrise.Attributes["rise"].Value;
            d.sunSet = sunset.Attributes["set"].Value;
            d.windDirection = windDirection.Attributes["name"].Value;
            d.windSpeed = windSpeed.Attributes["name"].Value;
            d.humidity = humidity.Attributes["value"].Value;


            days.Add(d);
        }
              
        private void ExtractForecast()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData7Day.xml");

            XmlNodeList dateList = doc.GetElementsByTagName("time");
            XmlNodeList templist = doc.GetElementsByTagName("temperature");
            XmlNodeList cloudlist = doc.GetElementsByTagName("clouds");
            XmlNodeList precipList = doc.GetElementsByTagName("symbol");
            XmlNodeList windSpeedList = doc.GetElementsByTagName("windSpeed");
            XmlNodeList windDirList = doc.GetElementsByTagName("windDirection");

            for (int i = 1; i < templist.Count; i++)
            {
                d = new Day();
                d.date = dateList[i].Attributes["day"].Value;
                d.tempHigh = templist[i].Attributes["max"].Value;
                d.tempLow = templist[i].Attributes["min"].Value;
                d.condition = cloudlist[i].Attributes["value"].Value;
                d.precipitation = precipList[i].Attributes["name"].Value;
                d.windDirection = windDirList[i].Attributes["name"].Value;
                d.windSpeed = windSpeedList[i].Attributes["name"].Value;

                days.Add(d);
            }


        }
    }
}
