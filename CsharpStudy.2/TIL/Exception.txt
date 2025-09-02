### 예외

: 프로그램을 설계할 때 실행 시 예외 상황이 발생할 가능성이 있는 것을 예측하여

사전에 예외 처리가 되도록 할 필요가 있음

∵ 적절한 조치가 없을 시 프로그램 에러 나며 죽음

→ 예상 외의 상황에 적절한 조치를 취함

- 종류와 대응책
    - 문법 에러 (syntax error)
    - 실행 시 에러 (runtime error)
    - 논리 에러 (logic error)
    
    |  | syntax error | runtime error | logic error |
    | --- | --- | --- | --- |
    | 원인 | 코드의 형식적 오류 | 실행 중에 예상 외의 사태가 발생하여 동작이 중지 됨 | 기술한 처리 내용에 논리적인 오류가 있음 |
    | 알아채는 법 | 컴파일 하면 에러 | 실행하면 도중에 강제로 종료 | 실행하면 예상 외의 값이 나옴 |
    | 해결 방법 | 컴파일러의 지적을 보고 수정 | 에러 | 원인을 스스로 찾아서 해결해야 함 |
    |  |  |  |  |
- 예외적인 상황들
    - 메모리 부족
    - 파일을 찾을 수 없음
    - 네트워크 통신 불가 등
- 예외 처리의 흐름
    
    ```csharp
    try
    {
    	// 에러가 날 수 있는 코드 작성
    }
    catch (Exception e)
    {
    	// 예외가 발생했을 때 실행되는 코드
    	// 'e'는 발생한 에러에 대한 정보를 담고 있는 객체
    }
    ```
    
    - 예외를 발생
        - 다양한 Exception이 준비되어 있음
    - `try-catch` 문으로 exception 계열 예외를 처리
        
        ```csharp
        static void Main2(string[] args)
        {
            try
            {
                SomeError();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        static void SomeError()
        {
            throw new ArgumentException("에러 발생 !");
        }
        ```
        
    - `throw` 로 에러 처리를 미룸
        
        ```csharp
        static void Main2(string[] args)
        {
            try
            {
                SomeError2();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        
            Console.WriteLine("Hello World");
        }
        
        static void SomeError2()
        {
            try
            {
                SomeError();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;  // 에러 처리를 미룸
            }
            
        }
        
        static void SomeError()
        {
            throw new ArgumentException("에러 발생 1");
        }
        ```
        
    - `finally` : 항상 해야 하는 처리
        
        ```csharp
            try
            {
                SomeError();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("무조건 실행되는 코드");
            }
        ```
        
    - 오리지날 예외 클래스 정의
        
        ```csharp
        public class InventoryFullException : Exception
        {
            public InventoryFullException() : base("인벤토리가 가득 찼습니다.")
            {
                
            }
        }
        ```
