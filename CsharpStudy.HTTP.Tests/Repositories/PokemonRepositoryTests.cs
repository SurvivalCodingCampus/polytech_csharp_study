using System;
using System.Threading.Tasks;
using NUnit.Framework;
using CsharpStudy.HTTP.Common;                 
using CsharpStudy.HTTP.Repositories;          
using CsharpStudy.HTTP.Tests.Mocks;

namespace CsharpStudy.HTTP.Tests.Repositories 
{
    [TestFixture]
    public class PokemonRepositoryTests
    {
        [Test]
        public async Task GetByNameAsync_AlwaysTimeout_ReturnsTimeoutError()
        {
            // Arrange
            var repo = new PokemonRepository(new TimeoutPokemonDataSource());

            // Act
            var (result, data) = await repo.GetByNameAsync("pikachu");

            // Assert
            Assert.That(result, Is.TypeOf<Result.Failure>());
            var failure = (Result.Failure)result;
            Assert.That(failure.Error.Kind, Is.EqualTo(PokemonError.Timeout));
        }

        [Test]
        public async Task GetByNameAsync_AlwaysJsonError_ReturnsUnknownError()
        {
            // Arrange
            var repo = new PokemonRepository(new JsonErrorPokemonDataSource());

            // Act
            var (result, data) = await repo.GetByNameAsync("pikachu");

            // Assert
            Assert.That(result, Is.TypeOf<Result.Failure>());
            var failure = (Result.Failure)result;
            Assert.That(failure.Error.Kind, Is.EqualTo(PokemonError.Unknown));
        }
    }
}