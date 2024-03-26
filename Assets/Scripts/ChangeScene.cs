using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScene : MonoBehaviour
{
    /*public bool level;
    public string ScName;

    void Update()
    {
            if(level)
            {
                LoadScene(ScName);
            }
    }
    */
    /// <summary>
    /// Load a new scene at proyect
    /// </summary>
    /// <param name="SceneName"></param>
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    /// <summary>
    /// Allows to quit the game while it execute
    /// </summary>
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Ha salido del juego");
    }
}
