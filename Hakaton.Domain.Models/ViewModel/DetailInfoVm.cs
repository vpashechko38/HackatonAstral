using Hakaton.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hakaton.Domain.Models.ViewModel
{
    public class DetailInfoVm 
    {
        public int ServiceId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string ServiceName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Address { get; set; }

        public List<PathPhoto> pathPhotos { get; set; }
    }
}
