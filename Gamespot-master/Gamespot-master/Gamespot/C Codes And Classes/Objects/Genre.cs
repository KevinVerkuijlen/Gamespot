using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// the summary of an genre
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// the name of an genre
        /// </summary>
        public string GenreName { get; set; }
        /// <summary>
        /// the description of an genre
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the constructor of an genre 
        /// </summary>
        /// <param name="genrename">the name of the genre</param>
        /// <param name="description">the description of the genre</param>
        public Genre(string genrename, string description)
        {
            if (genrename == null) { throw new ArgumentNullException("genrename", "genrename is null"); }
            if (description == null) { throw new ArgumentNullException("description", "genre description is null"); }

            this.GenreName = genrename;
            this.Description = description;
        }
    }
}