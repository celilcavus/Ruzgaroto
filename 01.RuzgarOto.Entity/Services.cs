using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RuzgarOto.Entity
{
	public class Services:BaseEntity
	{
        public int Id { get; set; }
        [NotMapped]
        public IFormFile Image{ get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        // Kategori ilişkisi
        public int? ServiceCategoryId { get; set; }
        [NotMapped]
        public virtual ServiceCategory? ServiceCategory { get; set; }
    }
}
