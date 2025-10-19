using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RuzgarOto.Entity
{
    public class ServiceCategory : BaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = "";
        public string Description { get; set; } = "";
        public string ShortDescription { get; set; } = "";
        public int DisplayOrder { get; set; } = 1;
        
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string ImageName { get; set; } = "";
        
        public string IconClass { get; set; } = "fas fa-wrench"; // Font Awesome icon
        public string ColorClass { get; set; } = "primary"; // Bootstrap color class
        
        // Navigation property
        public virtual ICollection<Services>? Services { get; set; }
    }
}
