using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {

        SceneManager.LoadScene("SC_Map_A_3");

    }

    public void ExitGame()
    {

        Application.Quit();

    }
}
