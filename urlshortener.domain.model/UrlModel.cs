using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace urlshortener.domain.model
{
    public class UrlModel
    {
        public string Key { get; set; }

        public Guid UserGuid { get; set; }
        
        [Required]
        public string Url { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public int ClickCount { get; set; } = 0;
    }
}
