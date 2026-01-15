using UnityEngine;

public class FileManager : Singleton<FileManager>
{
    public string ReadFile(string path)
    {
        return "";
    }
    
    public void WriteFile(string path, string content)
    {
        // save content to path
    }

    public void PrintMessage()
    {
        Debug.Log("Singleton working!");
    }

    public override void Init()
    {
        // init files
    }
}
