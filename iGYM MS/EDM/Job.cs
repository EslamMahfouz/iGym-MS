//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iGYM_MS.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        public Job()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int JobID { get; set; }
        public string JobName { get; set; }
        public string Salary { get; set; }
        public string HourPrice { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
    }
}