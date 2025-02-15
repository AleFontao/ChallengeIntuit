using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChallengeIntuit.DAL.DTOs.Request
{
    public class FilterDTO
    {
        public int? Limit { get; set; }
        public int? Skip { get; set; }
        public SORTBY? SortBy { get; set; }
        public string? ColumnFilter { get; set; }
        public string? SearchValue { get; set; }
        public bool IncludeInactive { get; set; } = false;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SORTBY { ASC, DESC }

}
