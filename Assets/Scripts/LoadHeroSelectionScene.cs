using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHeroSelectionScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Loader", 3);
    }

    public void Loader()
    {
        SceneManager.LoadScene("Hero Selection");
    }
}