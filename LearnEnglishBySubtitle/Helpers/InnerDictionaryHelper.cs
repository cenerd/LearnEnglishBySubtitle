﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LearnEnglishBySubtitle.Entities;

namespace Studyzy.LearnEnglishBySubtitle.Helpers
{
    public static class InnerDictionaryHelper
    {
        //private static IList<EasyWord> easyWords; 
        //public static IList<EasyWord> GetAllEasyWords()
        //{
        //    if (easyWords == null)
        //    {
        //        var rows = InnerDictionary.EasyWord.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
        //        easyWords = new List<EasyWord>();
        //        foreach (var row in rows)
        //        {
        //            easyWords.Add(new EasyWord() { Word = row });
        //        }
        //    }
        //    return easyWords;
        //}

        //public static IList<WordOriginalMap> GetAllWordOriginalMap()
        //{
            
        //}

        private static IList<string> easyWords;
        public static IList<string> GetAllEasyWords()
        {
            if (easyWords == null)
            {
                easyWords = InnerDictionary.EasyWord.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
               
            }
            return easyWords;
        }


        private static IList<string> englishNames;
        public static IList<string> GetAllEnglishNames()
        {
            if (englishNames == null)
            {
                englishNames = InnerDictionary.EnglishName.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            }
            return englishNames;
        }

        private static IDictionary<string,string> wordOriginalMaps;
        public static IDictionary<string, string> GetAllWordOriginalMaps()
        {
            if (wordOriginalMaps == null)
            {
                wordOriginalMaps=new Dictionary<string, string>();
                var rows = InnerDictionary.WordOriginalMap.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var row in rows)
                {
                    var array = row.Split(',');
                    wordOriginalMaps.Add(array[0],array[1]);
                }
            }
            return wordOriginalMaps;
        }


        private static IDictionary<string, int> vocabularyRanks;
        public static IDictionary<string, int> GetAllVocabularyRanks()
        {
            if (vocabularyRanks == null)
            {
                vocabularyRanks = new Dictionary<string, int>();
                var rows = InnerDictionary.VocabularyRank.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var row in rows)
                {
                    var array = row.Split(',');
                    vocabularyRanks.Add(array[0], Convert.ToInt32(array[1]));
                }
            }
            return vocabularyRanks;
        }
    }
}
