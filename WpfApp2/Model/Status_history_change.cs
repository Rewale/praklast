//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Status_history_change
    {
        public Nullable<int> id_VU { get; set; }
        public Nullable<int> id_Status { get; set; }
        public string desk { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public int id { get; set; }
    
        public virtual licence licence { get; set; }
        public virtual Status Status { get; set; }
    }
}
