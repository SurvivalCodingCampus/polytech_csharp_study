namespace FileSystem;

class FileSystemFD : IFileCopier
{
    static void Main(string[] args)
    {
        FileSystemFD fileSystemFd = new FileSystemFD();

        string adress = "Test.txt";
        
        File.WriteAllText(adress, "이건 테스트 코드 입니다");
        string readAdress = File.ReadAllText(adress);
        
        fileSystemFd.Copy(adress, readAdress);
    }

    public void Copy(string sourceFilePath, string destinationFilePath)
    {
        int i = 1;

        do
        {
            i++;
        } while (File.Exists(sourceFilePath + i));
        
        File.WriteAllText(sourceFilePath + i, destinationFilePath);
        
    }
}