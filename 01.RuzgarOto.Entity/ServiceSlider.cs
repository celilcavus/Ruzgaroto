using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RuzgarOto.Entity
{
    public class ServiceSlider : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int DisplayOrder { get; set; } = 1;
        
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string ImageName { get; set; } = "";
        
        public bool IsMainSlider { get; set; } = true; // Ana sayfa slider'ı için
    }
}
