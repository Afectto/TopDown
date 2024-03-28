using UnityEngine;

public class EnemyManager : MonoBehaviour, IListener
{
    [SerializeField] private float followingRange;
    [SerializeField] private MovingToTarget enemyMoving;
    [SerializeField] private TargetHandler targetHandler;
    [SerializeField] private GameObject skin;
    [SerializeField] private EnemyWeapon enemyWeapon;
    
    private Vector3 _originalPlayerScale;
    
    public void Start()
    {
        AddAllListeners();
        _originalPlayerScale = skin.transform.localScale;
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

    private void Update()
    {
        MoveIfNeed();
    }

    private void MoveIfNeed()
    {
        var target = Utils.FindTarget(targetHandler, transform, followingRange, "Player");
        if (!target) return;
        
        Flip(target);
        
        var distance = Vector3.Distance(transform.position, target.position);
        if (distance > enemyWeapon.AttackRange)
        {
            enemyMoving.Move();
        }
    }
    
    private void Flip(Transform target)
    {
        if (target)
        {
            var isNeedFlip = target.position.x < transform.position.x;
            var localScale = _originalPlayerScale;
            localScale.x = isNeedFlip ? -_originalPlayerScale.x : _originalPlayerScale.x;
            skin.transform.localScale = localScale;
        }
    }
    
    public void OnDestroy()
    {
        RemoveAllListeners();
    }
}
