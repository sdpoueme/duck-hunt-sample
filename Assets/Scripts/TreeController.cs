using UnityEngine;
using UnityEngine.Events;

public class Tree: MonoBehaviour
{
    public UnityEvent OnDuckFallingOnTree; 

    public void triggerEvent()
    {
        OnDuckFallingOnTree.Invoke();
    }


}