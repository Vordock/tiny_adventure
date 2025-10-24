using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "TransformEventChannelSO", menuName = "Scriptable Objects/TransformEventChannelSO")]
public class TransformEventChannelSO : ScriptableObject
{
    public UnityAction<Transform> OnEventRaised;

    public void RaiseEvent(Transform target)
    {
        OnEventRaised?.Invoke(target);
    }

}
