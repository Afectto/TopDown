using System.Collections;
using UnityEngine;

public class WeaponManager : AbstractTargetHandler
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRite;
    [SerializeField] private float radiusToAttack;
    [SerializeField] private Transform shootElement;
    [SerializeField] private BulletManager bulletPrefab;

    public float RadiusToAttack => radiusToAttack;
    private bool _isCanShoot;

    public override void Start()
    {
        base.Start();
        _isCanShoot = true;
    }

    private void Update()
    {
        ShootIfNeeded();
    }

    private void ShootIfNeeded()
    {
        if (_isCanShoot && _target != null )
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        _isCanShoot = false;
        var bullet = Instantiate(bulletPrefab, shootElement.position, Quaternion.identity);
        bullet.SetDamage(damage);
        bullet.GetComponent<MoveToTargetAndDestroy>().SetTarget(_target);
        yield return new WaitForSeconds(attackRite);
        _isCanShoot = true;
    }
}
