using UnityEngine;
using UnityEngine.UI;

public class DelegatesExample : MonoBehaviour
{
    public delegate void Notify(string message);
    private Notify OnComplete;

    public delegate void ButtonClick(string message);
    public event ButtonClick OnClick;

    private Button button;

    private void Start()
    {
        OnComplete = PrintOnComplete;

        OnComplete?.Invoke("Notified on complete");

        OnClick += PrintOnClick;
    }

    private void Click()
    {
        OnClick?.Invoke("Print on button click");
    }

    private void PrintOnClick(string message)
    {
        Debug.Log(message);
    }

    private void PrintOnComplete(string message)
    {
        Debug.Log(message);
    }
}