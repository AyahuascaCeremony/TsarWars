using System.Collections.Generic;

namespace TsarWars
{
    public class TsarWarsDataProcessor
    {
        private readonly IProvideFilmData _filmDataProvider;
        private readonly Dictionary<string, string> _characterMapper;

        public TsarWarsDataProcessor(IProvideFilmData filmDataProvider, Dictionary<string, string> characterMapper)
        {
            _filmDataProvider = filmDataProvider;
            _characterMapper = characterMapper;
        }

        public List<string> FetchCharactersFor(int episodeId)
        {
            var movieData = _filmDataProvider.GetMovieData(episodeId);

            var characters = new List<string>();

            foreach (var character in movieData.Characters)
            {
                characters.Add(_characterMapper[character.Name]);
            }

            return characters;
        }
    }
}