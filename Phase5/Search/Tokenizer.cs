﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Phase5.Interface;


namespace Phase5
{
    public class Tokenizer : ITokenizer
    {
        public HashSet<string> Tokenize(string doc)
        {
            var wordsDoc = Regex.Split(doc.ToLower(),"[\\W]+").Where(x => x.Length > 1).ToHashSet();
            return wordsDoc;
        }
    }
}