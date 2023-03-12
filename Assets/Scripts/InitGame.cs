using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame() {
        SceneManager.LoadScene("Little Shopping Centre");
    }

    public void FinishGame() {
        Application.Quit();
    }

    public void Menu() {
        SceneManager.LoadScene("MainMenu");
    }
}
