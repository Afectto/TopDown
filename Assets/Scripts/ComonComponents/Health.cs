using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IListener
{
    [SerializeField] private GameObject owner;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Image fillHealthBar;
    private float _currentHealth;
    private bool isAlreadyDie;

    public static Action<GameObject> OnOwnerDead;

    public void Start()
    {
        _currentHealth = maxHealth;
        isAlreadyDie = false;
        AddAllListeners();
    }

    public void AddAllListeners()
    {
        DamageHandler.OnDamageTaken += OnDamageTaken;
    }

    public void RemoveAllListeners()
    {
        // ReSharper disable once DelegateSubtraction
        DamageHandler.OnDamageTaken -= OnDamageTaken;
    }

    private void OnDamageTaken(GameObject thisOwner, float damage)
    {
        if (owner == thisOwner)
        {
            Damage(damage);
        }
    }

    private void Damage(float damage)
    {
        if(damage <= 0 ) return;
        
        _currentHealth -= damage;

        if (!isAlreadyDie && _currentHealth <= 0)
        {
            isAlreadyDie = true;
            _currentHealth = 0;
            Debug.Log("DEAD");
            OnOwnerDead?.Invoke(owner);
        }

        UpdateHealthLine();
    }
    
    private void UpdateHealthLine()
    {
        fillHealthBar.fillAmount = _currentHealth / maxHealth;
    }

    public void OnDestroy()
    {
        RemoveAllListeners();
    }
}
