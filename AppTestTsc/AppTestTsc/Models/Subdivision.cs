using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms.Internals;

namespace AppTestTsc.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Subdivisions
    {
        #region Properties

        /// <summary>
        /// Gets or sets countrie id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets countrie name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the countrie code.
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }


        #endregion
    }

    public class RootSubdivisions
    {
        public List<Subdivisions> data = new List<Subdivisions>();
    }
}
