using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace text2data.Api.DTO
{
    public class Sentence
    {
        public int SentenceNumber { get; set; }
        public string Text { get; set; }
        public string SentimentResultString { get; set; }
        public double SentimentValue { get; set; }
        public string SentimentPolarity { get; set; }
        public int Relevance { get; set; }
    }
}