//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Class
    {
        public string ClassID { get; set; }
        public Nullable<int> AddressID { get; set; }
        public string ClassName { get; set; }
    
        public virtual RegistrantAddress RegistrantAddress { get; set; }
    }
}
