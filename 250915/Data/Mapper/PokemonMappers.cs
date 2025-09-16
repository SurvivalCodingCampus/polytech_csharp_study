namespace _250915.Data.Mapper;

public static class PokemonMappers //한 객체를 다른 객체로 변환해주는 역할
{
    //매퍼는 코드에서 객체(PokemonDto)의 데이터를 다른 객체(Models.Pokemon)로 변환
    public static Models.Pokemon ToModel(this PokemonDto dto) //확장 메소드
    {
        return new Models.Pokemon //실제 변환 수행
        (
            id: dto.Id,
            name: dto.Name
            //새로운 Models.Pokemon 객체를 생성
        );
    }
    
}