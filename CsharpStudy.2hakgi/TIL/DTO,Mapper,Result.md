## ✅ DTO, Mapper

### DTO(DtatTransferObject)

- DTO: 데이터 소스를 모델 클래스로 변환하는 과정에서 순수하게 클래스에 담기 위한 중간 전달 객체
    - `JSON` → `DTO` → (Mapper) → `Model Class`
    - 잘못된 데이터 소스(json)를 받더라도, 문제가 없게끔 하려는 클라이언트 개발자의 방어 수단
    - 모든 필드를 Nullable 변수로 만들어 직렬화, 역직렬화가 가능하도록 한다

        ```json
        {
        	"userId": 1,
        	"id": 1,
        	"title": "title",
        	"completed": false
        },
        ```

        ```csharp
        using Netonsoft.Json;
        
        public class TodoDto
        {
        	[JsonProperty("userId")]
        	public int? UserId { get; set; }
        
        	[JsonProperty("id")]
        	public int? Id { get; set; }
        	
        	[JsonProperty("tilte")]
        	public string? Title { get; set; }
        	
        	[JsonProperty("completed")]
        	public bool? Completed { get; set; }
        }
        ```


### DTO 만드는 방법

- 인공지능에게 작성하고자 하는 Json 형태를 전달하고
    - `C# Dto로 만들고 모두 nullable 하게 해 줘. newtonsoft json 사용할거야`

### Mapper

```csharp
public static class TodoMapper
{
	public static TodoModel ToModel(this TodoDto dto)
	{
		// ToModel 확장 메서드는 TodoDto를 인수로 받고, 이를 TodoModel 객체로 변한하여 반환
		return new TodoModel(dto.Title!, dto.Completed!.Value);
	}
}
```

- 순수한 데이터인 DTO를 모델 클레스로 변환하기 위한 로직은 별도의 Mapper를 통해 진행한다
- `static` 메서드나 확장 함수를 활용하는 것을 추천한다
    - DTO 안에 작성하지 않는 이유는 데이터 저장용 클래스와 변환 로직을 분리하기 위함
    - Mapper는 복잡한 로직이 있을 수 있으므로 인공지능에게 부탁하기보다 인간이 작성하자
    - 문제가 발생하는 경우 DTO가 아닌 Mapper만 사용하면 된다
- Nullable을 `non-Nullable` 로 변환한다. 전체를 변환하는 것이 아니라 필요한 부분만 바꾼다.

### 추천 폴더 구조

```csharp
Data
ㄴ DataSource
	ㄴ IUserDataSource.cs
	ㄴ RemoteUserDataSource.cs
ㄴ DTOs
	ㄴ UserDto.cs
ㄴ Mapper
	ㄴ UserMapper.cs
ㄴ Models
	ㄴ User.cs
ㄴ Repositories
	ㄴ IUserRepository.cs
Program.cs
```

- `Json` → `DTO` → Mapper를 활용해 모델 클래스로 변환 → `Model`

### DTO가 필요한 이유

- 기존에 작성한 모델 클래스는 DTO 와 모델 클래스의 역할을 **모두 가지는** 클래스 였다
- DTO 가 도입된다면 역할 분담 가능
    - DTO : 데이터 소스 직렬화, 역직렬화
    - 모델 클래스 : DTO에서 필요한 내용만 활용하는 도메인 객체
- Model Class 는 non-nullable 값만 가지고 있도록 한다
- Json 데이터는 null 값을 포함할 수 있음 (문서에 명시되어 있지 않더라도…)
- Map -> Model Class 변환시 null 값 등의 예외를 사전에 걸러내기 용이함
- 불완전한 코드가 포함될 것 같다면 DTO를 도입하자
- Json 값에 예외가 없다면 반드시 DTO를 도입할 필요는 없다

## ✅ Result 패턴

### 서버에 데이터 요청시 예상되는 상황

- 성공(Success)
- 실패(Error): 실패에는 다양한 원인이 있다(네트워크 연결 이슈, 논리적으로 잘못된 값 등..)

### 에러 처리의 기본 `try-catch`

- 기본적으로 예외는 `try-catch` 를 활용하여 처리 한다.
- 런타임 에러 뿐만 아니라 논리적인 오류나 예외 상황에 대한 처리를 하기에는 부족하다
- Result 패턴은 여러가지 성공, 실패를 처리할 때 유용한 패턴이다

### 성공과 실패 중 하나를 리턴하는 Result 클래스 예시

```csharp
public abstract rescord Result<TData, TError>
{
	private Result()
	{
	}
	
	// success case
	public sealed record Success(TData data): Result<TDAta, TError>;
	
	// fail case
	public sealed record Error(TError error): Result<TDAta, TError>;
}
```

- Result 클래스는 성공시에는 데이터를, 실패는 에러 정보(예: Exception, String)를 담는 객체를 정의한다
- `record` 는 불변, 동등성 비교(Equals, HashCode), ToString 재정의 효과를 가지는 class 의 형태이다
- `sealed` 클래스는 타입 봉인 효과를 가진다 (enum 하고 비슷한 효과 + 다른 객체의 참조를 가질 수 있다)
    - 특정 클래스를 상속할 수 있는 자식 클래스는 `sealed` 가 붙은 클래스만이라고 컴파일러에게 공식화

### Error 타입을 enum으로 정의

```csharp
public enum PokemonError
{
	NetworkTimeout,
	NotFound,
	Unknown,
	AuthenticationFailed
}
```

- 기존 Repository에서는 상세 에러를 알려주기 어렵다
    - `Task<Models.Pokemon?> GetPokemonByNameAsync(string pokemonName);`
- Result타입을 반환하게 되면, 코드만 봐도 어떤 에러가 발생할 지 알게 되므로 코드가 문서화 되는 효과.
    - `Task<Models.Pokemon, PokemonError> GetPokemonByNameAsync(string pokemonName);`
    - `switch(response.StatuseCode)` switch문과 조합해 성공 실패 처리
        - `case 404: return .... Error(PokemonError.NotFound)`

### 추천 폴더 구조

```csharp
Data
ㄴ Common
	ㄴ Response.cs
	ㄴ Result.cs ⬅️ Common,Core와 같은 폴더에 공용 파일 배치
ㄴ DataSource
	ㄴ IUserDataSource.cs
	ㄴ RemoteUserDataSource.cs
ㄴ DTOs
	ㄴ UserDto.cs
ㄴ Mapper
	ㄴ UserMapper.cs
ㄴ Models
	ㄴ User.cs
ㄴ Repositories
	ㄴ IUserRepository.cs
Program.cs
```

### Result 패턴의 사용 시 장점

- 타입 안정성 향상, 명확한 분기 처리, 에러 처리 누락 방지 유도

### 정리

- sealed class 는 서브타입을 봉인한다.
- sealed class 는 패턴매칭을 활용하여 모든 서브타입에 대한 처리를 하기 용이하다
- Result 패턴은 여러가지 종류의 성공과 실패를 처리하기 용이한 패턴이다
- 앱의 규모에 맞게 Result 패턴을 사용하자