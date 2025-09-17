using System.Net;
using System.Net.Http;
using System.Text.Json;
using CsharpStudy.ResultPattern.Common;
using CsharpStudy.ResultPattern.DataSources;
using CsharpStudy.ResultPattern.DTOs;

namespace CsharpStudy.ResultPattern.Repositories;

public sealed class SubwayRepository(ISubwayApiDataSource api) : ISubwayRepository
{
    public async Task<(Result result, List<Arrival>? data)> GetArrivalsAsync(string stationNameKo)
    {
        try
        {
            var dto = await api.GetArrivalInfoAsync(stationNameKo);

            var list = dto?.RealtimeArrivalList;
            if (list is null || list.Count == 0)
                return (Result.Fail(new Error(SubwayError.NotFound, "Not found")), null);

            var arrivals = list.Select(x => new Arrival(
                    x.TrainLineNm ?? "",
                    x.ArrivalMessage ?? "",
                    int.TryParse(x.RemainSeconds, out var s) ? s : (int?)null
                ))
                .ToList();

            return (Result.Ok(), arrivals);
        }
        
        catch (TaskCanceledException ex)                      
        {
            return (Result.Fail(new Error(SubwayError.Timeout, ex.Message, ex)), null);
        }
        catch (TimeoutException ex)                               
        {
            return (Result.Fail(new Error(SubwayError.Timeout, ex.Message, ex)), null);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return (Result.Fail(new Error(SubwayError.NotFound, ex.Message, ex)), null);
        }
        catch (HttpRequestException ex)                          
        {
            return (Result.Fail(new Error(SubwayError.Timeout, ex.Message, ex)), null);
        }
        catch (JsonException ex)                                  
        {
            return (Result.Fail(new Error(SubwayError.Timeout, ex.Message, ex)), null);
        }
        catch (Exception ex)                                       
        {
            return (Result.Fail(new Error(SubwayError.Timeout, ex.Message, ex)), null);
        }
    }
}