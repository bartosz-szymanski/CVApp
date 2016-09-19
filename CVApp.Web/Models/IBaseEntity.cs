using System;

namespace CVApp.Web.Models
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime CreationDate { get; set; }
        DateTime ModificationDate { get; set; }
    }
}