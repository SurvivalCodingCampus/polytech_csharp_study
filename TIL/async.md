# C# 비동기 프로그래밍 TIL

## 동기 vs 비동기의 성능 차이

**핵심 깨달음**: 동기 방식으로 4개의 작업을 순차적으로 실행하면 28초가 걸리지만, 비동기 방식으로 병렬 처리하면 10초로 단축된다.

### 동기(Synchronous) 프로그래밍
- 코드가 순서대로 실행됨
- 작업이 완료될 때까지 프로그램이 중단됨
- 모든 작업은 이전 작업의 완료를 기다려야 함
- **비유**: 1차선 도로에서 느린 차가 끼어들면 전체가 느려짐

### 비동기(Asynchronous) 프로그래밍
- 작업 완료를 기다리지 않고 다른 작업을 시작할 수 있음
- **핵심**: 메인 스레드를 절대 막지 않음
- 사용자 경험 향상: 다운로드 중에도 버튼 클릭, 스크롤 조작 가능

## 동시성 vs 병렬성

### 동시성(Concurrency)
- 여러 작업이 **논리적으로** 동시에 실행되는 것처럼 보임 (싱글 코어)
- 시분할 방식으로 여러 스레드를 번갈아가며 실행
- **비유**: 선생님 한 명이 질문도 받고, 숙제도 체크하고, 수업 준비도 함

### 병렬성(Parallelism)
- 여러 작업이 **물리적으로** 동시에 실행됨 (멀티 코어)
- 멀티코어 환경에서 실제로 여러 스레드가 병렬로 실행
- **비유**: 선생님과 조교가 함께 일하는 것

## 콜백의 문제점과 해결책

### 콜백 방식의 문제점
1. **콜백 지옥**: 코드의 깊이가 깊어져 관리가 어려움
2. **디버깅 어려움**: 에러 추적이 힘듦
3. **가독성 저하**: 코드 흐름을 따라가기 어려움
4. **예외 처리**: try-catch 사용 불가

```csharp
// 콜백 지옥 예시
Task.Delay(3000).ContinueWith(task =>
{
    string data = "데이터";
    onSuccess?.Invoke(data);
});
```

### async/await의 장점
1. **콜백 지옥 해결**: 동기 코드처럼 순차적으로 작성 가능
2. **예외 처리 간편**: try-catch 블록 사용 가능
3. **가독성 향상**: 코드 흐름을 쉽게 파악 가능

```csharp
public async Task<string> GetDataAsync()
{
    try
    {
        Console.WriteLine("데이터를 가져오는 작업 시작...");
        var data = await _getDataFromAPI();
        Console.WriteLine("데이터 가져오기 성공!");
        return data;
    }
    catch (Exception error)
    {
        Console.WriteLine($"에러 발생: {error.Message}");
        return string.Empty;
    }
}
```

## Task 클래스 주요 메서드들

### 1. Task.Delay()
```csharp
await Task.Delay(1000); // 1초 대기
```
- 비동기적으로 지정된 시간만큼 대기
- Thread.Sleep()과 달리 스레드를 블록하지 않음

### 2. Task.WhenAll()
```csharp
var tasks = new List<Task<int>>
{
    GetInt1(), GetInt2(), GetInt3(), GetInt4(), GetInt5()
};
int[] results = await Task.WhenAll(tasks);
```
- 모든 작업을 **동시에** 시작하여 병렬 처리
- 모든 작업이 완료될 때까지 대기
- 성능을 극한으로 올릴 수 있는 방법

### 3. Task.WhenAny()
```csharp
var completedTask = await Task.WhenAny(tasks);
var result = await completedTask;
```
- 여러 작업 중 **가장 먼저** 완료되는 작업을 기다림
- 타임아웃 처리나 다중 소스에서 데이터 가져올 때 유용

### 4. Task.Run()
```csharp
var result = await Task.Run(() => {
    // CPU 집약적인 작업
    return HeavyComputation();
});
```
- CPU 집약적인 작업을 백그라운드 스레드에서 실행
- 메인 스레드를 블록하지 않음

### 5. Task.FromResult()
```csharp
public async Task<string> GetCachedDataAsync(string key)
{
    if (cache.ContainsKey(key))
        return Task.FromResult(cache[key]); // 동기 값을 Task로 래핑
    
    return await FetchFromServerAsync(key);
}
```
- 이미 계산된 값을 Task로 래핑할 때 사용

### 6. Task.CompletedTask
```csharp
public async Task ProcessAsync()
{
    if (condition)
        return Task.CompletedTask; // 즉시 완료된 Task 반환
    
    await DoActualWorkAsync();
}
```
- 즉시 완료된 Task를 반환할 때 사용

### 7. ConfigureAwait()
```csharp
var result = await SomeMethodAsync().ConfigureAwait(false);
```
- 컨텍스트 캡처 여부를 제어
- 라이브러리 코드에서 성능 최적화에 사용

## 실전 성능 비교

### 순차 실행 (5초)
```csharp
public static async Task PrintInts()
{
    List<int> results = new List<int>();
    results.Add(await GetInt1()); // 1초
    results.Add(await GetInt2()); // 1초
    results.Add(await GetInt3()); // 1초
    results.Add(await GetInt4()); // 1초
    results.Add(await GetInt5()); // 1초
    // 총 5초
}
```

### 병렬 실행 (1초)
```csharp
public static async Task PrintParallelInts()
{
    var tasks = new List<Task<int>>
    {
        GetInt1(), GetInt2(), GetInt3(), GetInt4(), GetInt5()
    };
    int[] results = await Task.WhenAll(tasks);
    // 모든 작업이 동시에 실행되므로 1초
}
```

## Unity에서의 비동기 처리

Unity에서는 **UniTask**를 주로 사용하여 코루틴을 완벽히 대체한다:
- 더 나은 성능
- async/await 패턴 지원
- 가비지 컬렉션 최적화
- Unity 생명주기와 완벽한 통합

## 마무리 정리

1. **동기 코드는 앱을 멈추게 할 수 있다**
2. **콜백은 '콜백 지옥'을 만들 수 있다**
3. **async/await는 깔끔하고 읽기 쉬운 코드를 제공한다**
4. **Task.WhenAll은 진정한 병렬성을 구현한다**
5. **예외 처리는 try-catch로 간단하게 처리 가능하다**

비동기 프로그래밍은 동시성과 병렬성 개념을 영리하게 사용해서 성능을 최대한 끌어내는 핵심 기술이다.

---

**참고 자료**: [Microsoft C# 비동기 프로그래밍 가이드](https://learn.microsoft.com/ko-kr/dotnet/csharp/asynchronous-programming/)