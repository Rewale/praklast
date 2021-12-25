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
    using System.Linq;

    public partial class licence
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public licence()
        {
            this.Status_history_change = new HashSet<Status_history_change>();
            this.Category = new HashSet<Category>();
        }
    
        public Nullable<System.DateTime> licence_date { get; set; }
        public Nullable<System.DateTime> expire_date { get; set; }
        public string licence_series { get; set; }
        public int number { get; set; }
        public int id { get; set; }
        public Nullable<int> owner { get; set; }
    
        public virtual Drivers Drivers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Status_history_change> Status_history_change { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Category { get; set; }
        public string CategoriesString
        {
            get
            {
                string i = "";
                foreach (var item in Category)
                {
                    i += item.letter + " ";
                }
                return i;
            }
        }

        public string ColorID
        {
            get
            {
                try
                {
                    return Status_history_change.Last().Status.color;
                }
                catch
                {
                    return "Green";
                }
            }
        }
    }
}