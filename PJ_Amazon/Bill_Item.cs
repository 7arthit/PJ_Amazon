//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PJ_Amazon
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill_Item
    {
        public int Id { get; set; }
        public int Menu_Id { get; set; }
        public int Bill_Id { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
