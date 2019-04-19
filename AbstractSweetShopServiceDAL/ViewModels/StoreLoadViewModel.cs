using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    [DataContract]
    public class StoreLoadViewModel
    {
        [DataMember]
        public string StoreName { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public IEnumerable<Tuple<string, int>> Materials { get; set; }
    }
}
