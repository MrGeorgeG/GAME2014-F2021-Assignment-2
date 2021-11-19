using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Scene Change
    private int nextSceneIndex;
    private int PreviousSceneIndex;

    //Spawn Point for Player
    public Transform player;
    public Transform playerSpawnPoint;

    private void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

        player.position = playerSpawnPoint.position;
    }
    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(PreviousSceneIndex);
    }

    public void OnInstructionButtonPressed()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene("Start");
    }
}
