using UnityEngine;
using UnityEngine.UIElements;

public class HUDController : MonoBehaviour
{
    private Label _coinLabel;

    [SerializeField] private ItemData[] _requiredItems;  ///Drag out scriptable objects for require items 

    private void Start()
    {
        var document = GetComponent<UIDocument>();
        _coinLabel = document.rootVisualElement.Q<Label>("coin-label");

        var listContainer = document.rootVisualElement.Q<VisualElement>("item-list-container");
        if (listContainer != null && _requiredItems != null)
        {
            //  Look through our ScriptableOjects and build a UI element for each one
            foreach (ItemData item in _requiredItems)
            {
                Label newLabel = new Label();
                newLabel.text = "[Missing]" + item.ItemName;
                newLabel.style.color = Color.white;

                listContainer.Add(newLabel);  // Dynamically display our asset data on our UI
            }
        }
        UpdateInventoryUI(); 
    }
    public void UpdateInventoryUI()
    {
        var listContainer = GetComponent<UIDocument>().rootVisualElement
            .Q<VisualElement>("item-list-container");
        listContainer.Clear();  //  Clear out old List

        foreach (ItemData item in _requiredItems)
        {
            Label newLabel = new Label();
            bool hasItem = GameManagerMain.Instance.HasItem(item);  // Check if player has the item
            newLabel.text = (hasItem ? "[Found] " : "[Missing] ") + item.ItemName;
            newLabel.style.color = hasItem ? Color.green : Color.white;
            listContainer.Add(newLabel);  //  Update our display with new info 
        }
    }
    private void Update()
    {
        //   Update our UI in real time
        if (GameManagerMain.Instance != null && _coinLabel != null)
        {
            _coinLabel.text = "Coins: " + GameManagerMain.Instance.PlayerCoins;
           // Debug.Log("Should be updating coin count on HUD");
        }
    }

}
