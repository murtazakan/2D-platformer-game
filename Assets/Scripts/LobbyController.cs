using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyController : MonoBehaviour
{
    public GameObject LevelSelection;
    private static int currentSceneIndex;

    public void BackToMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("getting buildindex " + currentSceneIndex);
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        Debug.Log("saving scene " + currentSceneIndex);
        SceneManager.LoadScene(0);
        Debug.Log("after loading scene " + currentSceneIndex);
    }
    public void StartGame()
    {
        Debug.Log("StartGame - if() " + currentSceneIndex);

        if (currentSceneIndex != 0)
        {
            Debug.Log("StartGame - if() " + currentSceneIndex);

            SceneManager.LoadScene(currentSceneIndex);
        }
        else 
        {
            Debug.Log("StartGame - else() " + currentSceneIndex);

            SceneManager.LoadScene(1);
        }
    }
    public void SelectLevel()     
    {
        LevelSelection.SetActive(true);
    }    
}
