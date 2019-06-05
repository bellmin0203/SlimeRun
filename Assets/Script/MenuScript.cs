using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onMenu1() {
        SceneManager.LoadScene("Main");
    }

    public void onMenu2()
    {
        SceneManager.LoadScene("How");
    }
    public void onMenu3()
    {
        SceneManager.LoadScene("Menu");
    }
}
