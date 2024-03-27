using UnityEngine;

[CreateAssetMenu(fileName = "New PickupBundleObject", menuName = "Pickup Bundle Object", order = 10)]
public class PickupBundleObject : ScriptableObject
{
    [SerializeField] private PickupData[] _pickupData;

    public PickupData[] PickupData => _pickupData;
    
}