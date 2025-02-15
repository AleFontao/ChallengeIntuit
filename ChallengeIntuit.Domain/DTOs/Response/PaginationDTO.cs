using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIntuit.DAL.DTOs.Response
{
    public class PaginationDTO<T>
    {
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }
}
