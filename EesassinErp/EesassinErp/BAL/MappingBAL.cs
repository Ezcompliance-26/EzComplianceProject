using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL
{
    public class MappingBAL
    {
        public string Createdby { get; set; }
        public string ClientId { get; set; }
        public string ClientSiteId { get; set; }
        public string VendorId { get; set; }
        public string AuditorId { get; set; }
        public string Action { get; set; }
        public List<MapListSet> MapListSet { get; set; }
    }
    public class MapListSet
    {
        public string Srno { get; set; }
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string ClientSiteId { get; set; }
        public string VendorId { get; set; }
        public string AuditorId { get; set; }
        public string Createdby { get; set; }
    }
}