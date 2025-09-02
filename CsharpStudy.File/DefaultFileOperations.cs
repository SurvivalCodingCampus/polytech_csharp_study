using System;
using System.IO;

namespace CsharpStudy.File
{
    public interface IFileCopier
    {
        void CopyFile(string sourceFilePath, string destinationFilePath);
    }

    // DefaultFileOperations 클래스에서 인터페이스 구현
    public class DefaultFileOperations : IFileCopier
    {
        public void CopyFile(string sourceFilePath, string destinationFilePath)
        {
            try
            {
                string text = System.IO.File.ReadAllText(sourceFilePath);
                System.IO.File.WriteAllText(destinationFilePath, text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}