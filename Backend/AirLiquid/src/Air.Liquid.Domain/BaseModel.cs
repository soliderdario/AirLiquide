using System;
using System.ComponentModel.DataAnnotations.Schema;
using Air.Liquide.Domain.Type;

namespace Air.Liquide.Domain
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        [NotMapped]
        public OperationType Operation { get; set; }
    }
}
