using System;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private GameObject owner;

    public static Action<GameObject, float> OnDamageTaken;

    public void SetDamage(float damage)
    {
        OnDamageTaken?.Invoke(owner, damage);
    }
}
