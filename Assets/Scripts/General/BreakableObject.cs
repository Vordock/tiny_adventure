using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject objectToDrop;

    void OnDisable()
    {
        if (objectToDrop)
        {
            //drop object
        }
    }
}
