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
    
    public partial class Members_DTP
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Nomer { get; set; }
        public Nullable<int> Id_DTP { get; set; }
    
        public virtual DTP DTP { get; set; }
    }
}