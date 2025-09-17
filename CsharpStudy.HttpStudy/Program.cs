using CsharpStudy.HttpStudy.Common;
using CsharpStudy.HttpStudy.Data;
using CsharpStudy.HttpStudy.Repository;

namespace CsharpStudy.HttpStudy;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient httpClient = new HttpClient();
        IPokemonApiDataSource dataSource = new RemotePostDataSource(httpClient); //데이터 만들기
        IPokemonRepository postRepository = new PostRepository(dataSource); //레포 생성
        
        Result<Pokemon, PokemonError> pokemon = await postRepository.GetPokemonByNameAsync("dittooo"); // GetPokemonByNameAsync 함수 실행해서 데이터를 DTO로 넣음
        


    }
}