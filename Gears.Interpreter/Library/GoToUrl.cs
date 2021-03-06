#region LICENSE
/*
Copyright 2016 Ondrej Homola <ondra.homola@gmail.com>

This file is part of Gears, a software automation and assistance framework.

Gears is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Gears is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion
using System;
using System.Xml.Serialization;
using Gears.Interpreter.Applications.Debugging.Overlay;
using Gears.Interpreter.Core.Registrations;

namespace Gears.Interpreter.Library
{
    public class GoToUrl : Keyword
    {
        public string Url { get; }

        [Wire]
        [XmlIgnore]
        public IOverlay Overlay { get; set; }

        public GoToUrl(string url)
        {
            Url = url;
        }

        public static string CombineUrl(string baseUrl, string relativeUrl)
        {
            var baseUri = new Uri(baseUrl);

            var combinedUri = new Uri(baseUri, relativeUrl);

            return combinedUri.AbsoluteUri;
        }

        public override object Run()
        {
            Selenium.WebDriver.Navigate().GoToUrl(Url);

            return null;
        }

        public override string ToString()
        {
            return "Go to '" + Url + "'";
        }
    }
}