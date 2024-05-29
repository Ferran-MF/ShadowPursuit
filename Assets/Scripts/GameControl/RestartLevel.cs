using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public void RestartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}