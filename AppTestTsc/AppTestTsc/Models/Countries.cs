using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace AppTestTsc.Models
{
    /// <summary>
    /// Model for countries page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Countries
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
        /// Gets or sets the countrie alpha2.
        /// </summary>
        [DataMember(Name = "alpha2")]
        public string Alpha2 { get; set; }

        /// <summary>
        /// Gets or sets the countrie alpha3.
        /// </summary>
        [DataMember(Name = "alpha3")]
        public string Alpha3 { get; set; }

        /// <summary>
        /// Gets or sets the countrie code.
        /// </summary>
        [DataMember(Name = "code")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the countrie iso_3166_2.
        /// </summary>
        [DataMember(Name = "iso_3166_2")]
        public string Iso_3166_2 { get; set; }

        /// <summary>
        /// Gets or sets the countrie is_independent.
        /// </summary>
        [DataMember(Name = "is_independent")]
        public bool Is_independent { get; set; }

        ///// <summary>
        ///// Gets or sets the countrie code.
        ///// </summary>
        //[DataMember(Name = "created_at")]
        //public string Created_at { get; set; }

        ///// <summary>
        ///// Gets or sets the countrie code.
        ///// </summary>
        //[DataMember(Name = "updated_at")]
        //public string Updated_at { get; set; }


        #endregion
    }

    public class Root
    {
        public List<Countries> data = new List<Countries>();
    }


}
