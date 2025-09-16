## Result 패턴

### 서버에 데이터 요청 시 예상되는 상황

- 성공
- 실패
    - 네트워크 연결이 아예 안 되어 있음
    - 네트워크 불안정으로 타임아웃 발생
    - 논리적으로 잘못된 값
    - 내가 판단했을 때 에러임
- 에러처리의 기본 `try-catch`
    - 런타임에러, 논리 오류, 예외상황에 대한 처리 부족

  ⇒ Result 패턴은 여러가지 성공, 실패 처리에 유용


---

### Result 클래스

- `Result` 클래스는 성공시에 데이터를, 실패시 에러 정보(`Exception, String`)를 담는 객체 정의
    - `record`는 불변, 동등성 비교(`Equals, HashCode`), `ToString` 재정의 효과를 가지는 class 형태
    - `sealed` 클래스는 타입 봉인 효과 (enum하고 비슷한 효과 + 다른 객체의 참조 가질 수 있음)
    - 예시

        ```csharp
        public abstract record Result<TData, TError>
        {
        	// 성공 케이스 : 데이터 담음
        	public sealed record Success(TData data) : Result<TData, TError>;
        	
        	// 실패 케이스 : 에러 정보를 담음
        	public sealed record Error(TError error) : Result<TData, TError>;
        }
        ```

- 에러 타입을 enum으로 정의

    ```csharp
    public enum PokemonError
    {
    	NetworkTimeout,
    	NotFound,
    	Unknown,
    	AuthenticationFailed
    }
    ```

- Repository는 Result 타입을 반환

  → 코드만 봐도 어떤 에러가 발생할지 알기 때문에 코드가 문서화되는 효과

    ```csharp
    public interface IPokemonRepository
    {
    	Task<Result<Models.Pokemon, PokemonError>> GetPokemonByNameAsync(string pokemon);
    }
    ```

- 결과를 `Result`로 반환하기
    - 여러가지 에러를 Result 형식으로 내보낼 수 있음
- Result 패턴 사용 시 효과
    - swith문과 조합하여 성공/실패 처리
- Result 패턴 사용 시 장점
    - 타입 안정성 향상
    - 명확한 분기 처리
    - 에러 처리 누락 방지 유도