
-----

### 람다식(Lambda Expression)과 함수형 프로그래밍(Functional Programming)

[cite\_start]**1급 객체**는 변수에 대입할 수 있는 객체를 말하며, 값, 인스턴스, 그리고 함수가 여기에 포함됩니다[cite: 5]. [cite\_start]C\#은 함수도 1급 객체로 취급하기 때문에 변수에 할당하거나 다른 함수의 매개변수로 전달할 수 있습니다[cite: 8]. [cite\_start]함수형 프로그래밍은 입력이 동일하면 항상 동일한 출력을 보장하는 수학적 함수의 계산으로 자료 처리를 취급하며 [cite: 9, 68][cite\_start], 가변 데이터를 멀리하는 특징을 가집니다[cite: 68].

-----

### 람다식(Lambda Expression)과 델리게이트(Delegate)

[cite\_start]**람다식**은 함수 내용을 즉석에서 정의하여 사용하고 싶을 때 유용한 간결한 함수 표현 방식입니다[cite: 57]. [cite\_start]람다식은 이름이 없는 \*\*익명 함수(Anonymous functions)\*\*의 한 형태로, 메서드와 달리 이름이 중요하지 않다는 특징이 있습니다[cite: 49, 62].

[cite\_start]**델리게이트**(delegate)는 C\#에서 메서드를 참조할 수 있도록 하는 타입 안전한 함수 포인터입니다[cite: 22]. [cite\_start]델리게이트를 사용하면 메서드를 변수처럼 다룰 수 있으며, 람다식은 이러한 델리게이트 타입의 변수에 할당될 수 있습니다[cite: 25].

```csharp
// 델리게이트 정의
public delegate int MyDelegate(int a, int b);

// 델리게이트 변수에 람다식 할당
MyDelegate func = (a, b) => a + b;

Console.WriteLine(func(10, 5)); // 출력: 15
```

-----

### `Action`과 `event` 키워드

C\#에는 미리 정의된 델리게이트 타입인 \*\*`Action`\*\*과 **`Func`** 등이 있습니다. 이 중 \*\*`Action`\*\*은 반환 값이 없는 메서드를 참조하는 델리게이트입니다.

```csharp
// Action을 사용한 람다식 예제
Action<string> printMessage = (message) => Console.WriteLine(message);
printMessage("Hello, world!"); // 출력: Hello, world!
```

**`event`** 키워드는 델리게이트를 특정 클래스의 이벤트로 선언할 때 사용됩니다. 이를 통해 이벤트 핸들러를 등록하고 제거하는 방식에 안전성을 더할 수 있습니다. 람다식을 사용하면 이벤트를 처리할 간단한 핸들러를 코드를 더 간결하게 작성할 수 있습니다.

```csharp
// 이벤트와 람다식을 사용한 예제
public class Button
{
    public event Action OnClick;

    public void Click()
    {
        OnClick?.Invoke();
    }
}

Button myButton = new Button();

// 람다식으로 이벤트 핸들러 등록
myButton.OnClick += () => Console.WriteLine("버튼이 클릭되었습니다.");

myButton.Click(); // 출력: 버튼이 클릭되었습니다.
```

-----

### 고계 함수(Higher-Order Function) 예제

[cite\_start]**고계 함수**는 다른 함수를 매개변수로 받거나 반환하는 함수를 의미합니다[cite: 69]. [cite\_start]C\#의 LINQ는 이러한 고계 함수를 활용한 강력한 데이터 처리 기능을 제공합니다[cite: 71].

-----

### 람다식(Lambda Expression)과 함수형 프로그래밍(Functional Programming)

[cite\_start]**1급 객체**는 변수에 대입할 수 있는 객체를 말하며, 값, 인스턴스, 그리고 함수가 여기에 포함됩니다[cite: 5]. [cite\_start]C\#은 함수도 1급 객체로 취급하기 때문에 변수에 할당하거나 다른 함수의 매개변수로 전달할 수 있습니다[cite: 8]. [cite\_start]함수형 프로그래밍은 입력이 동일하면 항상 동일한 출력을 보장하는 수학적 함수의 계산으로 자료 처리를 취급하며 [cite: 9, 68][cite\_start], 가변 데이터를 멀리하는 특징을 가집니다[cite: 68].

-----

### 람다식(Lambda Expression)과 델리게이트(Delegate)

[cite\_start]**람다식**은 함수 내용을 즉석에서 정의하여 사용하고 싶을 때 유용한 간결한 함수 표현 방식입니다[cite: 57]. [cite\_start]람다식은 이름이 없는 \*\*익명 함수(Anonymous functions)\*\*의 한 형태로, 메서드와 달리 이름이 중요하지 않다는 특징이 있습니다[cite: 49, 62].

[cite\_start]**델리게이트**(delegate)는 C\#에서 메서드를 참조할 수 있도록 하는 타입 안전한 함수 포인터입니다[cite: 22]. [cite\_start]델리게이트를 사용하면 메서드를 변수처럼 다룰 수 있으며, 람다식은 이러한 델리게이트 타입의 변수에 할당될 수 있습니다[cite: 25].

