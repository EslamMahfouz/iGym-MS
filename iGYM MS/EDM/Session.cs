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
    
    public partial class Session
    {
        public Session()
        {
            this.Invitations = new HashSet<Invitation>();
        }
    
        public int SessionID { get; set; }
        public string SessionName { get; set; }
        public string SessionPrice { get; set; }
    
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
