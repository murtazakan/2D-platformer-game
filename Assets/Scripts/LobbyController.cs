using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public GameObject LevelSelection;
    public static int currentSceneIndex;
    public PlayerController playerController;

    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void Update() 
    {
        Debug.Log(currentSceneIndex);
    }
    public void BackToMenu()
    {

        playerController.SavePlayer();
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        currentSceneIndex = data.level;
        DeathController.health = data.hearts;
        playerController.LoadPlayer(data);
        SceneManager.LoadScene(currentSceneIndex);


    }
    public void SelectLevel()     
    {
        LevelSelection.SetActive(true);
    }    
}
