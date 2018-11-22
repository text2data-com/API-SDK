using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace text2data.Api.DTO
{
    public class PartOfSpeech
    {
        public string Text { get; set; }
        public string Subject { get; set; }
        public string Action { get; set; }
        public string Object { get; set; }
        /// 
        public string ObjectSentimentResultString { get; set; }
        public double ObjectSentimentValue { get; set; }
        public string ObjectSentimentPolarity { get; set; }
    }
}