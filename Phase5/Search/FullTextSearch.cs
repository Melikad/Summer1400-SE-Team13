﻿using System.Collections.Generic;
using Phase5.Interface;

namespace Phase5
{
    public class FullTextSearch : IFullTextSearch
    {
        private readonly IInvertedIndex _invertedIndex;
        private readonly IDocsFileReader _docsFileReader;
        private readonly ITokenizer _tokenizer;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IFilterApplier _filterApplier;

        public FullTextSearch(IInvertedIndex invertedIndex, 
                                IDocsFileReader docsFileReader,
                                ITokenizer tokenizer, 
                                IQueryProcessor queryProcessor, 
                                IFilterApplier filterApplier)
        {
            _invertedIndex = invertedIndex;
            _docsFileReader = docsFileReader;
            _tokenizer = tokenizer;
            _queryProcessor = queryProcessor;
            _filterApplier = filterApplier;
        }

        public HashSet<string> FindCommandResult(string command)
        {
            const string filePath = "EnglishData";
            var docsMap = _docsFileReader.ReadContent(filePath);
            _invertedIndex.BuildInvertedIndex(docsMap, _tokenizer);
            _queryProcessor.SplitCommandWordsBySign(command);
            var result = _filterApplier.Filter(_queryProcessor.PlusCommandWords, _queryProcessor.MinusCommandWords, _queryProcessor.NoSignCommandWords);
            return result;
        }
    }
}