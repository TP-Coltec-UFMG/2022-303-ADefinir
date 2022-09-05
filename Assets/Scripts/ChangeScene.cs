using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nomeDaCena;

    public void ChangeS()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void Sair()
    {
        Application.Quit();
    }
    
    public void RestartGame(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
