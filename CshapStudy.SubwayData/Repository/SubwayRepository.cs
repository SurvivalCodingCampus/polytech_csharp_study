using CshapStudy.SubwayData.Common;
using CshapStudy.SubwayData.DTO;
using CshapStudy.SubwayData.Mapper;
using CshapStudy.SubwayData.Model;
using CsharpStudy.HttpPokeMon.DataSources;
using CsharpStudy.HttpPokeMon.Repository;

namespace CshapStudy.SubwayData.Repository;

public class SubwayRepository<SubwayDto> : ISubwayRepository 
{
    private ISubwayApiDataSource<SubwayDto> _apiDataSource;
    
    // 생성자
    public SubwayRepository(ISubwayApiDataSource<SubwayDto> subwayRepository)
    {
        _apiDataSource = subwayRepository;
    }

    public async Task<Result<Model.Subway, SubwayError>> GetSubwayByNameAsync(string subwayName)
    {

        try
        {
            //Responese<PokemonDTO> response = await _apiDataSource.GetPokemonAsync(pokemonName);
            //var response = await _apiDataSource.GetSubwayAsync(subwayName)
            //var subways = response.Body.ToSubwayModels();
            var response = await _apiDataSource.GetSubwayAsync(subwayName);

            switch (response.StatusCode)
            {
                case 200:
                    var subways = response.Body.ToSubwayModels();
                    return subways.Any()
                        ? new Result<Subway, SubwayError>.Success(subways.First())
                        : new Result<Subway, SubwayError>.Error(SubwayError.NotFound);

                case 404:
                    return new Result<Subway, SubwayError>.Error(SubwayError.NotFound);

                case -1:
                    return new Result<Subway, SubwayError>.Error(SubwayError.NetworkTimeout);

                default:
                    return new Result<Subway, SubwayError>.Error(SubwayError.Unknown);
            }
        }
        catch (Exception ex)
        {
            return new Result<Subway, SubwayError>.Error(SubwayError.Unknown);
        }
    }
}