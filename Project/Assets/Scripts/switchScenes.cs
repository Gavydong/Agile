using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class switchScenes : MonoBehaviour
{
    // Start is called before the first frame update

    public void GameModesLoader(int sceneIndex)
    {
        
        SceneManager.LoadScene(sceneIndex);
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}