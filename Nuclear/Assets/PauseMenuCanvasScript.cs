using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuCanvasScript : MonoBehaviour
{

    private bool isPause;
    public static bool loser = false;
    // Start is called before the first frame update
    void Start()
    {
        Continue();
        loser = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (loser == false)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPause)
                {
                    Pause();
                    isPause = true;

                }
                else
                {
                    Continue();
                    isPause = false;
                }
            }
        }
        
    }

    public void Pause()
    {
        transform.Find("Pause").gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Continue()
    {
        transform.Find("Pause").gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BackToMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
