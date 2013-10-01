using System;
using System.IO;

namespace BinaryTest
{
    class Program
    {
        static void Main()
        {
            var binaryWriter = new BinaryWriter(File.Open("test.bin", FileMode.OpenOrCreate));
            binaryWriter.Write(10);
            binaryWriter.Write(true);
            binaryWriter.Close();

            var binaryReader = new BinaryReader(File.Open("test.bin", FileMode.Open));

            binaryReader.Read(new byte[2], 0, 2);
            binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);

            Console.WriteLine(binaryReader.ReadInt32());
            Console.WriteLine(binaryReader.ReadBoolean());

            binaryReader.Close();
        }
    }
}
