using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Clothes.Model
{
    public class WeatherInfo
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string Icon { get { return $"{Application.StartupPath}/icon/{icon}.png"; } }
    }
}