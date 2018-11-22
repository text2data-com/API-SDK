using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace text2data.Api.DTO
{

    public class DocumentResult
    {
        public string DocSentimentResultString { get; set; }
        public double DocSentimentValue { get; set; }
        public string DocSentimentPolarity { get; set; }
		public string Subjectivity { get; set; } 
        public string Summarization { get; set; }      
        ////////
        public int NegativePhraseCount { get; set; }
        public int PositivePhraseCount { get; set; }
        public int NeutralPhraseCount { get; set; }
        ////////
        public List<SentencePart> Entities { get; set; }
        public List<SentencePart> Themes { get; set; }
        public List<SentencePart> Keywords { get; set; }
        public List<SentencePart> Citations { get; set; }
        ////////
        public List<Category> AutoCategories { get; set; }
        public List<Category> UserCategories { get; set; }
        ////////
        public List<SlangWord> SlangWords { get; set; }
        public List<SlangWord> SwearWords { get; set; }
        public List<Sentence> CoreSentences { get; set; }
        public List<PartOfSpeech> PartsOfSpeech { get; set; }
        ////////
        public string CloudTagHTML { get; set; }
        public string ResultTextHtml { get; set; }    
        ////////
        public string ErrorMessage { get; set; }
        public int Status { get; set; }
		////////
        public int TransactionTotalCreditsLeft { get; set; }
        public DateTime TransactionUseByDate { get; set; }
        public int TransactionCurrentDay { get; set; }
        public int TransactionDailyLimit { get; set; }
    }
}