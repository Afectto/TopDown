using System;
using System.Collections;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private float pickupRadius;
    [SerializeField] private SpriteRenderer skin;
    
    private string _name;
    
    private Coroutine _routine;
    
    public string Name => _name;
    
    public static Action<GameObject> OnPickupItemByPlayer;

    private void Start()
    {
        _routine = StartCoroutine(CheckPlayerInRadius());
    }

    private IEnumerator CheckPlayerInRadius()
    {
        while (true)
        {
            var target = Utils.FindTarget(transform, pickupRadius, "Player");
            if (target)
            {
                OnPickupItemByPlayer?.Invoke(gameObject);
                StopRoutine();
            }
            yield return new WaitForSeconds(0.1f);
        }
        // ReSharper disable once IteratorNeverReturns
    }

    public void SetName(string pickupName)
    {
        _name = pickupName;
    }
    
    public void SetSkin(Sprite sprite)
    {
        skin.sprite = sprite;
    }

    private void StopRoutine()
    {
        if (_routine != null)
        {
            StopCoroutine(_routine);
        }
        Destroy(gameObject);
    }
}

