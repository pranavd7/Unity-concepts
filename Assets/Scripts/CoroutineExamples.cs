using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
    
    int maxBullets = 10;
    int bullets = 10;
    
    void Start()
    {
        Coroutine co = StartCoroutine(OuterCoroutine());
        
        // StopAllCoroutines();
    }

    IEnumerator PrintMessage()
    {
        Debug.Log("Start");

        // Wait 2 seconds.
        yield return new WaitForSeconds(2f); 

        Debug.Log("2 seconds later...");
    }

    private IEnumerator MoveOverTime(Transform obj, Vector3 target, float duration)
    {
        Vector3 start = obj.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null; // continue next frame
        }

        obj.position = target;
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            Debug.Log("Bullet fired!");
            bullets--;
            // Fire every 1s.
            yield return new WaitForSeconds(1f);
            if (bullets == 0)
            {
                yield return Reload();
            }
        }
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading bullets");
        
        yield return new WaitForSeconds(2f);
        bullets = maxBullets;
    }

    IEnumerator InnerCoroutine()
    {
        Debug.Log("Inner start");
        yield return new WaitForSeconds(2f);
        Debug.Log("Inner end");
    }

    IEnumerator OuterCoroutine()
    {
        Debug.Log("Outer start");
        yield return StartCoroutine(InnerCoroutine());
        Debug.Log("Outer after inner");
    }

    // Outer start
    // Inner start
    // (wait 2 sec)
    // Inner end
    // Outer after inner

    IEnumerator OuterCoroutine2()
    {
        Debug.Log("Outer start");
        StartCoroutine(InnerCoroutine()); // run in parallel
        Debug.Log("Outer continues without waiting");
        yield return new WaitForSeconds(1f);
        Debug.Log("Outer end");
    }

    // Outer start
    // Inner start
    // Outer continues without waiting
    // (wait 1 sec)
    // Outer end
    // (wait 1 more sec inside Inner)
    // Inner end


    // yield return null; // wait until next frame.
    // yield return new WaitForSeconds(x); // wait x seconds (affected by Time.timeScale).
    // yield return new WaitForSecondsRealtime(x); // wait x seconds (ignores Time.timeScale).
    // yield return new WaitUntil(condition); // wait until a condition is true.
    // yield return new WaitWhile(condition); // wait while condition is true.
    // yield return new WaitForEndOfFrame(); // wait until the end of the current frame.
}
