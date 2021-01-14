using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class Banner
    {
        public int BannerImgId { get; set; }
        public string BannerImgUrl { get; set; }
        public int? CategoryId { get; set; }
        public string BannerText { get; set; }
    }
}
