using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Entities
{
    public abstract class baseEntities
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}