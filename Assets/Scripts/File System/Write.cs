using System;
using System.IO;

class FileWriteeEcample
{
    static void Main()
    {
        string path = "example.txt";
        string content = "Hello, this is a test file.";

        // Write entire content to file.
        File.WriteAllText(path, content);

        // Write multiple lines.
        string[] lines = { "Line 1", "Line 2", "Line 3" };
        File.WriteAllLines(path, lines);

        // Append text to end of file.
        File.AppendAllText(path, "\nAppended line at " + DateTime.Now);

        StreamWriter writer = null;
        try
        {
            writer = new StreamWriter(path);
            writer.WriteLine("Hello, world.");
            writer.WriteLine("Writing more lines...");
        }
        finally
        {
            if (writer != null)
            {
                // Close the underlying stream manually.
                writer.Close();
            }
        }

        // Best practice - Automatically handle closing the file.
        // Create or overwrite the file.
        using (writer = new StreamWriter(path))
        {
            writer.WriteLine("Hello, world!");
            writer.WriteLine("Writing more lines...");
        } // file is closed automatically here.
    }
}
