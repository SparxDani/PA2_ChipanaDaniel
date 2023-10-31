using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    public Button btnPlay;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(() => ReturnMenu());
    }

    void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
