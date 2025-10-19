using _01.RuzgarOto.Entity;
using _02.RuzgarOto.Model;
using _03.RuzgarOto.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RuzgarOto.Data.Repository
{
    public class ContactRepository : BaseRepository<Contact>, IContactServices
    {
        public ContactRepository(RuzgarOtoDbContext ruzgarOtoDbContext) : base(ruzgarOtoDbContext)
        {
        }
    }
}
