using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContrroller : MonoBehaviour
{
    [Header("OnScreenControls")]
    public GameObject onScreenControls;

    [Header("Button Control Events")]
    public static bool jumpButtonDown;

    //Scene Change
    private int nextSceneIndex;
    private int PreviousSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        CheckPlatform();
    }

    //PRIVATE METHOODS

    private void CheckPlatform()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.WindowsEditor:
                onScreenControls.SetActive(true);
                break;
            default:
                onScreenControls.SetActive(false);
                break;
        }
    }

    //EVENT FUNCTIONS

    public void OnJumpButton_Down()
    {
        jumpButtonDown = true;
    }

    public void OnJumpButton_Up()
    {
        jumpButtonDown = false;
    }

    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(PreviousSceneIndex);
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
