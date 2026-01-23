using System;
using System.IO;

class FileReadExample
{
    static void Main()
    {
        string path = "example.txt";

        // Read full file.
        string content = File.ReadAllText(path);
        Console.WriteLine("Content:\n" + content);

        // Read line by line.
        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            Console.WriteLine("Line: " + line);
        }

        // Using StreamReader read line by line
        StreamReader reader = null;
        try
        {
            reader = new StreamReader(path);
            // Your code to read from the file using 'reader'
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine("Read via StreamReader: " + line);
            }
        }
        catch (FileNotFoundException)
        {
            
        }
        finally
        {
            if (reader != null)
            {
                // Close the underlying stream.
                reader.Close();
            }
        }

        // Best practice - Automatically handle closing the file.
        using (reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine("Read via StreamReader: " + line);
            }
        } // file is closed automatically here.
    }
}
