using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDDD.DAL.Entities
{
    public class Tasks : BaseEntity
    {
        [Display(Name = "Название задачи")]
        public string TaskName { get; set; } = null!;

        [Display(Name = "Описание")]
        public string Desc { get; set; } = null!;

        [Display(Name = "Приоритет")]
        public Guid PriorityGuid { get; set; }
        public virtual Priority? Priority { get; set; }

        [Display(Name = "Статус")]
        public virtual Status? Status { get; set; }

        [Display(Name = "Создать")]
        public DateTime CreateDate { get; set; }
        public Guid StatusId { get; set; }
    }
}
