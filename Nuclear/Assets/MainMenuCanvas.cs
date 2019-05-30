using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void ShowPanel(string panelName)
    {
        transform.Find(panelName).gameObject.SetActive(true);
    }

    public void HidePanel(string panelName)
    {
        transform.Find(panelName).gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
