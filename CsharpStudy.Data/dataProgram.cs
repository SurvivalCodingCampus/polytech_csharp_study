using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CsharpStudy.Data;

class dataProgram
{
    static void Main(string[] args)
    {
        dataProgram.Emplovee emplovee = new dataProgram.Emplovee("홍길동", 49);
        dataProgram.Department department = new dataProgram.Department("홍길동", emplovee);
        
        string jsonString = JsonConvert.SerializeObject(department);

        File.WriteAllText("jsonString.json",jsonString);
    }
    
    public class Emplovee
    {
        public string Name{get;}
        public int Age{get;}

        public Emplovee(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Department
    {
        public string Name{get;}
        public Emplovee Leader{get;}

        public Department(string name, Emplovee leader)
        {
            Name = name;
            this.Leader = leader;
        }
    }


}