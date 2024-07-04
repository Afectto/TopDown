using System;
using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    private GameObject _owner;

    public static Action<GameObject, Transform> OnSetTarget;

    private void Awake()
    {
        _owner = gameObject;
    }

    public void SetTarget(Transform target)
    {
        OnSetTarget?.Invoke(_owner, target);
    }
}
