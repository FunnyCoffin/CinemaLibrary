//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaLibrary.bd
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actors()
        {
            this.Movies = new HashSet<Movies>();
        }
    
        public int ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string YearsOfLife { get; set; }
        public string Biography { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movies> Movies { get; set; }
    }
}
