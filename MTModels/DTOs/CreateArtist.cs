using MTModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTModels.DTOs
{
    public class CreateArtist : Base
    {
        public string Title { get; set; }
        public string Bography { get; set; }
        public string ImageURL { get; set; }
        public string HeroURL { get; set; }
    }
}
