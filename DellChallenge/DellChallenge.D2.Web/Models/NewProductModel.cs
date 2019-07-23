using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D2.Web.Models
{
    public class NewProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }

        [JsonIgnore]
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
