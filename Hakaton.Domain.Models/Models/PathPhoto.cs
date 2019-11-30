using System;
using System.Collections.Generic;
using System.Text;

namespace Hakaton.Domain.Models.Models
{
    public class PathPhoto
    {
        public int PhotoId { get; set; }

        public int ServiceId { get; set; }

        public string Path { get; set; }

        public Service Service { get; set; }
    }
}
