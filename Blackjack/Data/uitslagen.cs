//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blackjack.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class uitslagen
    {
        public int uitslag_ID { get; set; }
        public int speler_ID { get; set; }
        public int spel_ID { get; set; }
        public string uitslag { get; set; }
        public Nullable<int> Bank { get; set; }
    
        public virtual speler speler { get; set; }
        public virtual spellen spellen { get; set; }
    }
}
