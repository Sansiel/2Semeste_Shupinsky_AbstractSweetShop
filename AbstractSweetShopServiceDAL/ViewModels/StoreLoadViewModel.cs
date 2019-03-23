﻿using System;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    public class StoreLoadViewModel
    {
        public string StoreName { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Tuple<string, int>> Materials { get; set; }
    }
}
