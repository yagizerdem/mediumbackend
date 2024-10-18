using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class ArticleDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }

    }
}
