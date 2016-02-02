using System.Collections.Generic;

namespace TsarWars
{
    public class TsarWarsDataProcessor
    {
        public TsarWarsDataProcessor(IProvideFilmData filmDataProvider)
        {
        }

        public List<string> FetchCharactersFor(int episodeId)
        {
           return new List<string>();
        }
    }
}