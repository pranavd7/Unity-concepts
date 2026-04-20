using UnityEngine;

public class TestManager2
{
    private static TestManager2 instance;

    public static TestManager2 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TestManager2();
            }

            return instance;
        }
    }
    
    public void TestMethod()
    {
        Debug.Log("TestMethod");
    }

    public float CalculateMath(Vector3 start, Vector3 end)
    {
        float res = Vector3.Distance(start, end);
        return res;
    }
}