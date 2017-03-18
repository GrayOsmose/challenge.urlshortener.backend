using System;
using System.Collections.Generic;
using System.Text;

namespace urlshortener.domain.model
{
    public class UrlModel
    {
        public string Key { get; set; }

        public Guid UserGuid { get; set; }
        
        public string Url { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public int ClickCount { get; set; } = 0;
    }
}
