using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private UIDocument _document;
    private Button _startButton;
    private Label _scoreLabel;
    private Button _quitButton;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _startButton = _document.rootVisualElement.Q<Button>("start-button");
        _scoreLabel = _document.rootVisualElement.Q<Label>("score-label");
        _quitButton = _document.rootVisualElement.Q <Button>("quit-button");

        if (_startButton != null)
        {
            _startButton.clicked += OnStartClicked;
        }
        if (_quitButton != null)
        {
            _quitButton.clicked += OnQuitClicked;
        }

    }
    private void Start()
    {
        //Check to see if Game Manager exists and if so, get the current score and display it
        if (GameManagerMain.Instance != null && _scoreLabel != null)
        {
            _scoreLabel.text = GameManagerMain.Instance.GameOverMessage + " Final Coins:" +
                GameManagerMain.Instance.PlayerCoins;
        }
    }
    private void OnStartClicked()
    {
        Debug.Log("Start Button Clicked!  Loading into Game");
        SceneManager.LoadScene(1);
    }

    private void OnQuitClicked()
    {
        Debug.Log("Quit it!");
        Application.Quit();
    }
}
