### 동기 프로그래밍

- 코드가 순서대로 진행
- 작업이 완료될 때까지 프로그램이 중단될 수 없음
    - 이전 작업이 완료될때까지 기다려
    - 오래 쓰는 애가 스레드 점유해서 동기코드는 앱을 멈추게 할 수 있음
- 1차선 도로에서 앞에 느린차가 끼어들면 전체가 느려짐

- 클라이언트 - 서비스 요청자 (데이터 달라고 하는 쪽)
- 서버 - 서비스 제공자 (주는 쪽)
    - 동기 : 달라고 요청하면 줄 때까지 기다려야 됨
- 간단한 파일 쓰기 시 동기 방식으로 쓰기

    ```csharp
    File.WriteAllText("hero.json", jsonString);
    ```

- 대용량 파일 쓰기를 위한 비동기 방식으로 쓰기

    ```csharp
    File.WriteAllText("hero.json", jsonString)
    	.ContinueWith(task => { Console.WriteLine("파일복사 완료")});
    ```


---

### 비동기 프로그래밍 ASync

- 작업 완료를 기다리지 않고 다른 작업을 시작할 수 있게 허용하는 방식
- **: 메인 스레드를 절대 막지 않는다**
    - 느린 애가 있으면 길 하나 더 뚫어 가자
    - 엄청 큰 다운로드 중에 사용자는 버튼을 누르거나 스크롤을 조작할 수 있음
    - 앱이 버벅거리지 않고 즉각적으로 반응할 수 있도록 함
- **여러 작업을 처리하는 방식에 대한 차이**
    - **동시성**
        - 여러 작업이 논리적으로 동시에 실행되는 것처럼 보이는 개념 (싱글코어)
        - 논리적 : 여러 작업을 번갈아가면서 처리
        - 시분할 방식으로 여러 스레드를 활용해 동시성을 구현할 수 있음
            - (선생님 한 명이 질문도 받고, 숙제도 체크하고, 수업 준비도 하고)
    - **병렬성**
        - 여러 작업이 물리적으로 동시에 실행되는 개념 (멀티코어)
        - 물리적 : 여러 작업을 실제로 동시에 처리
        - 멀티코어 환경에서 실제로 여러 스레드가 병렬로 실행
            - (선생님이 조교와 함께 일을 하는 것)
- 스레드 : 하나의 프로그램에 여러 개 존재 가능
- 시간을 나눠써 (동시작업 가능)

---

### 콜백

- 콜백 기준의 동기화 방식의 문제점
    - 코드의 깊이가 깊어지고 관리하기 어려워짐
    - 콜백 지옥
    - 디버깅 및 에러 추적이 어려움
    - 가독성과 유지보수성 급격히 저하
    - 병렬처리의 어려움

    ```csharp
      fun main()
        {
            dofirstTask { result1 ->
                    doSecondTask(result1) {
                    result2->
                        doThirdTask(result2) {
                        result3->
                            doFourthTask(result3) {
                            result4->
                                println("Final result : $result4");
                        }
    
                    }
                }
            } 
        }
    ```

- 콜백 함수 사용 (`delegate` 또는 `event`로 구현)

    ```csharp
        public class AsyncExam()
        {
            public void FetchData(Action<string> onSuccess)
            {
                Console.WriteLine("데이터를 가져오는 작업 시작");
                
                // 실제 비동기 작업 (예 : 네트워크 요청, 파일I/O) 대신 지연을 사용
                Task.Delay(3000).ContinueWith(task =>
                {
                    string data = "데이터";
                    onSuccess?.Invoke(data); // 작업 완료 후 콜백 호출
                });
                Console.WriteLine("데이터 가져오기 작업 비동기적으로 시작됨");
            }
        }
    ```

    - `Task<T>` : 비동기적으로 수행될 작업을 나타내는 객체
    - `ContinueWith()` : Task가 완료된 후 실행될 작업을 지정하는 메서드 (콜백 방식)
- 콜백을 활용한 실행코드 예시 : 예측이 어려움

    ```csharp
        static void Main()
        {
            AsyncExam p = new AsyncExam();
            Console.WriteLine("1. 메인 함수 시작");
            
            p.FetchData(data =>
            {
                Console.WriteLine($"2. 콜백으로 받은 데이터 : {data}");
            });
    
            Console.WriteLine("3. 메인함수 종료(비동기 작업이 백그라운드에서 진행될 수 있음)");
            
            // 비동기 작업이 완료되기 전에 프로그램이 종료되는 것을 방지하기 위해 대기
            // 실제 애플리케이션에서는 적절한 동기화 메커니즘이 필요합니다.
            Console.ReadLine();
        }
    ```

