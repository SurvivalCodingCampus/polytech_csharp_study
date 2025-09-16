## 네트워크 통신

### 네트워크 기초 이론

- URL을 사용한 고수준 액세스
    - 고수준 : 사람이 이해하기 쉽게 작성된 프로그램 또는 API

---

### JSON 개념

- 서버-클라이언트 통신에서 표준처럼 사용되는 데이터 교환 형식
- 가볍고 사람이 읽기 쉬움
- Map 과 같은 간단한 구조
- 직렬화하여 문자열로 나타내기 쉬움
- 대부분의 언어가 이를 파싱할 수 있기 때문에 상호 운용성은 걱정할 것이 없음

---

### HTTP

- 개념
    - `HyperText Transfer Protocol`
    - 원래 문서 전송용으로 설계된 상태 비저장용 프로토콜
    - 브라우저가 GET 요청으로 웹 서버의 문서를 읽어오는 용도였음
    - 지금은 서버와 클라이언트가 텍스트, 이미지, 동영상 등의 데이터를 주고받을 때 사용하는 프로토콜로 확장됨
    - 웹 상에서 보는 이미지, 영상, 파일과 같은 바이너리 데이터도 HTTP 멀티파트나 Base64 인코딩하여 사용
- **무상태성**
    - 상태 비저장 프로토콜
    - 요청 메시지를 보내기 직전까지 대상 컴퓨터가 응답 가능한지 알 방법 없음
    - Stateless 프로토콜, 즉 상태가 없는 프로토콜이라고 함
    - //TCP는 전송계층의 연결지향(상태 유지) 프로토콜이며, 
    - //HTTP는 그 위 애플리케이션 계층에서 동작하는 무상태 프로토콜임
- HTTP 요청과 응답
    - 일대일로 대응
    - 클라이언트는 항상 자기 자신이 보낸 요청에 대한 응답을 알 수 있어서 로직이 단순해지는 장점
    - 클라이언트는 서버로 HTTP 요청을 보내기 직전까지 실제로 서버가 작동하는지 알 방법이 없는 단점
- HTTP 응답 없음
    - 일정 시간 응답 없을 경우 요청 실패로 간주
    - 실무에서의 HTTP응답 없음
        - 실제로 서버가 제대로 처리를 했어도 응답이 늦게 와서 타임아웃 되는 경우도 있음
            - 안드로이드 10초 이내
            - IOS 60초
    - 예측이 어려운 HTTP 응답 없음
        - 서버가 다른 국가에 있는 경우
        - 클라우드 기반의 서버
        - Mock 서버를 활용한 테스트 필요
