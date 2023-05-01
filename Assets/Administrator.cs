using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //oyun bittikten sonra tekrar oyunu yüklemek için SceneManagement kütüphanesi elzem.

public class Administrator : MonoBehaviour
{
    public GameObject gameOverPanel;

    

    public void showPanel()
    {
        gameOverPanel.SetActive(true); //game over paneli aktive edildi, parametre yoluyla.

        Invoke("stop", 1.0f);

    }

    void stop()
    {
        Time.timeScale = 0.0f; //oyunun durdurulması için lüzumlu fonksiyon.
    }

    public void playAgain()
    {
        Time.timeScale = 1.0f; //0.0f olsaydı oyun donardı. Bunu engellemek adına 1 saniye dedik.

        SceneManager.LoadScene("Scenes/Game");
    }
    
}
