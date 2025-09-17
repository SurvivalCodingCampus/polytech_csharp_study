using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.DtoMapper.Common;
using CsharpStudy.DtoMapper.DataSources;
using CsharpStudy.DtoMapper.Models;
using CsharpStudy.DtoMapper.Repositories;
using NUnit.Framework;

namespace CsharpStudy.DtoMapper.Tests.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest // PokemonRepository : 데이터 창고 관리인 > 테스트 > 품질 검사 > .. 데이터를 줘! 목록 줘! 
{
    [Test]
    public async Task Result_Test()
    {
        IPokemonRepository repository = new PokemonRepository(new PokemonApiDataSource(new HttpClient()));
        //PokemonRepository 객체 생성 하고 초기화 
        //HttpClient : 인터넷을 통해 http 요청 보내고 응답 받을 수 있도록 기본 도구인 객체 만듦> API 서버로 데이터 가지러갈때 트럭역할 
        //new PokemonApiDataSource(new HttpClient()) : API 전문가 객체 생성(API와 통신하는 방법을 아는 전문가) > 어떤 트럭 사용할건지 알고 있음.API 서버 정확 주소요청방법 알고 있음 
        // new PokemonRepository(new PokemonApiDataSource(...)) :  데이터 총 책임자 >PokemonRepository 이름의 총 책임자 객체 생성 >API 전문가에게 일시켜 데이터업무총괄
        //repository = ...는 "데이터 총책임자라는 직책

        Result<Pokemon, PokemonError> result = await repository.GetPokemonByNameAsync("ditto");
        Assert.That(result is Result<Pokemon, PokemonError>.Success, Is.True); // API 호출이 성공했는지? check 
        //  result라는 변수가 Result 클래스 안에 정의된 Success라는 중첩 클래스(Nested Class) 타입의 객체인지 확인

        Pokemon pokemon = (result as Result<Pokemon, PokemonError>.Success)!.data; //성공한 데이터에서 포켓몬 객체를 잘 꺼냈는지?
        // (result as Result<Pokemon, PokemonError>.Success) :"혹시 ~라면" - 안전한 타입 변환 /as 키워드는 result 객체를 Success 타입으로 변환을 시도
        // esult가 정말 Success 객체라면, Success 타입으로 변환된 객체 / result가 Error 객체라면, 예외(에러)를 발생시키며 프로그램을 멈추는 대신 null 값을 반환합니다. 이것이 as 키워드의 핵심 특징
        // 절대 null이 아니야!
        // .data; 데이터를 꺼내줘 > 속성(프로퍼티) 접근
        //Success 타입으로 변환된 객체 안에서, 실제 포켓몬 데이터가 담겨있는 data라는 속성(멤버 변수)에 접근하여 그 값을 가져옴 
        //result를 Success 타입으로 바꿔보고(as), 그 결과가 절대 null이 아닐 거라고 컴파일러를 안심시킨 뒤(!), 내용물인 data를 꺼내 pokemon 변수에 저장
        Assert.That(pokemon.Name, Is.EqualTo("ditto")); //그래서 그 꺼낸 데이터의 내용물이 우리가 예상한 'ditto'가 정말 맞아? 
    }

    [Test]
    public async Task Result_Fail_Test()
    {
        IPokemonRepository repository = new PokemonRepository(new MockErrorDataSource()); // 가짜 데이터 생성해서 넣을거임

        // 404 일때
        Result<Pokemon, PokemonError> result = await repository.GetPokemonByNameAsync("404");
        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.False); // 결과가 에러 맞지?
        PokemonError error = (result as Result<Pokemon, PokemonError>.Error)!.error;
        // result 객체를 Error 타입으로 변환해달라고 시도
        //result가 진짜 Error 객체라면, 변환에 성공
        //result가 Success 객체라면, 변환에 실패하고 null을 반환합
        // .error; : 속성(프로퍼티)에 접근 
        //Error 타입으로 변환된 객체 안에서, PokemonError.NotFound와 같은 실제 에러 정보가 담겨있는 error 속성의 값을 꺼내옴
        Assert.That(error == PokemonError.NotFound, Is.True);

        // NetworkError
        result = await repository.GetPokemonByNameAsync("NetworkError");
        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);

        error = (result as Result<Pokemon, PokemonError>.Error)!.error;
        Assert.That(error == PokemonError.NetworkError, Is.True);

        // UnknownError
        result = await repository.GetPokemonByNameAsync("1111");
        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);

        error = (result as Result<Pokemon, PokemonError>.Error)!.error;
        Assert.That(error == PokemonError.UnknownError, Is.True);
    }
}

public class MockErrorDataSource : IPokemonApiDataSource
{
    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        if (pokemonName == "404")
        {
            return new Response<PokemonDto>(
                404,
                new Dictionary<string, string>(),
                new PokemonDto()
            );
        }

        if (pokemonName == "NetworkError") // 최악의 상황 비밀 스위치 
        {
            throw new ArgumentException("NetworkError"); //예상치 못한 예외(Exception)를 강제로 일으키는 코드 
            // 그 스위치가 눌렸으면 정상적인 흐름 깨뜨리는 예외를 강제로 던짐 > 잘못된 인자 전달됬다는 의미의 예외 > 네트워크 에러 흉내내기위해 
        }

        return new Response<PokemonDto>( // 기본 반환값 
            -1, // 아무것도 정의되지 않은 기본 상태 > catch-all을 위한 값 (모든 경우) > 404, 네트워크 오류만 테스트 하기위한 가짜데이터임 
            new Dictionary<string, string>(), // 문자열(string)을 키(Key)로 사용해서 또 다른 문자열(string) 값을 찾아올 수 있는 비어있는 '사전(Dictionary)' 데이터 저장소를 새로 만든다
            new PokemonDto() // 포켓몬 데이터를 담기 위한 비어있는 '데이터 상자(객체)'를 새로 만든다
        );
    }
}