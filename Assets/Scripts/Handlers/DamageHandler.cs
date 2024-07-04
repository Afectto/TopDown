using System;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    private GameObject _owner;
    public static Action<GameObject, float> OnDamageTaken;

    private void Awake()
    {
        _owner = gameObject;
    }

    public void SetDamage(float damage)
    {
        OnDamageTaken?.Invoke(_owner, damage);
    }
}
