using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AboutDTO
    {
        public int Id { get; set; }
        public string HeaderText { get; set; }
        public string ContentText { get; set; }
        public Nullable<bool> Status { get; set; }

    }
}
