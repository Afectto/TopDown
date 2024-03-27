using System;
using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    [SerializeField] private GameObject owner;

    public static Action<GameObject, Transform> OnSetTarget;

    public void SetTarget(Transform target)
    {
        OnSetTarget?.Invoke(owner, target);
    }
}
