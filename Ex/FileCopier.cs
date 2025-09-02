namespace Ex;

public class FileCopier : IFileCopier
{
    public void Copy(string sourcePath, string destinationPath)
    {
            File.Copy(sourcePath, destinationPath, true);

    }
}
