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
    
    public partial class Watched_Movies
    {
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public Nullable<System.DateTime> WatchDate { get; set; }
        public Nullable<decimal> Rating { get; set; }
        public string Review { get; set; }
    
        public virtual Movies Movies { get; set; }
        public virtual Users Users { get; set; }
    }
}
