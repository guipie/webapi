using System;
using System.Collections.Generic;
using System.Text;

namespace Monster.Entity.DomainDto
{
    public class MovieWebsiteTypeRelation
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string SiteTypeName { get; set; }
        public int SiteId { get; set; }
    }
}
