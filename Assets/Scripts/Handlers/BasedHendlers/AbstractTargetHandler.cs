using UnityEngine;

public abstract class AbstractTargetHandler : MonoBehaviour, IListener
{
    [SerializeField] private GameObject owner;
    protected Transform _target;

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
        if (owner == thisOwner)
        {
            _target = target;
        }
    }

    public void OnDestroy()
    {
        RemoveAllListeners();
    }
}