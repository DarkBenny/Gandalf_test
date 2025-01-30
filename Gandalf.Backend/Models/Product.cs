﻿using Gandalf.Backend.Models;

namespace Gandalf.Backend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageLink { get; set; }

    }
}
