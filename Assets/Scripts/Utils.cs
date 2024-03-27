using UnityEngine;

public static class Utils
{
    public static Transform FindTarget(TargetHandler targetHandler, Transform transform, float radius, string tag)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        
        bool isFindEnemy = false;
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                isFindEnemy = true;
                targetHandler.SetTarget(collider.transform);
                return collider.transform;
            }
        }

        if (!isFindEnemy)
        {
            targetHandler.SetTarget(null);
        }

        return null;
    }

    public static Transform FindTarget(Transform transform, float radius, string tag)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                return collider.transform;
            }
        }

        return null;
    }
}