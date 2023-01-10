using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Domain.Models
{
    public class FilmeModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int MinutesDuration { get; set; }
    }
}
