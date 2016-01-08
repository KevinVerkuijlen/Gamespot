using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// the summary of an theme
    /// </summary>
    public class Theme
    {
        /// <summary>
        /// the name of an theme
        /// </summary>
        public string ThemeName { get; set; }
        /// <summary>
        /// the description of an theme
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the constructor of an theme
        /// </summary>
        /// <param name="themename">the name of the theme</param>
        /// <param name="description">the description of the theme</param>
        public Theme(string themename, string description)
        {
            this.ThemeName = themename;
            this.Description = description;
        }
    }
}