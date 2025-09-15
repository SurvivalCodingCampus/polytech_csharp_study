## Dto, Mapper

- 문제점
    - 데이터 소스를 모델로 정의하기 어려운 경우(동적 Json)
    - 서버에서 아예 잘못된 값을 보내는 경우
    - 서버 API 변경으로 인한 필드 누락/제거
    - 서버 장애시 예상치 못한 응답 구조
    - 클라이언트/서버 버전 불일치

⇒ 방어적 코드 작성

서버 잘못에 클라이언트 독박 대비

`Repository`

→  `DataSource` → `Remote DB` →  `DataSource`

→ `DTO`  : JSON 그대로 담는 객체

→ `Mapper` 변환

→ `Model 클래스` : 앱에서 사용하는 객체

→ `Repository`

---

### DTO (Data Transfer Object)

- 데이터 소스를 모델 클래스로 변환하는 과정에서 순수하게 클래스에 담기 위한 중간 전달 객체
- 잘못된 데이터 소스(JSON)를 받더라도 안 터지게 하려는 클라이언트 개발자의 방어수단
- 예시

    ```csharp
    using Newtonsoft.Json;
    
    public class TodoDto
    {
        [JsonProperty("userId")]
        public int?  UserId { get; set; }
        
        [JsonProperty("id")]
        public int?  Id { get; set; }
        
        [JsonProperty("title")]
        public string?  Title { get; set; }
        
        [JsonProperty("completed")]
        public bool?  Completed { get; set; }
    }
    ```

    - 모든 필드가 `Nullable` 변수
    - 직렬화, 역직렬화 가능하도록 받음
    - json 형태 전달 → “C# Dto로 만들고 모두 Nullable하게 해줘. newtonsoft json 사용할거야”
- **모델 클래스 역할 재정의**
    - 모든 필드는 `non-nullable` 상수
    - `Equals` 재정의
    - `HashCode` 재정의
    - `ToString()` 재정의

  ⇒ 실제 필요한 내용으로만 구성


---

### Mapper

- DTO를 모델 클래스로 변환
    - `static` 메서드나 확장함수를 활용 추천
    - `Nullable` 을 `non-Nullable` 로 변환하자
- DTO 전체를 변환하는 것 아님, 필요한 부분만 변환
- 순수한 데이터 DTO를 모델 클래스로 변환하기 위한 로직은 별도의 mapper 통해 변환

```csharp
public class TodoMapper
{
    public static TodoModel ToModel(this TodoDto dto)
    {
        // Tomodel 확장 메서드는 ToDoDto를 인수로 받고,
        // 이를 객체로 변환하여 반환합니다.
        return new TodoModel(dto.Title!, dto.Completed!, Value);
    }
    
}
```

> **Mapper 작성 시 DTO 안에 작성하지 않고 static 또는 Extension 선호 이유**
> - 데이터 저장용 클래스와 변환 로직을 분리
> - Mapper는 복잡한 로직이 포함될 수 있어서 인간이 작성, 문제 있으면 여기만 살핌

---

**DataSource의 반환 타입으로 올바른 예시**

- `DTO`
- DTO를 담은 `Response` 반환

---

**DTO가 필요한 이유**

- `Model Class`는 `non-Nullable` 값만 가지고 있도록 한다
- Json 데이터는 `null` 값을 포함할 수 있음 (문서에 명시되어 있지 않더라도)
- `Map → Model Class` 변환 시 `null` 값 등의 예외를 사전에 걸러내기 용이함
- 불완전한 코드가 포함될 것 같다면  DTO를 도입하자
    - Json값에 예외가 없다면 반드시 DTO 할 필요 없음