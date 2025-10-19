using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RuzgarOto.Entity
{
    public class MainTitle:BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public IFormFile Image1{ get; set; }
        public string Image1Name { get; set; }

        [NotMapped]
        public IFormFile Image2 { get; set; }
        public string Image2Name { get; set; }
        [NotMapped]
        public IFormFile Image3 { get; set; }
        public string Image3Name { get; set; }
    }
}
