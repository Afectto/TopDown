using UnityEngine;

public class BulletManager : MonoBehaviour, IListener
{
    [SerializeField] private MoveToTargetAndDestroy moveToTarget;
    
    private float _damage;

    public void Start()
    {
        AddAllListeners();
    }
    
    public void AddAllListeners()
    {
        MoveToTargetAndDestroy.OnObjectInTarget += ApplyDamageToTarget;
    }

    public void RemoveAllListeners()
    {
        MoveToTargetAndDestroy.OnObjectInTarget -= ApplyDamageToTarget;
    }

    private void ApplyDamageToTarget(Transform target)
    {
        var damageHandlerTarget = target.GetComponent<DamageHandler>();
        if (damageHandlerTarget)
        {
            damageHandlerTarget.SetDamage(_damage);
        }
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    private void FixedUpdate()
    {
        moveToTarget.MoveObjectToTarget();
    }

    public void OnDestroy()
    {
        RemoveAllListeners();
    }

}
