using System;
using System.IO;

class FileStreamExample
{
    static void Main()
    {
        string path = "binary.dat";

        // Writing bytes.
        using (FileStream fs = new FileStream(path, FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            writer.Write(42);        // int
            writer.Write(3.14f);     // float
            writer.Write("Hello");   // string
        }

        // Reading bytes.
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int number = reader.ReadInt32();
                float pi = reader.ReadSingle();
                string text = reader.ReadString();

                Console.WriteLine($"Read: {number}, {pi}, {text}");
            }
        }
    }
}
