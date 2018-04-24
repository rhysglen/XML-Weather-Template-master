using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, currentTemp,sunRise,sunSet, currentTime,humidity,condition, location, tempHigh, tempLow, 
            windSpeed, windDirection, precipitation, visibility;

        public Day()
        {
            date = currentTemp = currentTime = sunRise = sunSet = condition = humidity = location = tempHigh = tempLow
                = windSpeed = windDirection = precipitation = visibility = "";
        }
    }
}
