namespace CsharpStudy.Data;

public class Department
{
    public string Name { get; } // 읽기 전용 프로퍼티 [부서 이름]
    public Employee leader { get; } // 읽기 전용 프로퍼티 [부서 리더]
    
    // 생성자 -> 부서 이름과 리더를 초기화
    public Department(string name, Employee leader)
    {
        Name = name;
        this.leader = leader;
    }
}

// Name, leader -> 읽기 전용 자동 구현 프로퍼티