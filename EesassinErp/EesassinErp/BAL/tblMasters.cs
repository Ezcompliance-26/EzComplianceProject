using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EesassinErp.BAL
{
    public class tblMasters
    {
        public int Action { get; set; }
        public float ParentId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int PartyTypeId { get; set; }
    }
    public class StoreStatusList
    {
        public string isActive { get; set; }
        public string[] selectedStores { get; set; }


    }

}