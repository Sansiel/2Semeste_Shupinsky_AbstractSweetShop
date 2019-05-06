﻿using System;
using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    [DataContract]
    public class MessageInfoViewModel
    {
        [DataMember]
        public string MessageId { get; set; }
        [DataMember]
        public string BuyerName { get; set; }
        [DataMember]
        public DateTime DateDelivery { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Body { get; set; }
    }
}