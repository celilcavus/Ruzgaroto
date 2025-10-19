using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RuzgarOto.Entity
{
    public class InsuranceCompany : BaseEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = "";
        public string WebsiteUrl { get; set; } = "";
        public int DisplayOrder { get; set; } = 1;
        
        [NotMapped]
        public IFormFile? LogoFile { get; set; }
        public string LogoName { get; set; } = "";
    }
}
