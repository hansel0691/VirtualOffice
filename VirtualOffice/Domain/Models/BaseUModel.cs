using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public abstract class BaseUModel
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateTime TimeSpan { get; set; }

        protected BaseUModel()
        {
            TimeSpan = DateTime.Now;
        }

        public override string ToString()
        {
            return UModelExtensions.ToString(this);
        }
    }
}