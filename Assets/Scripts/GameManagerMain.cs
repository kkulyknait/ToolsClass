using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMain : MonoBehaviour
{
    //  Making this a static Instance allows ALL scripts to talk to this manager.
    public static GameManagerMain Instance { get; private set; }
    
    //  Persistent Game Data Variables
    public int PlayerCoins = 0;
    public int PlayerHealth = 3;
    public int CurrentLevel = 1;

    public string GameOverMessage = "";  ///  We will use this later to pass Win/Lose text!

    public int CoinsNeededForLevel2 = 4;
    public int CoinsNeededToWin = 8;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  //  Make me IMMORTAL!!
        }
        else
        {
            //If another manager is somehow accidentally created, destroy it.
            Destroy(gameObject);
        }
    }

    public void TryAdvanceLevel()
    {
        if (CurrentLevel == 1)
        {
            if (PlayerCoins >= CoinsNeededForLevel2)
            {
                Debug.Log("Level 1 Complete!  Loading Level 2...");
                CurrentLevel = 2;
                SceneManager.LoadScene(2);
            }
            else
            {
                Debug.Log("You need " + CoinsNeededForLevel2);
            }
        }
        else if (CurrentLevel ==2)
        {
            if (PlayerCoins >= CoinsNeededToWin)
            {
                Debug.Log("A Winner is You!");
                GameOverMessage = "A Winner is You!";
                SceneManager.LoadScene(0);  //Load main menu
            }
            else
            {
                Debug.Log("You need " + CoinsNeededToWin);
            }
        }
    }

}
