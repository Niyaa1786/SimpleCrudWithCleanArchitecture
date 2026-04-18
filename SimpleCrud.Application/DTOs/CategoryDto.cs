using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
    }
}
