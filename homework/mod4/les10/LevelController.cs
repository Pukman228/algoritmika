using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public Spawner spawner;
    public static bool finished = false;
    public static int level = 1;
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    // Start is called before the first frame update
    void Start()
    {
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished == false)
        {
            Check();
        }

    }

    public void Check()
    {
        if (spawner.spawnCounter <= 0)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            if (enemies.Length <= 0)
            {
                Victory();

            }
        }

        if (Corn.singleton.health <= 0)
        {
            Defeat();
        }

    }

    public void Victory()
    {
        finished = true;
        level += 1;
        victoryPanel.SetActive(true);
    }

    public void Defeat()
    {
        finished = true;
        level = 1;
        defeatPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
