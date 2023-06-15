using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

SceneManager.LoadScene("out_view", LoadSceneMode.Additive);

public class MyCutScene : MonoBehaviour
{
    void Awake()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("out_view"));   
    }
}
