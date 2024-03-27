using UnityEngine;

public class RotatePlayer : AbstractTargetHandler
{
    [SerializeField] private GameObject skin;
    
    private Vector3  _originalPlayerScale;

    public override void Start()
    {
        base.Start();
        _originalPlayerScale = skin.transform.localScale;
    }

    private void Update()
    {        
        if (_target == null)
        {
            ResetPayerPosition();
            return;
        }
        Flip();
    }

    private void Flip()
    {
        if (_target)
        {
            var isNeedFlip = _target.position.x < transform.position.x;
            var localScale = _originalPlayerScale;
            localScale.x = isNeedFlip ? -_originalPlayerScale.x : _originalPlayerScale.x;
            skin.transform.localScale = localScale;
        }
    }

    private void ResetPayerPosition()
    {
        skin.transform.localScale = _originalPlayerScale;
    }

}
