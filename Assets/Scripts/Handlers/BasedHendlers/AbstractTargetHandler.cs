using UnityEngine;

public abstract class AbstractTargetHandler : MonoBehaviour, IListener
{
    protected GameObject _owner;
    protected Transform _target;

    protected virtual void Awake()
    {
        _owner = gameObject;
    }

    public virtual void Start()
    {
        AddAllListeners();
    }

    public virtual void AddAllListeners()
    {
        TargetHandler.OnSetTarget += SetTarget;
    }

    public virtual  void RemoveAllListeners()
    {
        // ReSharper disable once DelegateSubtraction
        TargetHandler.OnSetTarget -= SetTarget;
    }

    private void SetTarget(GameObject thisOwner, Transform target)
    {
        if (_owner == thisOwner)
        {
            _target = target;
        }
    }

    public void OnDestroy()
    {
        RemoveAllListeners();
    }
}