//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppTasks_Statuses.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tasks
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status_ID { get; set; }

        [NotMapped]
        public List<Statuses> StatusesCollection { get; set; }
    }
}
