using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    
    public void RestartGame() //Restarts game, loads game screen
    {
        SceneManager.LoadScene("GameScene");
    }

}
