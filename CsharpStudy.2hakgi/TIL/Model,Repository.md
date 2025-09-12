## Test 이론, Model/Repository 

### 과제 리뷰

- `public string Name { get; set; }`
    - 프로퍼티는 변수가 아니라 메서드다
- `Person person = new Person { Name = "aaa", Age = 10 }`
    - 이니셜라이저 방식 (일부 회사에서는 사용을 권장하지 않는다)
- `List<Person>? people = new List<Person>();`
    - ? = null 을 허용한다
- `List<Person>? people = JsonConvert.DeserializeObject<LIst<Person>>(text) ?? [ ]`
    - ?? 의 앞의 값이 Null 인 경우 ?? 뒤의 값을 사용한다

### 테스트 방법론

- 화이트 박스 테스트
    - 내부 구조와 동작에 중점을 두고 테스트
    - 코드의 내부 로직, 제어 흐름, 데이터 흐름 등을 이해하고 검증하는데 사용
    - 테스트 케이스를 설계할 때 코드의 특정 부분을 직접 확인
    - 주요 기법으로는 구문 검사, 경로 검사, 조건/분기 검사 등이 있다
- 블랙 박스 테스트
    - 소프트웨어의 내부 구조를 무시하고 기능을 테스트하는 방법
    - 시스템 동작에 대한 내부 정보 없이 사용자 관점 테스트
    - 테스트 케이스는 입력값과 예상출력값에 기반해서 설계
    - 요구 사항 충족 여부 확인하고, 시스템의 기능적/비기능적 요구 사항을 테스트
    - 주요기법으로는 등가 분할, 경계값 분석 상태 전이 테스트 등이 있다

### 단위 테스트(UnitTest)

- 특정 모듈이 의도한 대로 잘 작동하는가를 테스트하는 가장 작은 단위의 테스트
- 반드시 단위 테스트를 진행해야하는 경우
    - **DB**: 스키마 변경, 모델 클래스가 변경되는 경우
    - **Network**: 네트워크 연결이 정상적이거나 안된 경우
    - **데이터 검증**: 예측한 데이터를 제대로 처리하고 있는지, 잘못되 데이터가 들어오는 경우

### 테스트 케이스 종류

- **동등 분할**: 테스트 케이스의 그룹을 나눠 그룹마다 대표값만 확인

    ```csharp
    [Test] 
    [TestCase(50)] // C# 에서 테스트 케이스를 지정하는 방식
    [TestCase(1)]
    [TestCase(120)]
    public void ValidateAge_ShouldBeTrue_ForValidRange(int age)
    {
        // Assert
        Assert.That(_service.ValidateAge(age), Is.True);
    }
    ```

- **경계값 분석**: 각 범위의 경계 근처의 값을 확인

    ```csharp
    [Test]
    [TestCase(0, false)]  // 경계값 -1
    [TestCase(1, true)]   // 경계값
    [TestCase(2, true)]   // 경계값 +1
    [TestCase(119, true)] // 경계값 -1
    [TestCase(120, true)] // 경계값
    [TestCase(121, false)]// 경계값 +1
    public void ValidateAge_ShouldHandleBoundaryValuesCorrectly(int age, bool expected)
    {
        // Assert
        Assert.That(_service.ValidateAge(age), Is.EqualTo(expected));
    }
    ```


### TDD(TestDrivenDevelopment)

- 테스트 중심으로 개발하는 방법론
- 테스트 코드를 먼저 작성하고, 성공하도록 수정

### TestDouble

- 테스트를 진행하기 어려운 경우에 테스트가 가능하도록 만들어주는 객체

  *→ 영화 촬영 시 위험한 역할을 대신하는 스턴트 더블에서 비롯되었다.*

- https://tecoble.techcourse.co.kr/post/2020-09-19-what-is-test-double/
- TestDouble 객체의 종류(용어)는 모호한 경계를 가지므로 용어에 집착하지 말 것
    - (예) Fakes, Spies, Mocks, Stubs Dumies….
    - 본 수업에서는 Mocks 객체로 용어를 통일한다
