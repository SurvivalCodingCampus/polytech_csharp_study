namespace CshapStudy.SubwayData.Model;

public class Subway
{
    public Subway(int id, string name, string? trainLineNum, string? time)
    {
        this.id = id;
        Name = name;
        TrainLineNum = trainLineNum;
        this.time = time;
    }

    public int id {get; set;}
    public string Name {get; set;}
    public string? TrainLineNum {get; set;}

    public string? time { get; set; }
    
}