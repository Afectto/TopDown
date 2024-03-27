using UnityEngine;

public class SpawnPickup : MonoBehaviour, IListener
{
    [SerializeField] private PickupBundleObject allPickupBundleObject;
    [SerializeField] private PickupManager prefab;

    public void Start()
    {
        AddAllListeners();
    }

    public void AddAllListeners()
    {
        Health.OnOwnerDead += OnDead;
    }

    private void OnDead(GameObject obj)
    {
        if(!obj.CompareTag("Enemy")) return;
        
        var pickUpData = allPickupBundleObject.PickupData;
        var pickupDataLength = pickUpData.Length;
        var randomItemIndex = Random.Range(0, pickupDataLength);
        var randomItem = pickUpData[randomItemIndex];

        var item = Instantiate(prefab, obj.transform.position, Quaternion.identity);
        item.SetName(randomItem.Name);
        item.SetSkin(randomItem.Skin);
    }

    public void RemoveAllListeners()
    {
        Health.OnOwnerDead -= OnDead;
    }
    
    public void OnDestroy()
    {
        RemoveAllListeners();
    }
}
