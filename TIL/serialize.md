# 📚 Today I Learned - C# 데이터 형식 변환

**날짜**: 2025년 9월 2일  
**주제**: C# Object ↔ CSV, Object ↔ JSON 변환  
**키워드**: `System.Text.Json`, `CsvHelper`, 직렬화, 역직렬화

---

## 🎯 학습 목표

C#에서 객체 데이터를 다른 형식으로 변환하는 방법을 익히기
- Object → CSV → Object 변환
- Object → JSON → Object 변환

---

## 💡 핵심 개념

### 직렬화(Serialization)
- **정의**: 메모리 상의 객체를 저장/전송 가능한 형태로 변환
- **용도**: 데이터 저장, 네트워크 전송, API 통신

### 역직렬화(Deserialization)  
- **정의**: 저장된 데이터를 다시 객체로 복원
- **용도**: 데이터 복구, 파일 읽기, API 응답 처리

---

## 🔧 사용 도구 및 라이브러리

### CSV 변환
```csharp
// NuGet 패키지 설치 필요
dotnet add package CsvHelper
```
- **CsvHelper**: CSV 파일 읽기/쓰기 전용 라이브러리
- **장점**: 타입 안전성, 자동 헤더 생성, 유연한 설정

### JSON 변환
```csharp
using System.Text.Json; // .NET Core 기본 포함
```
- **System.Text.Json**: .NET Core/5+ 기본 내장
- **장점**: 빠른 성능, 메모리 효율적, 네이티브 지원

---

## 📝 실습 코드 정리

### 데이터 모델 클래스

```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
}
```

### CSV 변환 메서드

```csharp
// Object → CSV
public static void ObjectToCsv<T>(List<T> objects, string filePath)
{
    using var writer = new StringWriter();
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    csv.WriteRecords(objects);
    File.WriteAllText(filePath, writer.ToString());
}

// CSV → Object
public static List<T> CsvToObject<T>(string filePath)
{
    using var reader = new StringReader(File.ReadAllText(filePath));
    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
    return csv.GetRecords<T>().ToList();
}
```

### JSON 변환 메서드

```csharp
// Object → JSON
public static void ObjectToJson<T>(T obj, string filePath)
{
    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    string jsonString = JsonSerializer.Serialize(obj, options);
    File.WriteAllText(filePath, jsonString);
}

// JSON → Object
public static T JsonToObject<T>(string filePath)
{
    string jsonString = File.ReadAllText(filePath);
    var options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    return JsonSerializer.Deserialize<T>(jsonString, options);
}
```

---

## ✨ 주요 학습 내용

### 1. 제네릭 메서드 활용
- `<T>` 를 사용해 어떤 타입이든 변환 가능
- 코드 재사용성과 타입 안전성 확보

### 2. JSON 직렬화 옵션
- `WriteIndented`: 가독성 좋은 포맷팅
- `PropertyNamingPolicy.CamelCase`: 웹 표준 명명 규칙

### 3. 에러 처리
- `FileNotFoundException` 처리
- `using` 문을 통한 리소스 관리

### 4. 데이터 검증
- `SequenceEqual()` 로 변환 전후 데이터 일치 확인
- `Equals()`, `GetHashCode()` 오버라이드

---

## 🚀 실무 적용 사례

### CSV 활용
- 엑셀 데이터 가져오기/내보내기
- 대용량 데이터 배치 처리
- 레거시 시스템 연동

### JSON 활용  
- REST API 통신
- 설정 파일 관리
- NoSQL 데이터베이스 연동
- 캐싱 데이터 저장

---

## ⚠️ 주의사항 및 팁

### CSV 처리 시
- 한글/특수문자: `CultureInfo.InvariantCulture` 사용
- 날짜 형식: DateTime 타입 자동 변환 지원
- 대용량 파일: 메모리 사용량 고려

### JSON 처리 시
- 속성명 매칭: `PropertyNamingPolicy` 설정 중요
- 날짜 형식: ISO 8601 표준 사용
- null 처리: nullable 타입 활용

### 성능 최적화
- 대용량 데이터: Stream 기반 처리 고려
- 반복 처리: JsonSerializerOptions 재사용
- 메모리: `using` 문으로 리소스 정리


---

## 📚 참고 자료

- [System.Text.Json 공식 문서](https://docs.microsoft.com/en-us/dotnet/api/system.text.json)
- [CsvHelper 공식 문서](https://joshclose.github.io/CsvHelper/)
- [C# 직렬화 가이드](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/)

---

## 🎉 마무리

오늘은 C#에서 객체 데이터를 CSV와 JSON 형식으로 변환하는 방법을 학습했다. 특히 제네릭 메서드를 활용한 재사용 가능한 코드 작성과, 실무에서 바로 활용할 수 있는 에러 처리 방법을 익혔다. 

다음에는 **XML 직렬화**와 **비동기 파일 처리**를 추가로 학습해보자! 💪