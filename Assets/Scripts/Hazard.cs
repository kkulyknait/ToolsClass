using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Defeated!  Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // reloads current level

            //Debug.Log("Player hit a hazard!  Lose a life!");
            //GameManagerMain.Instance.PlayerHealth -= 1;
            //if (GameManagerMain.Instance.PlayerHealth <= 0)
            //{
            //    Debug.Log("Player has no more health!  Game Over!");
            //    GameManagerMain.Instance.GameOverMessage = "Game Over!";
            //    SceneManager.LoadScene(0);  //Load main menu
            //}
        }
    }
   
}
