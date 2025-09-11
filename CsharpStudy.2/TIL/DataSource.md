## DataSource

### UI, 데이터와 로직을 분리해야 하는 이유

- 유지보수 지옥
    - 아이템 능력치를 바꾸려면 코드를 수정하고 다시 빌드해야 함
- 협업의 비효율성
    - 기획자나 아티스트가 데이터를 수정하고 싶어도 개발자에게 의존해야 함

⇒ 데이터와 로직을 분리

---

### DataSource

- 앱이 사용하는 원천 데이터
    - 마치 요리할 때 재료
    - 파일, 텍스트, Json, DB 등 다양한 형태
- 앱은 단독으로 데이터를 만들어내지 않음
- 대부분 외부에서 받아와서 화면에 보여줌
1. 역할
    - 외부 데이터 저장소와 직접 통신
    - Raw 데이터 수신 및 처리
    - CRUD 작업 수행

   ⇒ 주로 데이터를  **Create, Read, Update, Delete** 하는 역할

2. 종류
    - Text (.txt 등)
    - File (로컬 파일)
    - Json (웹 API에서 자주 사용)
    - XML
    - CSV (엑셀 같은 형식)
    - RDBMS (MySQL, PostgreSQL 등 관계형 DB)
    - NoSQL (MongoDB, Firebase Firestore 등)
    - 각 소스마다 장단점이 다르며,  상황에 따라 적절히 선택
3. 예시
    1. 아이템 데이터 관리
        - 게임에 등장하는 모든 아이템의 정보(이름, 능력치, 설명 등)을 코드에 입력하는 대신, **외부 파일에 저장하고 게임 실행 시 불러와서 사용**
    2. 세이브 파일
        - 게임 플레이 중 발생한 모든 상태 변화를 저장하는 외부 파일
            - 캐릭터 레벨, 아이템 인벤토리, 진행 상황 등
4. 데이터 모델 정의
    - 데이터 구조를 정의
    - 저장할 데이터 모양을 클래스로 작성

    ```csharp
    public class Person
    {
    		public string Name { get; set; }
    		public int Age { get; set; }
    		
    		public Person(string name, int age)
    		{
    				Name = name;
    				Age = age
    		}
    }
    ```

5. 데이터 소스의 기능 정의
    - 데이터 소스에 대한 추상화를 담당하는 인터페이스 정의
    - 기본적인 기능을 제공하지만, 실제 데이터가 어디에 저장되는지 신경쓰지 않음

    ```csharp
    public interface IDataSource
    {
    		public Task<List<Person>> getPeopleAsync();
    		public Task SavePeopleAsync(List<Person> people);
    }
    ```

6. 인터페이스를 구현하는 데이터 소스
    - 기능을 구현하는 클래스

    ```csharp
    public class InMemoryDataSource : IDataSource
    {
    		private readonly List<Person> _people = new List<Person>();
    		
    		public async Task<List<Person>> GetPeopleAsync()
    		{
    				await Task.Delay(500);
    				return _people;
    		}
    		
    		public async Task SavePeopleAsync(List<Person> people)
    		{
    				await Task.Delay(500);
    				_people.AddRange(people);
    		}
    }
    ```

7. 유연한 설계
    1. 이름 짓기
        - 저장소 위치 기준 (어디에 저장?)
            - `LocalUserDataSource` `RemoteUserDataSource` `CachedUserDataSource`
        - 기술 스택 기준 (어떤 기술로 구현?)
            - `RoomUserDataSource` `RetrofitUserDataSource` `SharePrefsUserDataSource`
    2. 인터페이스 사용
        - 데이터 저장 방식(로컬 파일, 온라인 서버)을 유여하게 변경 가능
        - `I` 접두사를 사용한 인터페이스명
        - 인터페이스와 구현체 구분 용이
        - 많은 기업, 프로젝트에서 채택하는 관례

        ```csharp
        // 인터페이스 정의
        public interface IUserDataSource
        {
        		Task<User> GetUser(string userId);
        		Task SaveUser(User user);
        }
        
        // 파일 기반 데이터 소스 구현
        public class FileUserDataSource : IUserDataSource
        {
        		public async Task<User> GetUser(string userId)
        		{
                            // Json 파일에서 유저 데이터를 읽어오는 로직
        		}
        		
        		public async Task SaveUser(User user)
        		{
                            // Json 파일에 유저 데이터를 저장하는 로직
        		}
        }
        ```

8. 디렉토리 구조
- `Project Name/`
    - `Models/`
        - `person.cs`
    - `Interfaces`
        - `IDataSource.cs`
    - `DataSource`
        - `JsonFileDataSource.cs`
    - `Program.cs`