using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DroneCopilotServices
{
    enum WeatherFormat
    {
        XML, JSON, HTML
    };

    public class Weather
    {
        private string cityName;
        private double lat;
        private double lon;
        private bool metric;
        private bool accurate;

        Weather(string cityName = "Skopje", double lat = 42, double lon = 21.43, bool metric = true, bool accurate = true)
        {
            this.cityName = cityName;
            this.lat = lat;
            this.lon = lon;
            this.metric = metric;
            this.accurate = accurate;
        }
        string getCityName()
        {
            return cityName;
        }
        double getLatitude()
        {
            return lat;
        }
        double getLongitude()
        {
            return lon;
        }
        bool isMetric()
        {
            return metric;
        }
        bool isAccurate()
        {
            return accurate;
        }
    }
    public class WeatherData
    {
        readonly string baseUri = "http://api.openweathermap.org/data/2.5/";
        string appID;
        private string locationName;
        private string requestInit;
        private double latitude;
        private double longitude;
        private bool metric;
        private bool accurate;
        WeatherFormat format;

        public WeatherData()
        {
            appID = "904fba3186bd743f13e87be949d4c02a";
            requestInit = "weather?";
            latitude = 42.00;
            longitude = 21.43;
            metric = true;
            accurate = false;
            locationName = "";
            format = WeatherFormat.JSON;
        }
        public WeatherData(string appID)
        {
            this.appID = appID;
            requestInit = "weather?";
            latitude = 42.00;
            longitude = 21.43;
            metric = true;
            accurate = false;
            format = WeatherFormat.JSON;
            locationName = "";
        }

        public void setLatitude(double lat)
        {
            latitude = lat;
        }
        public void setLongitude(double lon)
        {
            longitude = lon;
        }

        public string receiveData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string request = string.Empty;

                request += requestInit + "appid=" + appID;
                if (locationName != "")
                {
                    request += "&q=" + locationName;
                }
                else
                {
                    if (latitude != 0.00)
                        request += "&lat=" + latitude;
                    if (longitude != 0.00)
                        request += "&lon=" + longitude;
                }
                if (metric)
                    request += "&units=metric";
                else
                    request += "&units=imperial";
                if (accurate)
                    request += "&type=accurate";
                else
                    request += "&type=like";

                switch (format)
                {
                    case WeatherFormat.XML:
                        {
                            request += "&mode=xml";
                            break;
                        }
                    case WeatherFormat.JSON:
                        {
                            request += "&mode=json";
                            break;
                        }
                    case WeatherFormat.HTML:
                        {
                            request += "&mode=html";
                            break;
                        }
                    default:
                        {
                            request += "&mode=json";
                            break;
                        }
                }
                HttpResponseMessage response = client.GetAsync(request).Result;
                response.EnsureSuccessStatusCode();


                string result = string.Empty;
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result;
                else
                    result = "Error fetching data";
                
                return result;
            }
        }



    }
}
