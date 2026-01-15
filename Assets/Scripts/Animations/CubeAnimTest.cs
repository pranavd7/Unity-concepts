using UnityEditor.Animations;
using UnityEngine;

public class CubeAnimTest : MonoBehaviour
{
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Space");
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("F");
        }
    }
}
