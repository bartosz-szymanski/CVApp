using CVApp.Web.Models.Enums;
using System;

namespace CVApp.Web.Models
{
    public class Log : IBaseEntity
    {
        public Log(LogCategory category, string details, string exception)
        {
            Category = category;
            Details = details;
            Exception = exception;
            CreationDate = ModificationDate = DateTime.Now;
        }

        public long Id { get; set; }
        public LogCategory Category { get; set; }
        public string Details { get; set; }
        public string Exception { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}