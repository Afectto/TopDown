using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private DamageHandler damageHandler;
    [SerializeField] private TargetHandler targetHandler;
    [SerializeField] private WeaponManager weaponManager;

    private void Update()
    {
        FindTarget();
    }

    private void FindTarget()
    {
        var weaponRadius = weaponManager.RadiusToAttack;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, weaponRadius);
        
        bool isFindEnemy = false;
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                isFindEnemy = true;
                targetHandler.SetTarget(collider.transform);
            }
        }

        if (!isFindEnemy)
        {
            targetHandler.SetTarget(null);
        }
    }
}
