using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinPanel : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
