using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPlay : MonoBehaviour
{

    Scene s;
    public TMP_Text winText;
    void Start()
    {
        s = SceneManager.GetActiveScene();
        string ganhador = PlayerPrefs.GetString("ganhador");
        Debug.Log("Awake:" + s.name);
        Debug.Log("Ganhador: " + ganhador);
        if (s.name == "Restart")
        {
            winText.text = ganhador;
        }
    }

    public void PlayGame()
    {
        Debug.Log("Play Pong");
        SceneManager.LoadScene("Pong");
    }
}
