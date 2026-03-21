using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProductsApi.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string? FullName { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}