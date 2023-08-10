using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baltaDataAcess.Model
{
    [Table("[Course]")]
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
