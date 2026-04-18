using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.DTOs.Request
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
