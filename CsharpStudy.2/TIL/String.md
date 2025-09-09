## 문자열 조작

### 1. 문자열 처리

- 결합
    - ‘+’ 연산
        
        ```csharp
         string s1 = "Hello";
         Console.WriteLine(s1 + " World");
        ```
        
        - 느린 이유 : String 인스턴스는 불변 객체
            
            → 문자열을 결합할 때마다 새로운 String 객체가 생성되므로 반복적인 결합 작업은 성능 저하 유발
            
    - String interpolation
        - {수식}을 활용한 문자열 결합
        
        ```csharp
        String name = "김철수";
        int age = 30;
        
        string message = $"안녕하세요, {name}님. 나이는 {age}살 입니다.";
        ```
        
    - String Builder
        
        ```csharp
            static void StringVsStringBuilder()
            {
                // 동적 생성
                string s1 = "Hello";
                Console.WriteLine(s1.GetHashCode());
                s1 = s1 + "World";
                Console.WriteLine(s1.GetHashCode());
        
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 100000; i++)
                {
                    // count++;
                    // s1 += "!";   // 3.47초
                    sb.Append("!"); // 0.0004초
                }
        
                // Console.WriteLine(s1 + " World");
                // Console.WriteLine($"{s1} World");
            }
        ```
        
        - Append() 메서드로 결합한 결과를 내부 메모리(버퍼)에 담아두고 ToString()으로 결과 얻음
        - 자기 자신의 참조를 반환하는 메서드를 연속해서 호출하는 기법 = **메서드 체인**
- 일부 떼어내기
    
    ```csharp
    String s1 = "HELLO";
    Console.WriteLine(s1.Substring(0,2));  // 결과 : HE
    Console.WriteLine(s1.Substring(2));  // 결과 : LLO (인덱스 2부터 끝까지)
    ```
    
- 일부 치환
    
    ```csharp
    String s1 = "HELLO";
    Console.WriteLine(s1.Replace("LL","XX"));  // 결과 : HEXXO
    ```
    
- 분리
    
    ```csharp
    String s1 = "1, 2, 3";
    String[] splitNumbers = s1.Split(',');
    foreach (string s in splitNumbers)
    {
    	Console.WriteLine(s.Trim());  // 결과 : 1 / 2 / 3 (각 줄)
    }
    ```
    
- 대소문자 변경
    
    ```csharp
    String s1 = "HELLO";
    Console.WriteLine(s1.ToLower());
    ```
    
- 길이
    
    ```csharp
    string greeting = "Hello, World!";
    int length = greeting.Length; // 13
    
    string emptyString = "";
    int emptyLength = emptyString.Length; // 0
    
    string s1 = null;
    string s2 = "";
    string s3 = " ";
    string s4 = "hello";
    
    // 문자열이 null, 빈 문자열, 또는 공백만으로 이루어져있는지
    Console.WriteLine(string.IsNullOrEmpty(s1));         // 결과 : True
    Console.WriteLine(string.IsNullOrEmpty(s2));         // 결과 : True
    Console.WriteLine(string.IsNullOrWhiteSpace(s3));    // 결과 : True (공백만으로 구성)
    Console.WriteLine(string.IsNullOrEmpty(s4));         // 결과 : False
    ```
    
- 검색
    
    ```csharp
    string s1 = "Java and JavaScript";
    
    Console.WriteLine(s1.Contains("Java"));  // 결과 : True
    Console.WriteLine(s1.EndsWith("Java"));  // 결과 : False
    Console.WriteLine(s1.IndexOf("Java"));  // 결과 : 0
    Console.WriteLine(s1.LastIndexOf("Java"));  // 결과 : 9
    ```
    
- 변환
    
    ```csharp
    string s1 = "Java and JavaScript";
    
    Console.WriteLine(s1.ToLower());  // 결과 : java and javascript
    Console.WriteLine(s1.ToUpper());  // 결과 : JAVA AND JAVASCRIPT
    Console.WriteLine(s1.Trim());  // 결과 : Java and JavaScript (좌우 공백 제거)
    Console.WriteLine(s1.Replace("and", "or"));  // 결과 : Java or JavaScript
    ```
    

### 2. 문자열

- **문자열**은 더하는 게 아니고 새로운 인스턴스 생성함
- 기존의 s1에 더하는 게 아니라 더해진 데이터를 새로운 메모리에 생성
- String은 불변이라서 더해도 새로운 메모리를 만들어서 시간이 오래걸림
- StringBuilder는 힙을 늘리지 않고 같은 메모리에 붙이는 식이라 빠름

### 3. Accessor, Mutator

```csharp
string uppercased = river.ToUpper();  // Accessor
pic.Translate(15, 25);  // Mutator
```

- Accessor
    - **원본 상태는 그대로 두고, 새로운 결과만 반환**.
        
        ```csharp
        string greeting = "Hello";
        
        Console.WriteLine(greeting.Replace("H", "J"));  // Jello
        Console.WriteLine(greeting);  // Hello
        ```
        
- Mutator
    - 객체의 **내부 상태를 직접 변경**
        
        ```csharp
        var box = new Rectangle(5, 10, 60, 40);
        
        Console.WriteLine(box.X);  // 5
        Console.WriteLine(box.Width);  // 60
        
        box.Offset(25, 40);
        
        Console.WriteLine(box.X);  //30
        Console.WriteLine(box.Width);  // 60
        ```
        
- String 복사하기
    
    ```csharp
    string greeting1 = "Hello, World!";
    string greeting2 = greeting1;
    
    greeting2.ToUpper();


    // 기대값(Accessor: 원본 불변, 반환값을 저장하지 않아 변화 없음)    
    greeting1 = ?  // "Hello, World!"
    greeting2 = ?  // "Hello, World!"
    ```
    
    - `ToUpper()`은 **mutator가 아니라 accessor**
        
        → 원래 문자열을 바꾸지 않고, `"HELLO, WORLD!"`라는 **새 문자열 객체** 반환
        
    - 하지만 여기서 반환값을 변수에 담지 않아, 아무도 `"HELLO, WORLD!"` 객체를 참조하지 않음 ⇒ 그대로 버려짐
    - 따라서 `greeting1`과 `greeting2`는 여전히 `"Hello, World!"`를 가리킴.
- Number 복사
    
    ```csharp
    int luckyNumber1 = 13;
    int luckyNumber2 = luckyNumber1;
    
    luckyNumber2 = 12;
    
    luckyNumber1 = ?  // 13
    luckyNumber2 = ?  // 12
    ```
    
    - `int`는 **값 타입**이라서 대입할 때 **값 자체가 복사**
        
        → 서로 독립적인 저장 공간에 존재
        
        ⇒ 바꿔도 다른 쪽에 영향 없음.
