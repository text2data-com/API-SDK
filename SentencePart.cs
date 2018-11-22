using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace text2data.Api.DTO
{
    public class SentencePart
    {
        public string Text { get; set; }
        public string SentenceText { get; set; }
        public int Mentions { get; set; }
        public string SentencePartType { get; set; }
        public string KeywordType { get; set; }
        ///
        public string SentimentResult { get; set; }
        public double SentimentValue { get; set; }
        public string SentimentPolarity { get; set; }
    }
}