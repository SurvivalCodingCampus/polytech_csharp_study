## Model, Repository

### Model

- 모델 객체 클래스의 속성에 대한 데이터를 조회할 수 있는 클래스
- 일반적으로 별도의 기능을 가지지 않는 순수한 불변 객체로 작성하는 것이 이상적

    ```csharp
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        
        // 아이템 목록 등을 추가할 수 있습니다. 
    }
    ```


### Repository

- Repository 패턴
    - 소프트웨어 개발에서 데이터 저장소에 접근하는 객체를 추상화하고
    - 데이터 소스(DB, File, 서버 API 등)와의 통신을 담당하는 객체를 캡슐화하는 디자인 패턴
    - 비즈니스 로직과 데이터 소스를 분리하는 데 중점
    - 이점
        - 관심사 분리
            - 게임의 핵심 로직과 데이터 저장 및 로딩 로직을 명확하게 분리
            - 플레이어 인벤토리 관리
        - 테스트 용이성
            - 데이터 소스를 Mocking하여 단위 테스트를 쉽게 작성
            - PlayerRepository를 테스트할 때 실제 서버 없이 가짜 데이터를 사용해 로직 검증
        - 확장성
            - 새로운 데이터 저장 방식을 추가하기에 용이
                - 로컬 파일 저장 게임을 클라우드 저장소로 옮길 때

### 데이터 소스와 리포지토리

- 데이터 소스 : 실제 데이터가 저장된 매체와 직접 소통하는 코드 포함
    - 데이터를 읽고 쓰는 **구체적인 메커니즘**에 집중
    - 용도에 맞는 저장 매체 특화 로직 구현 → 저장 매체와 직접적인 소통
        - File 조작
        - 서버와 통신
        - 메모리 사용
        - 데이터 형식 변환 등

    ```csharp
    // 데이터 소스의 역할을 정의하는 인터페이스
    public interface IPlayerDataSource
    {
        Task SavePlayer(Player player);
        Task<Player> LoadPlayer(string playerId);
        Task<List<Player>> LoadPlayers();
    }
    ```

- 리포지토리 : 어떤 데이터를 제공할지에 초점, 데이터 소스 관리
    - 데이터 소스를 숨기고 상위계츠에서 일관된 방법으로 데이터에 접근하는 방식을 제공
    - 데이터를 비즈니스 로직에 전달

    ```csharp
    // 리포지토리의 역할을 정의하는 인터페이스
    public interface IPlayerRepository
    {
        Task SavePlayer(Player player);
        Task<Player> LoadPlayer(string playerId);
        Task<List<Player>> LoadPlayers();
        
        // 도메인 특화 쿼리 예시
        Task<List<Player>> GetPlayersByLevel(int intLevel, int maxLevel);
    }
    ```

- 예시
    - `PlayerDataSource` : 유저 데이터를 저장하거나 불러오는 로직 담당
    - `PlayerRepository` : `PlayerDataSource` 를 사용하여 플레이어의 레벨, 경험치, 아이템 목록 등을 제공하는 메서드 구현
    - `GetPlayerByLevel()` 같은 게임 도메인(비즈니스 문제 영역) 특화 쿼리를 포함할 수 있음
    -
- 도메인 특화 기능을 Repository가 제공하는 경우의 장점
    - 도메인 의도가 명확히 드러남
    - 재사용 가능한 쿼리 로직
    - 데이터 소스 구현과 분리된 비즈니스 요구사항 처리
- 주의할 점
    - Repository는 어떤 데이터를 전달할지에 집중
    - Repository는 직접적인 데이터 조작이 아닌 필요한 데이터를 골라내는 일을 할 것
    - 저장 매체를 다루는 코드는 DataSource에서 하도록 할 것
    - 복잡한 비즈니스 로직은 더 상위 계층으로