using UnityEngine;
using UnityEngine.UIElements;

public class HUDController : MonoBehaviour
{
    private Label _coinLabel;

    private void Start()
    {
        var document = GetComponent<UIDocument>();
        _coinLabel = document.rootVisualElement.Q<Label>("coin-label");

    }

    private void Update()
    {
        //   Update our UI in real time
        if (GameManagerMain.Instance != null && _coinLabel != null)
        {
            _coinLabel.text = "Coins: " + GameManagerMain.Instance.PlayerCoins;
        }
    }

}
