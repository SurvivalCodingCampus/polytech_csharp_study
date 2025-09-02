using System.Globalization;
using Newtonsoft.Json;

namespace CsharpStudy.Data;

class Sword // 검 
{
    public string Name { get; set; }

    public Sword(string name) // 생성자 
    {
        Name = name;
    }
}

class Hero
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
    public List<string> Items { get; set; } = new List<string>(); // 아이템 목록 
    public Sword? Sword { get; set; } // 영웅이 가진 검 (다른 클래스 포함)

    public Hero(string name, int hp, int mp) // 생성자 
    {
        Name = name;
        Hp = hp;
        Mp = mp;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Hp)}: {Hp}, {nameof(Mp)}: {Mp}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // new Program().JsonSerialization(); >> static을 생략할 경우 , 한 번만 사용할 땐 변수 안쓰고 바로 new 가능 
        JsonSerialization(); // 메서드 : 객체를 JSON 파일로 저장하기 > 직렬화 
        JsonDeserialization(); //메서드: JSON 파일에서 객체로 복원하기 > 역직렬화 
    }

    // 직렬화 > 서로다른 프로그램이 통신 하려함 > 같이 약속 정해야함 
    // 메모리상에 있는걸 남겨놔야함 > 파일 저장시 제이슨 형태로 저장 > 다른 언어의 프로그램과 통신하려고 > 서로다른 서비스 간에 통신 하려고 
    static void JsonSerialization() // 객체를 JSON 파일로 저장하기 > 직렬화 
    {
        // 직렬화
        // 1. 메모리에 Hero 객체를 생성하고 데이터 채우기 
        Hero hero = new Hero("홍길동", 100, 50);
        hero.Items.Add("물약");
        hero.Items.Add("반창고");
        hero.Sword = new Sword("불의 검");
        // 2. 직렬화 : hero 객체를 JSON 문자열로 변환 
        string jsonString = JsonConvert.SerializeObject(hero); //JsonConvert.SerializeObject() : 자동으로 변환해줌 
        // 3. 변환된 결과를 확인
        Console.WriteLine(hero); // 객체의 ToString() 결과 출력 
        Console.WriteLine(jsonString); // JSON 문자열 출력 
        // 4. 변환된 JSON 문자열을 "hero.json"파일에 저장 
        File.WriteAllText("hero.json", jsonString);
    }

    static void JsonDeserialization() // 역직렬화 
    {
        // 역직렬화
        // 1. 아까 저장했던 "hero.json"파일의 모든 텍스트를 읽어옴 
        string jsonString = File.ReadAllText("hero.json");
        // 2. 역직렬화 : 읽어온 JSON 문자열을  -> 다시 Hero 겍체로 복원
        // 어떤 타입의 객체로 복원할지 <Hero>로 알려주는게 중요 
        Hero? hero = JsonConvert.DeserializeObject<Hero>(jsonString);
        // 3. 복원된 객체의 정보를 출력하여 확인 
        Console.WriteLine(hero);
    }

    // ------------- 수작업 과정 예시 ------------------------------

    // PropertyParser() 메서드는 key=value 형태로 작성된 .properties 파일을 읽어서 처리하는 방법
    // 파일 1줄씩 읽어 '=' 기호 기준 직접 문자열 자리고 결과를 Dictionary에 수작업 저장  
    static void PropertyParser()
    {
        // 1. key-value 데이터를 저장할 Dictionary를 준비
        Dictionary<string, object> heroes = new Dictionary<string, object>();

        // 2. "hero.properties" 파일의 모든 줄을 읽어와 문자열 배열에 담음
        // hero.properties 파일 내용 예시:
        // heroName=홍길동
        // heroHp=100
        string[] heroesArray = File.ReadAllLines("hero.properties");

        // 3. 각 줄을 반복하면서 처리
        foreach (var hero in heroesArray)
        {
            // 4. '=' 문자를 기준으로 문자열을 자름
            // "heroName=홍길동" -> ["heroName", "홍길동"]
            string key = hero.Split("=")[0]; // "=" 앞부분을 key로 저장
            string value = hero.Split("=")[1]; // "=" 뒷부분을 value로 저장
            // 5. Dictionary에 key와 value를 추가
            heroes.Add(key, value);
        }

        // 6. 완성된 Dictionary의 내용을 출력
        foreach (var keyValuePair in heroes)
        {
            Console.WriteLine(keyValuePair.Key + " : " + keyValuePair.Value);
        }
    }

    // '.csv'피일을 한 줄씩 읽어 쉼표(,)를 기준으로 문자열 자름 > 숫자 데이터는 int.Parse()로 직접 형변환 -> Hero 객체 리스트 만듦 
    // hero.csv 파일 내용 예시:
    // 이름,hp,mp  <-- 헤더(Header)
    // 홍길동,100,50
    // 이순신,150,20
    static void CsvParser()
    {
        // 이름, hp, mp
        // CSV
        // string hero = "영웅,100,50";
        // File.WriteAllText("hero.csv", hero);

        List<Hero> heroes = File.ReadAllLines("hero.csv")
            .Skip(1) // 1. Skip(1): 첫 번째 줄(헤더)은 데이터가 아니므로 건너뜀
            .Select(line => // 2. Select: 남아있는 각 줄(line)에 대해 아래의 변환 작업을 수행
            {
                // 3. 쉼표(',')를 기준으로 문자열을 자름 -> "홍길동,100,50" -> ["홍길동", "100", "50"]
                string name = line.Split(",")[0];
                // 4. hp와 mp는 문자열이므로 int.Parse를 이용해 숫자로 변환
                int hp = int.Parse(line.Split(",")[1]);
                int mp = int.Parse(line.Split(",")[2]);
                // 5. 추출하고 변환한 데이터로 새로운 Hero 객체를 생성하여 반환
                return new Hero(name, hp, mp);
            })
            .ToList(); // 6. Select를 통해 만들어진 Hero 객체들을 최종적으로 List로 만듦

        heroes.ForEach(Console.WriteLine); // 7. 완성된 리스트의 내용을 화면에 출력
    }
}