using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Platformer/ItemData")]

public class ItemData : ScriptableObject
{
    public string ItemName;
    public Sprite ItemIcon;
}
