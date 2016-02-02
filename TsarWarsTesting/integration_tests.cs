using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TsarWars;

namespace TsarWarsTesting
{
    public class integration_tests
    {
        [Test]
        public void characters_fetched_are_correctly_mapped_to_meerkats()
        {
            var filmDataProvider = new StubFilmDataProvider();
            const int episodeId = 4;

            filmDataProvider.AddMovie(CreateMovie(episodeId));

            var tsarWars = new TsarWarsDataProcessor(filmDataProvider);

            var movieCharacters = tsarWars.FetchCharactersFor(episodeId);

            Assert.That(movieCharacters.Count, Is.EqualTo(2));
            Assert.That(movieCharacters[0], Is.EqualTo("Aleksandr Orlov"));
            Assert.That(movieCharacters[1], Is.EqualTo("Bogdhan"));
        }

        [Test]
        public void different_characters_for_each_film_mapped_correctly()
        {
            var filmDataProvider = new StubFilmDataProvider();
            const int episodeId = 1;

            filmDataProvider.AddMovie(CreateMovie(episodeId));

            var tsarWars = new TsarWarsDataProcessor(filmDataProvider);

            var movieCharacters = tsarWars.FetchCharactersFor(episodeId);

            Assert.That(movieCharacters.Count, Is.EqualTo(3));
            Assert.That(movieCharacters[0], Is.EqualTo("Sergei"));
            Assert.That(movieCharacters[1], Is.EqualTo("Maiya"));
            Assert.That(movieCharacters[2], Is.EqualTo("Vassily"));
        }

        private static Movie CreateMovie(int episodeId)
        {
            Movie movie;

            switch (episodeId)
            {
                case 1:
                    movie = new Movie
                    {
                        Title = "Phantom Menace",
                        EpisodeId = episodeId,
                        OpeningCrawl = "blah blah",
                        Director = "George Lucas",
                        Producers = new[] {"Gary Kurtz", "Rick McCallum"},
                        ReleaseDate = new DateTime(1977, 5, 25),
                        Characters = new List<Character>
                        {
                            new Character {Name = "Hans Solo"},
                            new Character {Name = "Obi Wan Kenobi"},
                            new Character {Name = "Darth Vader"}
                        }
                    };
                    break;
                case 4:
                    movie = new Movie
                    {
                        Title = "A New Hope",
                        EpisodeId = episodeId,
                        OpeningCrawl = "blah blah",
                        Director = "George Lucas",
                        Producers = new[] {"Gary Kurtz", "Rick McCallum"},
                        ReleaseDate = new DateTime(1977, 5, 25),
                        Characters = new List<Character>
                        {
                            new Character {Name = "Luke Skywalker"},
                            new Character {Name = "C-3PO"}
                        }
                    };
                    break;
                default:
                    movie = null;
                    break;
            }

            return movie;
        }

        public class StubFilmDataProvider : IProvideFilmData
        {
            private readonly List<Movie> _movies = new List<Movie>();

            public void AddMovie(Movie movie)
            {
                _movies.Add(movie);
            }

            public Movie GetMovieData(int episodeId)
            {
                return _movies.Single(m => m.EpisodeId == episodeId);
            }
        }
    }
}
