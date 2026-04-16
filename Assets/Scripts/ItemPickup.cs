using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;  //  Drag Scriptable Object Here! 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //  Tell the GameManager we collected this item!
            GameManagerMain.Instance.CollectItem(_itemData);

            //  Update the HUD
            FindObjectOfType<HUDController>().UpdateInventoryUI();

            // Destroy this item from the scene
            Destroy(gameObject);
        }
    }


}
