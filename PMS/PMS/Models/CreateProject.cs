//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class CreateProject
    {
        public int id { get; set; }
        [DisplayName("Project Name")]
        public string pro_name { get; set; }
        [DisplayName("Start Date")]
        public Nullable<System.DateTime> strt_date { get; set; }
        [DisplayName("End Date")]
        public Nullable<System.DateTime> end_date { get; set; }
        public string state { get; set; }
        [DisplayName("Price")]
        public Nullable<double> price { get; set; }
        [DisplayName("Leader Name")]
        public string leader_name { get; set; }
        public Nullable<int> team_id { get; set; }
        public string usrname { get; set; }
        public IEnumerable<user> mt { get; set; }
        public IEnumerable<user> mtl { get; set; }
        public IEnumerable<project> projectss { get; set; }

        public virtual team team { get; set; }
        public virtual user user { get; set; }
    }
}
