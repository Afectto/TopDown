using UnityEngine;

public class RotateWeapon : AbstractTargetHandler
{
    private Quaternion _originalGunRotation;
    private Vector3 _originalGunScale;
    
    protected override void Awake()
    {
        _owner = GetComponentInParent<PlayerManager>().gameObject;
    }

    public override void Start()
    {
        base.Start();
        _originalGunRotation = transform.rotation;
        _originalGunScale = transform.localScale;
    }

    void Update()
    {
        if (_target == null)
        {
            ResetWeaponPosition();
            return;
        }

        RotateGun();
    }

    private void RotateGun()
    {
        Vector3 diference = _target.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        Vector3 localScale = transform.localScale;

        if (rotationZ > 90 || rotationZ < -90)
        {
            localScale.y = -_originalGunScale.y;
        }
        else
        {
            localScale.y = _originalGunScale.y;
        }
		
        transform.localScale = localScale;
    }

    private void ResetWeaponPosition()
    {
        transform.localScale = _originalGunScale;
        transform.rotation = _originalGunRotation;
    }
}
