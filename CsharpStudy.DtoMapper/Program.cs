namespace CsharpStudy.DtoMapper;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var person1 = new Person("홍길동", 10);
        var person2 = new Person("홍길동", 10);
        Console.WriteLine(person1.Equals(person2));  // false
        Console.WriteLine(person2.ToString());
        
        Animal animal = new Dog();

        switch (animal)
        {
            case Dog dog:
                Console.WriteLine(dog.ToString());
                break;
            case Cat cat:
                Console.WriteLine(cat.ToString());
                break;
            default:
                break;
        }
    }
}

// 아래꺼와 동일
record Person(string Name, int Age);

public class Animal
{
        
}

public sealed class Dog : Animal
{
    
}

public sealed class Cat : Animal
{
    
}



// class Person
// {
//     public string Name { get; }
//     public int Age { get; }
//
//     public Person(string name, int age)
//     {
//         Name = name;
//         Age = age;
//     }
//
//     protected bool Equals(Person other)
//     {
//         return Name == other.Name && Age == other.Age;
//     }
//
//     public override bool Equals(object? obj)
//     {
//         if (obj is null) return false;
//         if (ReferenceEquals(this, obj)) return true;
//         if (obj.GetType() != GetType()) return false;
//         return Equals((Person)obj);
//     }
//
//     public override int GetHashCode()
//     {
//         return HashCode.Combine(Name, Age);
//     }
//     
//     public override string ToString()
//     {
//         return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
//     }
// }