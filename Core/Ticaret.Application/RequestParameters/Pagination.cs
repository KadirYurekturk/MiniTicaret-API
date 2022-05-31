using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticaret.Application.RequestParameters
{
    public class Pagination
    {
        public int Page { get; set; } = 0;
        public int ItemsPerPage { get; set; } = 10;
    }
}
