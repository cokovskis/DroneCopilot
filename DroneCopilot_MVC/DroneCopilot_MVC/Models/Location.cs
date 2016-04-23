using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DroneCopilot_MVC.Models
{
    public class Location
    {
        private string name;
        private double latitude;
        private double longitude;
        private double height;

        public Location()
        {
            name = "";
            latitude = 0.00;
            longitude = 0.00;
            height = 20.00;
        }
        public Location(double lat, double lon, double h, string name = "")
        {
            name = "";
            latitude = lat;
            longitude = lon;
            height = h;
        }

        void setLatitude(double lat)
        {
            latitude = lat;
        }
        void setLongitude(double lon)
        {
            longitude = lon;
        }
        void setHeight(double h)
        {
            height = h;
        }

        double getLatitude()
        {
            return latitude;
        }
        double getLongitude()
        {
            return longitude;
        }
        double getHeight()
        {
            return height;
        }

        string toString()
        {
            return latitude.ToString() + ", " + longitude.ToString() + " at " + height.ToString() + "m";
        }

    }
}