- 문제점 : **콜백지옥 발생 가능**
    - 여러 비동기 작업이 순차적으로 의존성을 가질 때, 콜백 함수들이 중첩되어 코드의 가독성과 유지보수성이 급격히 저하
        - 유니티에서 제공하는 `Coroutine` 도 콜백지옥을 벗어날 수 없음

    ```csharp
        void Start()
        {
            StartCoroutine(DownloadData(data => //첫 번째 콜백
            {
                Debug.Log("데이터 다운로드 완료: " + data);
                StartCoroutine(ProcessImage(data, texture => // 두번째 콜백 (중첩)
                {
                    Debug.Log("이미지 처리 완료: " + texture.name);
    
                    // UI 업데이트 로직 (세 번째 콜백이 될 수도 있음)
                }));
            }));
        }
    ```

- 동시에 여러가지 비동기 코드 실행 ⇒ 예측 불가능한 순서
- `ContinueWith()` 예외 처리

    ```csharp
        public Task<string> GetData()
        {
            Console.WriteLine("GetData: 데이터 가져오기 시도");
            
            // Task CompletionSource를 사용해서 Task<string>를 생성하고
            // 나중에 결과를 설정
            var tcs = new TaskCompletionSource<string>();
    
            _getDataFromAPI()
                .ContinueWith(t =>
                {
                    if (t.IsFaulted) // 예외 발생
                    {
                        // TaskCompletionSource에 예외를 설정하여 호출자에게 전달
                        tcs.SetException(t.Exception.InnerException);
                        Console.WriteLine($"GetData: 데이터를 가져오는 데 실패했습니다. {t.Exception}");
                    }
                    else if (t.IsCompletedSuccessfully) // 성공
                    {
                        // TaskCompletionSource에 결과값을 설정
                        tcs.SetResult(t.Result);
                        Console.WriteLine("GetData: 데이터 가져오기 성공!");
                    }
                    else if (t.IsCanceled) // 취소
                    {
                        tcs.SetCanceled();
                    }
                });
            return tcs.Task;  // TaskCompletionSource가 관리하는 Task를 반환
        }
    ```


---

### `Async - await` 문법

- 비동기 코드를 작성할 때 더 깔끔한 코드 제공
- `await` : 해당 Task가 끝날 때까지 함수 실행을 기다림
- 예측 가능

    ```csharp
        static async Task Main()
        {
            AsyncExam p = new AsyncExam();
            Console.WriteLine("1. 메인함수 시작");
    
            var result = await p.FetchDataAsync();
    
            Console.WriteLine($"2. 콜백으로 받은 데이터: {result}");
            
            Console.WriteLine("3. 메인함수 종료(비동기 작업이 백그라운드에서 진행될 수 있음)");
            
            // 비동기 작업이 완료되기 전에 프로그램이 종료되는 것을 방지하기 위해 대기
            // 실제 애플리케이션에서는 적절한 동기화 메커니즘이 필요
            Console.ReadLine();
            
        }
    
        public class AsyncExam
        {
            public async Task<string> FetchDataAsync()
            {
                Console.WriteLine("데이터를 가져오는 작업 시작");
                
                // 실제 비동기 작업 (예: 네트워크 요정, 파일 I/O) 대신 지연을 사용
                await Task.Delay(3000);
                Console.WriteLine("데이터 가져오기 작업 비동기적으로 시작됨");
                return "데이터";
            }
        }
    ```

    - 예외 처리의 정석

        ```csharp
            public async Task<string> GetData()
            {
                try
                {
                    Console.WriteLine("GetData: 데이터 가져오기 시도");
                    var data = await _getDataFromIPA(); // 비동기 작업 대기
                    Console.WriteLine("GetData: 데이터 가져오기 성공!");
                    return data;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"GetData: 데이터를 가져오는 데 실패: {error.Message}");
                    return string.Empty;
                } 
            }
        
        ```


---

### 병렬성 잠금 해제(성능 극대화하기)

- 병렬처리
    - 동시에 여러가지 일을 진행(실제로
    - ↔ 동시성 : 동시에 하는 **것처럼** 보임)
    - `Task.WhenAll()` : 모든 작업을 동시에 시작하여 성능을 극한으로 올리고 모두 끝날 때까지 기다림
- 새로운 씬으로 전환할 때
    - 데이터 로딩
    - 애니메이션