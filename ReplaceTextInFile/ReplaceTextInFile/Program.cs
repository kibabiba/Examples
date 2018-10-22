using System.IO;

namespace ReplaceTextInFile
{
    static class Program
    {
        static void Main(string[] args)
        {
            ReplaceTextInFile(args[0], args[1], args[2], args[3]);
        }

        private static void ReplaceTextInFile(string originalFile, string outputFile, string searchTerm, string replaceTerm)
        {
            using (FileStream inputStream = File.OpenRead(originalFile))
            {
                using (var inputReader = new StreamReader(inputStream))
                {
                    using (StreamWriter outputWriter = File.AppendText(outputFile))
                    {
                        string tempLineValue;
                        while (null != (tempLineValue = inputReader.ReadLine()))
                        {
                            outputWriter.WriteLine(tempLineValue.Replace(searchTerm, replaceTerm));
                        }
                    }
                }
            }
        }
    }
}