- 웹 페이지에 접속시 일어나는 일
    - 브라우저에서 [http://www.google.com](http://www.google.com/) 입력
    - 브라우저가 [http://www.google.com](http://www.google.com/)에 접속
    - 페이지 내용이 HTML 형식으로 송신
    - 브라우저가 HTML을 파싱하여 화면에 출력

### 그 외 통신 프로토콜

- TCP vs UDP
    - `Socket`을 사용한 저수준 액세스
        - 저수준 : 컴퓨터가 이해하기 쉽게 작성된 프로그램 또는 API
        - TCP / UDP 를 추상화한 개발자를 위한 API
        - 프로토콜이 아님 → OSI 7계층에 포함되지 않는다
    - **TCP**
        - 신뢰성 있는 **연결지향성** 앱에서 사용 (이메일, 파일전송, 웹브라우저)
            - //Stateful 프로토콜
            - **연결되면 연결을 끊기 전까지 계속 메시지를 주고 받는 프로토콜**
            - **한쪽에 문제가 생기면 다른 쪽에서 감지 가능**
            - 텍스트가 아닌 바이너리 데이터 전송
            - 패킷 크기가 HTTP에 비해 작음 ⇒ 속도 빠름
            - 각 요청이 소켓 1개 공유 (HTTP는 각 요청이 소켓 1개씩 사용)

              ⇒ 요청을 식별할 식별자가 필요

            - 응답을 알 수 있는 방법이 없기 때문에 타임아웃에 대해 직접 구현해야 함
        - TCP / IP
            - Socket을 사용해서 TCP/IP 통신을 할 수 있음
            - 접속하기 위해 IP 주소와 포트번호가 필요
            - 프로토콜(통신시 사용되는 데이터 형식이나 순서 등) 형식은 RFC 문서에 정해둔 것을 따른다
            - 웹페이지 접속, 메일 전송, 게임 등은 모두 TCP/IP를 통한 통신에 의해 이루어진다.
    - **UDP**
        - 신속한 데이터 전송이나 손실 가능성이 있는 상황에 주로 사용
        - 비연결형 프로토콜
        - 데이터 전달 보장이 안되어 신뢰성 낮음
        - 흐름 제어 없음
        - 단순성
        - 멀티캐스팅 및 브로드캐스팅

[정리]

- TCP는 HTTP보다 빠르지만 개발자가 할 일이 많다
- HTTP는 로직이 간단하지만 TCP보다는 느리다

---

### 요청 메서드 (HTTP)

- 요청의 형태를 정의하는 키워드
- 상황에 맞게 사용하는 것이 관례
    - `GET` : 데이터 요청
        - 일반적으로 웹브라우저가 서버에 웹 페이지를 요청할 때 사용
        - 읽기 요청
        - body를 포함할 수 없음
        - `?`와 `&` 문자를 사용하는 쿼리 파라미터를 추가할 수 있다
    - `POST` : 데이터가 포함된 요청
        - 웹브라우저로 테스트 불가
        - 클라이언트에서 서버로 데이터가 포함된 요청을 보낼 때 사용
        - 로그인, 주문 요청 등
        - 쿼리 파라미터뿐만 아니라 body로 데이터 전송
    - `DELETE` : 삭제
        - 웹 브라우저로 테스트 불가
    - `PUT` : 전부 업데이트
        - 웹 브라우저로 테스트 불가
    - `PATCH` : 일부 업데이트 등
        - 웹 브라우저로 테스트 불가
- HTTP 요청 헤더
    - 요청 정보를 파악하는 데 도움이 되는 다른 여러 정보를 포함할 수 있음
    - 주로 인증, 캐싱, 클라이언트 힌트, 조건, 연결관리, 쿠키, CORS 등에 활용
    - JSON 파일을 주고 받을 때 `Content-Type` 에 `application/json` 으로 명시
    - https://developer.mozilla.org/ko/docs/Web/HTTP/Headers
- 상태 코드
    - 모든 HTTP 응답에는 상태 코드와 상태 메시지가 있음
        - 200 OK
        - 400 Bad Request
        - 404 Not Found
        - 500 Internal Server Error
- 세션과 쿠키
    - HTTP는 상태라는 개념이 존재하지 않기 때문에 세션과 쿠키를 사용해 구분
    - 주로 웹에서 서버는 세션, 클라이언트는 쿠키를 통해 상태 저장
    - 모바일에 없는 개념 : SharedPreference 등으로 구현
- HTTP 통신을 위한 클래스
    - C# : HttpClient
    - 유니티 : UnityWebRequest

---

### RESTful API

- 서버와 클라이언트가 메시지를 주고받을 때 가장 많이 사용하는 통신 규격(암묵적인 룰)
- REST (representational state transfer)
    - 분산 시스템을 위한 소프트웨어 아키텍처의 한 형태
    - RESTful이란 REST 조건을 만족한다는 뜻
    - 요청 주소(URL)과 메서드(GET, POST 등), JSON 규격을 이용하여 API를 정의
    - 오늘날 가장 범용적으로 사용

---

``` csharp
### 모든 posts
GET https://jsonplaceholder.typicode.com/posts

### posts 특정 id
GET https://jsonplaceholder.typicode.com/posts?id=1

### posts 쓰기
POST https://jsonplaceholder.typicode.com/posts
Content-Type: application/json  // 일반인지 json인지 알려줌

{
  "userId": 1,
  "title": "test",
  "body": "test"
}

### posts 삭제
DELETE https://jsonplaceholder.typicode.com/posts/10

### posts 전체수정
PUT https://jsonplaceholder.typicode.com/posts/1
Content-Type: application/json  // 일반인지 json인지 알려줌

{
  "userId": 200,
  "title": "바보",
  "body": "test"
}

### posts 일부수정
PATCH https://jsonplaceholder.typicode.com/posts/1
Content-Type: application/json  // 일반인지 json인지 알려줌

{
  "userId": 200,
  "title": "바보",
  "body": "test"
} 
```