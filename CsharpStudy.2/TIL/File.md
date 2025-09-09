### 파일 조작

- 파일 조작의 기본 순서
    1. 파일을 연다.
    2. 파일을 읽거나 쓴다.
        
        ```csharp
        string text = "안녕 홍길동\n";
        System.IO.File.WriteAllText("test.txt", text);  // 알아서 열고 닫아줌
        
        System.IO.File.AppendAllText("test.txt", text);  // 뒤에 추가
        ```
        
        ```csharp
        text = System.IO.File.ReadAllText("test.txt");
        Console.WriteLine(text);
        
        string[] lines = System.IO.File.ReadAllLines("test.txt");
        lines.ToList().ForEach(Console.WriteLine);
        ```
        
    3. 파일을 닫는다.