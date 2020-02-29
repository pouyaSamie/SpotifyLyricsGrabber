﻿using Core.ApiCaller;
using Core.ApiCaller.Models;
using Core.Lyrics;
using GeniusLyrics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusLyrics
{
    public class GeniusWebApi : BaseWebAPI,ILyricsFinder<Response<GeniusResult>>
    {
        public override IWebBuilder _builder => new GeniusApiBuilder();
        private GeniusApiBuilder _geniusApiBuilder => (GeniusApiBuilder)_builder;
        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.
        /// </summary>
        /// <param name="q">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues.</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <returns></returns>
        public Task<Response<GeniusResult>> SearchItems(string q, int limit = 20)
        {
            return DownloadDataAsync<Response<GeniusResult>>(_geniusApiBuilder.SearchItems(q, limit));
        }


        public override void SetAuthenticationParams(ref Dictionary<string, string> headers, ref string url)
        {
           //Do nothing
        }
    }
}