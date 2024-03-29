﻿using Hakaton.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hakaton.Domain.Models.Models
{
    public class Service
    {
        public Service()
        {
            PathPhotos = new List<PathPhoto>();
        }

        public int ServiceId { get; set; }

        public int UserId { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Address { get; set; }
        public List<PathPhoto> PathPhotos { get; set; }
    }
}
