using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace text2data.Api.DTO
{
    public class Document
    {
        public string DocumentText { get; set; }
        public bool IsTwitterContent { get; set; }
        public string PrivateKey { get; set; }
        public string Secret { get; set; }
        /// 
        public string UserCategoryModelName { get; set; } //trained model name
		public string DocumentLanguage { get; set; } //default: EN
        public int SerializeFormat { get; set; }
        public bool LoadHtmlInfo { get; set; }
    }
}