```csharp
// 델리게이트 정의
public delegate int MyDelegate(int a, int b);

// 델리게이트 변수에 람다식 할당
MyDelegate func = (a, b) => a + b;

Console.WriteLine(func(10, 5)); // 출력: 15
```

-----

### `Action`과 `event` 키워드

C\#에는 미리 정의된 델리게이트 타입인 \*\*`Action`\*\*과 **`Func`** 등이 있습니다. 이 중 \*\*`Action`\*\*은 반환 값이 없는 메서드를 참조하는 델리게이트입니다.

```csharp
// Action을 사용한 람다식 예제
Action<string> printMessage = (message) => Console.WriteLine(message);
printMessage("Hello, world!"); // 출력: Hello, world!
```

**`event`** 키워드는 델리게이트를 특정 클래스의 이벤트로 선언할 때 사용됩니다. 이를 통해 이벤트 핸들러를 등록하고 제거하는 방식에 안전성을 더할 수 있습니다. 람다식을 사용하면 이벤트를 처리할 간단한 핸들러를 코드를 더 간결하게 작성할 수 있습니다.

```csharp
// 이벤트와 람다식을 사용한 예제
public class Button
{
    public event Action OnClick;

    public void Click()
    {
        OnClick?.Invoke();
    }
}

Button myButton = new Button();

// 람다식으로 이벤트 핸들러 등록
myButton.OnClick += () => Console.WriteLine("버튼이 클릭되었습니다.");

myButton.Click(); // 출력: 버튼이 클릭되었습니다.
```

-----

### 고계 함수(Higher-Order Function) 예제

[cite\_start]**고계 함수**는 다른 함수를 매개변수로 받거나 반환하는 함수를 의미합니다[cite: 69]. [cite\_start]C\#의 LINQ는 이러한 고계 함수를 활용한 강력한 데이터 처리 기능을 제공합니다[cite: 71].

#### Where 함수

[cite\_start]**Where** 함수는 컬렉션에서 특정 조건을 만족하는 요소들을 필터링합니다[cite: 72].

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

// 짝수만 필터링
var evenNumbers = numbers.Where(n => n % 2 == 0);

foreach (var number in evenNumbers)
{
    Console.WriteLine(number); // 출력: 2, 4, 6
}
```

#### Select 함수

[cite\_start]**Select** 함수는 컬렉션의 각 요소를 새로운 형태로 변환합니다[cite: 73].

```csharp
List<string> words = new List<string> { "apple", "banana", "cherry" };

// 각 단어의 길이를 새로운 컬렉션으로 변환
var wordLengths = words.Select(word => word.Length);

foreach (var length in wordLengths)
{
    Console.WriteLine(length); // 출력: 5, 6, 6
}
```

#### Aggregate 함수

[cite\_start]**Aggregate** 함수는 컬렉션의 요소를 반복적으로 줄여나가며 하나의 결과를 만들어냅니다[cite: 79].

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// 모든 요소의 합을 계산
int sum = numbers.Aggregate(0, (total, next) => total + next);

Console.WriteLine(sum); // 출력: 15
```

#### Any 함수

[cite\_start]**Any** 함수는 컬렉션에 특정 조건을 만족하는 요소가 하나라도 존재하는지 확인하는 데 사용됩니다[cite: 78].

```csharp
List<string> fruits = new List<string> { "apple", "banana", "grape" };

// 'a'로 시작하는 과일이 있는지 확인
bool hasApple = fruits.Any(f => f.StartsWith("a"));

Console.WriteLine(hasApple); // 출력: True
```
#### Where 함수

[cite\_start]**Where** 함수는 컬렉션에서 특정 조건을 만족하는 요소들을 필터링합니다[cite: 72].

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

// 짝수만 필터링
var evenNumbers = numbers.Where(n => n % 2 == 0);

foreach (var number in evenNumbers)
{
    Console.WriteLine(number); // 출력: 2, 4, 6
}
```

#### Select 함수

[cite\_start]**Select** 함수는 컬렉션의 각 요소를 새로운 형태로 변환합니다[cite: 73].

```csharp
List<string> words = new List<string> { "apple", "banana", "cherry" };

// 각 단어의 길이를 새로운 컬렉션으로 변환
var wordLengths = words.Select(word => word.Length);

foreach (var length in wordLengths)
{
    Console.WriteLine(length); // 출력: 5, 6, 6
}
```

#### Aggregate 함수

[cite\_start]**Aggregate** 함수는 컬렉션의 요소를 반복적으로 줄여나가며 하나의 결과를 만들어냅니다[cite: 79].

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// 모든 요소의 합을 계산
int sum = numbers.Aggregate(0, (total, next) => total + next);

Console.WriteLine(sum); // 출력: 15
```

#### Any 함수

[cite\_start]**Any** 함수는 컬렉션에 특정 조건을 만족하는 요소가 하나라도 존재하는지 확인하는 데 사용됩니다[cite: 78].

```csharp
List<string> fruits = new List<string> { "apple", "banana", "grape" };

// 'a'로 시작하는 과일이 있는지 확인
bool hasApple = fruits.Any(f => f.StartsWith("a"));

Console.WriteLine(hasApple); // 출력: True
```