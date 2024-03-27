using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IListener
{
    public void Start()
    {
        AddAllListeners();
    }

    private void OnDead(GameObject owner)
    {
        Destroy(gameObject);
    }

    public void AddAllListeners()
    {
        Health.OnOwnerDead += OnDead;
    }

    public void RemoveAllListeners()
    {
        Health.OnOwnerDead -= OnDead;
    }

    public void OnDestroy()
    {
        RemoveAllListeners();
    }
}
