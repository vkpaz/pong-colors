using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TriggerPontuacao : MonoBehaviour
{
    public AudioClip clip;
    AudioSource audioSource;
    int pontos;
    public int pontosParaGanhar;
    public TMP_Text placar;
    public TriggerPontuacao j1;
    public TriggerPontuacao j2;
    void Awake()
    {
        pontosParaGanhar = 3;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;

        j1 = GameObject.FindWithTag("TriggerPontuacao2").GetComponent<TriggerPontuacao>();
        j2 = GameObject.FindWithTag("TriggerPontuacao1").GetComponent<TriggerPontuacao>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        pontos++;

        Bola bola = coll.gameObject.GetComponent<Bola>();
        if (bola != null)
        {

            bola.tr.Clear();
            audioSource.Play();

            coll.transform.position = Vector3.zero;

            bola.direction.x = bola.direction.x * -1;
            bola.currentSpeed = bola.speed;
            placar.text = "" + pontos;
        }

        EndGame();
    }
    void EndGame()
    {
        if ((j1.pontos - j2.pontos) >= pontosParaGanhar)
        {
            PlayerPrefs.SetString("ganhador", "Jogador 1 Ganhou!");
            SceneManager.LoadScene("Restart");
        }
        else if ((j2.pontos - j1.pontos) >= pontosParaGanhar)
        {
            PlayerPrefs.SetString("ganhador", "Jogador 2 Ganhou!");
            SceneManager.LoadScene("Restart");
        }
    }
}
