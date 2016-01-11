using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// the summary of an console
    /// </summary>
    public class Console
    {
        /// <summary>
        /// the name and the ID of an console
        /// </summary>
        public string ConsoleNameID { get; set; }
        /// <summary>
        /// the consoltype of an console which is Handheld or Home console
        /// </summary>
        public string ConsoleType { get; set; }
        /// <summary>
        /// the description of an console
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the constructor for an console
        /// </summary>
        /// <param name="consolenameid">the name and the ID of the console</param>
        /// <param name="consoletype">the consoltype of the console which is Handheld or Home console</param>
        /// <param name="description">the description of the console</param>
        public Console(string consolenameid, string consoletype, string description)
        {
            if (consolenameid == null) { throw new ArgumentNullException("consolenameid", "consolenameid is null"); }
            if (consoletype == null) { throw new ArgumentNullException("consoletype", "consoletype is null"); }
            if (description == null) { throw new ArgumentNullException("description", "console description is null"); }

            this.ConsoleNameID = consolenameid;
            this.ConsoleType = consoletype;
            this.Description = description;
        }
    }
}