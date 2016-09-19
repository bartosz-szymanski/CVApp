using System;

namespace CVApp.Web.Models
{
    public class Position : IBaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}