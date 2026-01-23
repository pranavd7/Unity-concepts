using System;
using System.IO;

class DirectoryExample
{
    static void Main()
    {
        string folderPath = "TestFolder";
        string filePath = Path.Combine(folderPath, "data.txt"); // TestFolder/data.txt

        // Create directory if it doesn’t exist.
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        // Create or overwrite file.
        File.WriteAllText(filePath, "Data inside file.");

        // Check existence.
        if (File.Exists(filePath))
            Console.WriteLine("File exists at: " + filePath);

        // Copy file.
        string copyPath = Path.Combine(folderPath, "copy.txt");
        File.Copy(filePath, copyPath, true);

        // Move file.
        string movedPath = Path.Combine(folderPath, "moved.txt");
        File.Move(copyPath, movedPath);

        // Delete file
        File.Delete(movedPath);
        Console.WriteLine("File deleted.");
    }
}
