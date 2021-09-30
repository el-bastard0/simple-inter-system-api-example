using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElBastard0.Api.Models
{
    /// <summary>
    /// Entity db model
    /// </summary>
    public partial class Entity: IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
