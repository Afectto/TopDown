using System;
using UnityEngine;

public class MoveToTargetAndDestroy : AbstractTargetHandler
{
    [SerializeField] private float speed;
    private Vector3 _lastTargetPosition;

    public static Action<Transform> OnObjectInTarget;

    public void MoveObjectToTarget()
    {		
        if (!_target)
        {
            transform.position = Vector3.MoveTowards(transform.position, _lastTargetPosition, Time.deltaTime * speed);
            if (transform.position == _lastTargetPosition)
            {
                Destroy(gameObject);
            }
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * speed);
        _lastTargetPosition = _target.position;
        
        Vector3 diference = _target.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        
        if (transform.position == _lastTargetPosition)
        {
            OnObjectInTarget?.Invoke(_target);
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
