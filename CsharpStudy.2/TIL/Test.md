## Test 이론 

### 테스트하는 방법

- 수동 테스트 : 인간이 하는 테스트 (print)
- 단위 테스트 : 1개의 함수를 테스트 (test 코드)
- 통합 테스트 : 여러 개 연관된 테스트나 함수를 함께 테스트 (UI test, Intengration test)

### 테스트 방법론

- **화이트 박스 테스트**
    - 내부 구조와 동작에 중점을 두고 테스트 하는 방법
    - 코드의 내부 로직, 제어 흐름, 데이터 흐름 등을 이해하고 검증하는 데에 사용
    - 테스트 케이스를 설계할 때 코드의 특정 부분을 직접 확인
    - 구문 검사, 경로 검사, 조건/분기 검사 등
- **블랙박스 테스트**
    - 소프트웨어의 내부 구조를 무시하고 기능을 테스트하는 방법
    - 시스템이 어떻게 동작하는 지에 대한 내부 정보를 알 필요 없이 사용자 관점에서 테스트
    - 테스트 케이스는 입력 값과 예상 출력 값에 기반하여 설계
    - 요구 사항을 충족하는지 확인하고, 시스템의 기능적 및 비기능적 요구사항을 테스트
    - 등기분할, 경계값 분석, 상태 전이 테스트 등

### Unit Test (단위 테스트)

- 특정 모듈이 의도한 대로 잘 작동하는가 테스트하는 가장 작은 단위의 테스트
    - 모듈 = 메서드, 기능
- 새로운 기능을 추가하거나 기존 기능을 변경했을 때, 앱이 여전히 제대로 동작하는지

### 테스트 장점

- 장애에 관한 신속한 피드백
- 개발주기에서 조기 장애 감지
- 회귀에 신경쓸 필요 없이 코드를 최적화할 수 있도록 하는 더 안전한 코드 리팩터링
- 기술적 문제를 최소화하는 안정적인 개발 속도

### 테스트 케이스


 : 가능한 모든 가능성의 범위를 테스트하는 것이 좋은 테스트 케이스

- 동등분할
- 경계값 분석 등

```csharp
// 테스트 대상 클래스 
public class MemberService
{
	public bool ValidateAge(int age)
	{
		return age >= 1 && age <= 120;
	}
}	

// 1. 동등분할 테스트
[Test]
[TestCase)(50)]
[TestCase)(1)]
[TestCase)(120)]
public void ValidateAge_ShouldBeTrue_ForValodRange(int age)
{
    //Assert
    Assert.That(_service.ValidateAge(age), Is.True)
}

[Test]
[TestCase)(0)]
[TestCase)(-5)]
[TestCase)(150)]
public void ValidateAge_ShouldBeFalse_ForValodRange(int age)
{
    //Assert
    Assert.That(_service.ValidateAge(age), Is.False)
}

// 2. 경계값 분석 테스트
[Test]
[TestCase)(0, false)]
[TestCase)(1, true)]
[TestCase)(2, true)]
[TestCase)(119, true)]
[TestCase)(120, true)]
[TestCase)(121, false)]
public void ValidateAge_ShouldHandleBoundaryValuesCorrectly(int age, bool expected)
{
    //Assert
    Assert.That(_service.ValidateAge(age), Is.EqualTo(expected));
}
```

- 단위 테스트가 꼭 필요한 이유
    - DB
        - 스키마가 변경되는 이유
        - 모델 클래스가 변경되는 경우
    - Network
        - 네트워크 연결이 정상적인 경우
        - 네트워크 연결이 안되었을 때
    - 데이터 검증
        - 예측한 데이터를 제대로 처리하고 있는지
        - 잘못된 데이터가 들어올 경우
- TDD (Test Driven Development)
    - 테스트 중심으로 개발하는 방법론
        - 테스트 코드를 먼저 작성하고
        - 테스트가 성공하도록 코드를 수정

### Test Double

- 테스트를 진행하기 어려운 경우에 테스트가 가능하도록 만들어주는 객체
- Test Double의 경계 : 모호한 경계를 가지므로 용어에 집착하지 말 것

### Mock 객체 활용

- 실제 구현 객체를 에뮬레이션하고 상황에 따라 특정 결과를 반환
    - 단위테스트는 서버나 DB에서 데이터를 가져오는 클래스에 의존

      → 테스트 실행 속도가 느려짐

      → 예기치 않은 결과를 반환하면 통과 테스트가 실패하기 시작

      → 가능한 모든 성공 및 실패 시나리오를 테스트하는 것 어려움

      → 라이브 웹 서비스나 데이터 베이스에 의존하는 대신 종속성을 `Mocking`

- 테스트 용이성
    - 테스트가 어려운 구조
        - 인터넷이 끊어지거나 서버가 죽으면 테스트 불가

          ![image.png](attachment:a8036826-b11c-409f-b2f0-383c24e90d98:image.png)

    - 다형성을 활용하면 테스트할 때 원하는 객체를 활용 가능
        - 테스트용 객체를 별도로 준비하여 테스트 가능
        - `Interface` 활용

          ![image.png](attachment:de7a5afb-ed59-4f8f-b6c6-54542ad8dab7:image.png)

    - **클래스 내부에서 다른 클래스를 생성하기보다 외부에서 받도록**
- Mock 객체 작성 예시

    ```csharp
    public class MockUserRepository : IUserRepository
    {
        private readonly Dictionary<int, User> _users = new Dictionary<int, User>
        {
            { 1, new User { Id = 1, Name = "Alice" } },
            { 1, new User { Id = 2, Name = "Bob" } },
    
        };
        
        public int GetByIdCallCount {get; private set;}
    
        public User GetById(int id)
        {
            GetByIdCallCount++;  // 호출 횟수 증가
            
            // 미리 설정된 데이터에서 값을 반환
            return _users.GetValueOrDefault(id);
        }
    }
    ```

- 테스트 코드 예시

    ```csharp
    [Fact]
    public void GetUserName_ShouldReturnCorrectName_WhenUserExists()
    {
        // Arrange
        // 수동으로 만든 Mock 객체 생성
        var mockUserRepository = new MockUserRepository();
        
        // 테스트할 Service 클래스에 Mock 객체 주입
        var userService = new UserService(mockUserRepository);
        
        // Act
        var userName = userService.GetUserName(1);
        
        // Assert
        // 1. 반환된 결과 검증
        Assert.Equal("Alice", userName);
        
        // 2. 메서드 호출 횟수 검증 (행위 검증)
        Assert.Equal(1, mockUserRepository.GetByIdCallCount);
    }
    ```

- 좋은 Unit Test 6가지 조건
    - `fast` 빠르고
    - `Reliable` 믿을 수 있고
    - `Independent` 독립적인
    - `Ease of Maintenance` 유지관리가 쉽고
    - `Nearly compacted code` 거의 압축적인 코드
    - `Dependencies should be less` 의존성이 적어야 한다.
