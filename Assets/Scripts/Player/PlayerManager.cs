using UnityEngine;

public class PlayerManager : MonoBehaviour, IListener
{
    [SerializeField] private DamageHandler damageHandler;
    [SerializeField] private TargetHandler targetHandler;
    [SerializeField] private WeaponManager weaponManager;

    private void Update()
    {
        var weaponRadius = weaponManager.RadiusToAttack;
        Utils.FindTarget(targetHandler, transform, weaponRadius, "Enemy");
    }

    public void Start()
    {
        AddAllListeners();
    }

    public void AddAllListeners()
    {
        Health.OnOwnerDead += OnDead;
    }

    public void RemoveAllListeners()
    {
        Health.OnOwnerDead -= OnDead;
    }
    
    private void OnDead(GameObject owner)
    {
        if (owner == gameObject)
        {
            Destroy(gameObject);
        }
    }
    
    public void OnDestroy()
    {
        RemoveAllListeners();
    }
}
