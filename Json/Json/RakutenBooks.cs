using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Json
{
    [DataContract]
    public class RakutenBooks
    {
        [DataMember]
        public int count { get; set; }
        [DataMember]
        public int page { get; set; }
        [DataMember]
        public string first { get; set; }
        [DataMember]
        public int last { get; set; }
        [DataMember]
        public int hits { get; set; }
        [DataMember]
        public int carrier { get; set; }
        [DataMember]
        public int pageCount { get; set; }

        [DataMember]
        public List<Item> Items { get; set; }

        [DataContract]
        public class Item
        {
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string titleKana { get; set; }
            [DataMember]
            public string subTitle { get; set; }
            [DataMember]
            public string subTitleKana { get; set; }
            [DataMember]
            public string seriesName { get; set; }
            [DataMember]
            public string seriesNameKana { get; set; }
            [DataMember]
            public string contents { get; set; }
            [DataMember]
            public string author { get; set; }
            [DataMember]
            public string authorKana { get; set; }
            [DataMember]
            public string publisherName { get; set; }
            [DataMember]
            public int size { get; set; }
            [DataMember]
            public string isbn { get; set; }
            [DataMember]
            public string itemCaption { get; set; }
            [DataMember]
            public string salesDate { get; set; }
            [DataMember]
            public int itemPrice { get; set; }
            [DataMember]
            public int listPrice { get; set; }
            [DataMember]
            public float discountRate { get; set; }
            [DataMember]
            public int discountPrice { get; set; }
            [DataMember]
            public string itemUrl { get; set; }
            [DataMember]
            public string affiliateUrl { get; set; }
            [DataMember]
            public string smallImageUrl { get; set; }
            [DataMember]
            public string mediumImageUrl { get; set; }
            [DataMember]
            public string largeImageUrl { get; set; }
            [DataMember]
            public string chirayomiUrl { get; set; }
            [DataMember]
            public int availability { get; set; }
            [DataMember]
            public int postageFlag { get; set; }
            [DataMember]
            public int limitedFlag { get; set; }
            [DataMember]
            public float reviewcount { get; set; }
            [DataMember]
            public float reviewAverage { get; set; }
            [DataMember]
            public string booksGenreId { get; set; }
        }
    }
}
