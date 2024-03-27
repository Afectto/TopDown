using UnityEngine;

public class MovingToTarget : AbstractTargetHandler
{
    [SerializeField] private float speed;

    public void Move()
    {
        if (!_target) return;
        
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * speed);
    }

    public void RotateByMove()
    {
        Vector3 diference = _target.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

}
