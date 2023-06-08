using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour
{
    [SerializeField]
    Button gameStartBtn;

    void Start()
    {
        gameStartBtn.onClick.AddListener(GameStart);
    }

    void GameStart()
    {
        SceneManager.LoadScene("Stage1");
    }
}
