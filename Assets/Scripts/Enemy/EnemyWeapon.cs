using System.Collections;
using UnityEngine;

public class EnemyWeapon : AbstractTargetHandler
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRite;

    private DamageHandler _damageHandler;
    private bool _isCanShoot;
    
    public float Damage => damage;
    public float AttackRange => attackRange;

    public override void Start()
    {
        base.Start();
        _isCanShoot = true;
    }

    private void Update()
    {
        if(!_target) return;
        
        _damageHandler = _target.GetComponent<DamageHandler>();
        AttackIfCan();
    }

    private void AttackIfCan()
    {
        var distance = Vector3.Distance(transform.position, _target.position);
        if (_isCanShoot && distance <= attackRange)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        _isCanShoot = false;
        _damageHandler.SetDamage(damage);
        yield return new WaitForSeconds(attackRite);
        _isCanShoot = true;
    }
}
