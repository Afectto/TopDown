using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private DamageHandler damageHandler;
    [SerializeField] private TargetHandler targetHandler;
    [SerializeField] private WeaponManager weaponManager;

    private void Update()
    {
        var weaponRadius = weaponManager.RadiusToAttack;
        Utils.FindTarget(targetHandler, transform, weaponRadius, "Enemy");
    }
}
