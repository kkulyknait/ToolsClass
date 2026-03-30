using UnityEngine;

public class GameManagerMain : MonoBehaviour
{
    //  Making this a static Instance allows ALL scripts to talk to this manager.
    public static GameManagerMain Instance { get; private set; }
    
    //  Persistent Game Data Variables
    public int PlayerCoins = 0;
    public int PlayerHealth = 3;
    public int CurrentLevel = 1;

    public string GameOverMessage = "";  ///  We will use this later to pass Win/Lose text!

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

}
