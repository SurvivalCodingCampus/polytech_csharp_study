using _250915.Data.DataSources;
using _250915.Data.Mapper;
using Moq;
using _250915.Data.Repositiories;

namespace _250915_Tests;

public class Tests
{
    [Test]
    public void MapperTest1()
    {
        var PokemonDto = new PokemonDto()
        {
            Id = 315,
            Name = "Roselia",
        };

        var PokemonModel = PokemonDto.ToModel();
        
        Assert.NotNull(PokemonModel);
        Assert.That(PokemonModel.Name, Is.EqualTo("Roselia"));
    }

    [Test]
    //PokemonRepository가 GetPokemonByNameAsync 메서드를 호출했을 때,
    //IPokemonApiDataSource가 반환하는 PokemonDto를 올바르게 반환하는지 확인하는 테스트
    public async Task PokemonTest1()
    {
        //가짜 객체 생성 : 이는 IPokemonApiDataSource를 흉내냄
        var mockDataSource = new Mock<IPokemonApiDataSource<PokemonDto>>();
        // 가짜 PokemonDto 객체 준비
        var expectedPokemonDto = new PokemonDto()
        {
            Id = 315,
            Name = "Roselia",
        };
        
        //가짜 데이터 소스 호출 시 가짜용 Response 객체를 반환하도록 설정
        Response apiResponse = new Response(200, new Dictionary<string, string>(), expectedPokemonDto);
        mockDataSource.Setup(d => d.GetPokemonAsync("Roselia")).ReturnsAsync(apiResponse);
        // 테스트할 레포지토리 객체 생성하여 모의 객체 넣기
        IPokemonRepsoitory reopository = new PokemonRepository(mockDataSource.Object);
        
        //PokemonRepository가 GetPokemonByNameAsync 메서드를 호출
        PokemonDto resultDto = await reopository.GetPokemonByNameAsync("Roselia");
        
        //IPokemonApiDataSource가 반환하는 PokemonDto를 올바르게 반환하는지 확인
        Assert.That(resultDto.Id, Is.EqualTo(expectedPokemonDto.Id));
        Assert.That(resultDto.Name, Is.EqualTo(expectedPokemonDto.Name));
        
        //expectedPokemonDto는 내가 직접 만든 객체
        // resultDto는 PokemonRepository의 GetPokemonByNameAsync가 반환한 객체
        
    } 
}