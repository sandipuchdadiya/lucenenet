﻿using System.Collections.Generic;
using TokenFilterFactory = Lucene.Net.Analysis.Util.TokenFilterFactory;

namespace org.apache.lucene.analysis.ngram
{

	/*
	 * Licensed to the Apache Software Foundation (ASF) under one or more
	 * contributor license agreements.  See the NOTICE file distributed with
	 * this work for additional information regarding copyright ownership.
	 * The ASF licenses this file to You under the Apache License, Version 2.0
	 * (the "License"); you may not use this file except in compliance with
	 * the License.  You may obtain a copy of the License at
	 *
	 *     http://www.apache.org/licenses/LICENSE-2.0
	 *
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 */

	using TokenFilterFactory = TokenFilterFactory;

	/// <summary>
	/// Factory for <seealso cref="NGramTokenFilter"/>.
	/// <pre class="prettyprint">
	/// &lt;fieldType name="text_ngrm" class="solr.TextField" positionIncrementGap="100"&gt;
	///   &lt;analyzer&gt;
	///     &lt;tokenizer class="solr.WhitespaceTokenizerFactory"/&gt;
	///     &lt;filter class="solr.NGramFilterFactory" minGramSize="1" maxGramSize="2"/&gt;
	///   &lt;/analyzer&gt;
	/// &lt;/fieldType&gt;</pre>
	/// </summary>
	public class NGramFilterFactory : TokenFilterFactory
	{
	  private readonly int maxGramSize;
	  private readonly int minGramSize;

	  /// <summary>
	  /// Creates a new NGramFilterFactory </summary>
	  public NGramFilterFactory(IDictionary<string, string> args) : base(args)
	  {
		minGramSize = getInt(args, "minGramSize", NGramTokenFilter.DEFAULT_MIN_NGRAM_SIZE);
		maxGramSize = getInt(args, "maxGramSize", NGramTokenFilter.DEFAULT_MAX_NGRAM_SIZE);
		if (args.Count > 0)
		{
		  throw new System.ArgumentException("Unknown parameters: " + args);
		}
	  }

	  public override NGramTokenFilter create(TokenStream input)
	  {
		return new NGramTokenFilter(luceneMatchVersion, input, minGramSize, maxGramSize);
	  }
	}

}