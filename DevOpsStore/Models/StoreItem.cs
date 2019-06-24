using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DevOpsStore.Models
{
    public class StoreItem : DbContext
    {
        public string Id { get; set; }
    }
}