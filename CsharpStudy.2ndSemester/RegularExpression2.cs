namespace CsharpStudy._2ndSemester;

public class RegularExpression2
{
    String getPath(String path, String filename)
    {
        if (path.EndsWith("\\"))
        {
            string t = path + filename;
        }
        else
        {
            string t = path + "\\" + filename;
        }

        return t;
    }
}