- ***Mock 객체를 활용한 테스트***
    - 때때로 단위 테스트는 **서버나 DB**에서 데이터를 가져오는 클래스에 의존할 수 있다
    - 이 경우 다음과 같은 몇 가지 이유로 불편하다
        - 테스트 실행 속도가 느려진다
        - 예기치 않은 결과를 반환하면 통과 테스트가 실패하기 시작할 수 있다.
        - 가능한 모든 성공 및 실패 시나리오를 테스트하는 것은 어렵다
        - 따라서 라이브 웹 서비스나 데이터베이스에 의존하는 대신 이러한 종속성을 Mocking할 수 있다.
    - Mock은 실제 구현 객체를 에뮬레이션하고 상황에 따라 특정 결과를 반환할 수 있다.

### 테스트

- 테스트가 어려운 구조: 인터넷 연결이 끊어졌거나, 의존성이 강한 경우
- 테스트의 용이성: 다형성을 활용하면 테스트할 때 원하는 객체를 활용 가능
    - 테스트용 객체를 별도로 준비하여 테스트 가능 → Interface 활용

### **좋은 Unit Test 의 6가지 조건 (FRIEND)**

- Fast (빠르고)
- Reliable (믿을 수 있고)
- Independent (독립적인)
- Ease of Maintenance (유지 관리가 쉽고)
- Nearly compacted code (거의 압축적인 코드)
- Dependencies should be less (의존성이 적어야 한다)

### Model

- 모델 객체 클래스의 속성에 대한 데이터를 조회할 수 있는 클래스
- 일반적으로 별도의 기능을 가지지 않는 순수한 불변 객체로 작성하는 것이 이상적
- 데이터 구조 정의, 데이터 홀더, 직렬화 / 역직렬화

### Repository 패턴

- 소프트웨어 개발에서 데이터 저장소에 접근하는 객체를 추상화하고 데이터 소스(DB,File,Server API 등)와의 통신을 담당하는 객체를 캡슐화하는 디자인 패턴
- 데이터를 **어디서/어떻게** 가져오는지 감추고(**추상화**)
- 도메인/서비스는 하나의 공통 계약(인터페이스)으로 접근하게 한다
- 이 패턴은 비즈니스 로직과 데이터 소스를 분리하는 데 중점을 둔다
- **Repository의 책임과 역할**
    - 데이터 접근의 진입점
    - 데이터 접근에 대한 추상화 계층
    - 데이터 소스 은닉
    - 비즈니스 로직과 데이터 소스 사이의 중재자
    - 데이터 매핑, 변환 담당
- **Repository 패턴의 장점**
    - 관심사 분리
        - 게임의 핵심 로직과 데이터 저장 및 로딩 로직을 명확하게 분리
        - 플레이어 인벤토리 관리 : InventoryRepository
    - 테스트 용이성
        - 데이터 소스를 Mocking하여 단위 테스트를 쉽게 작성할 수 있음
        - PlayerRepository를 테스트할 때 실제 서버 없이 가짜 데이터를 사용해 로직을 검증
    - 확장성
        - 새로운 데이터 저장 방식을 추가하기 용이
        - 예: 로컬 파일 저장 게임을 클라우드 저장소로 옮길 때
- **도메인 특화 기능을 Repository 가 제공하는 경우의 장점**
    - 도메인 의도가 명확히 드러남
    - 재사용 가능한 쿼리 로직
    - 데이터 소스 구현과 분리된 비즈니스 요구사항 처리
- **주의할 점**
    - Repository는 어떤 데이터를 전달할지에 집중
    - Repository는 직접적인 데이터 조작이 아닌 필요한 데이터를 골라내는 일을 할 것
    - 저장 매체를 다루는 코드는 DataSource 에서 하도록 할 것
    - 복잡한 비즈니스 로직은 더 상위 계층으로

### 요약

- DataSource는 직접적인 데이터 접근에 대한 방법을 작성
- Model 객체는 데이터 구조 정의 (순수 데이터만, 불변)
- Repository는 DataSource 사용 및 관리, 필요한 데이터 전달에 집중
- 단순하고 명확한 구조 유지
- 이렇게 하면 데이터 관리가 깔끔해진다