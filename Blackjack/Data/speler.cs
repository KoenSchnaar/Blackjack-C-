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
    
    public partial class speler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public speler()
        {
            this.sessies = new HashSet<sessy>();
            this.uitslagens = new HashSet<uitslagen>();
        }
    
        public int speler_ID { get; set; }
        public string spelernaam { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sessy> sessies { get; set; }
        public virtual speler spelers1 { get; set; }
        public virtual speler speler1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<uitslagen> uitslagens { get; set; }
    }
}
