using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool activo = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (activo)
            {
                pauseMenu.SetActive(false);
                activo = false;
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.SetActive(true);
                activo = true;
                Time.timeScale = 0;
            }
        }
    }

    public void salir()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void continuar()
    {
        pauseMenu.SetActive(false);
        activo = false;
        Time.timeScale = 1;
    }
}
