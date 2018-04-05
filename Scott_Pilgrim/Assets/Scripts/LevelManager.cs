using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required to switch scenes

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public int CurrentSceneIndex;
    public int score;
    // Use this for initialization
    void Awake()
    {
        if (levelManager == null)
        {
            DontDestroyOnLoad(gameObject);
            levelManager = this;
        }
        else if (levelManager != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(string name)
    {
        print("Loading " + name);
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            LoadNextLevel();
        }
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
   

   

}

