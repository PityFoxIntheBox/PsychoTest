//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PsychoTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class Results
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Results()
        {
            this.Users_Tests = new HashSet<Users_Tests>();
        }
    
        public int Result_id { get; set; }
        public string Result_name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Id_test { get; set; }
        public int Score_count { get; set; }
    
        public virtual Tests Tests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_Tests> Users_Tests { get; set; }
    }
}