using System;
using System.Net;
using System.Threading.Tasks;
using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using Newtonsoft.Json;

namespace CsharpStudy.Network.Test.Repositories;

public class BeTimeoutDataSource : IDataSource<PokemonDto>
{
    public async Task<Response<PokemonDto>> GetNameAsync(string name)
    {
        return new Response<PokemonDto>((int)HttpStatusCode.RequestTimeout, null!, new PokemonDto());
    }
}

public class BeJsonSerializationExceptionDataSource : IDataSource<PokemonDto>
{
    public async Task<Response<PokemonDto>> GetNameAsync(string name)
    {
       throw new JsonSerializationException();
    }
}