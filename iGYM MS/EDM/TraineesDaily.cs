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
    
    public partial class TraineesDaily
    {
        public int TraineeID { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> LogID { get; set; }
    
        public virtual Trainee Trainee { get; set; }
        public virtual TraineeProfile TraineeProfile { get; set; }
    }
}
