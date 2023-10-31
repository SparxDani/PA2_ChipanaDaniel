using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button btnPlay;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(() => Play());
    }

    void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
