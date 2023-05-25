using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.models
{
    public class UIDDAL
    {
        [Key]
        public int IdUID { get; set; }
        public string UID { get; set; } = "UID";
    }
}
