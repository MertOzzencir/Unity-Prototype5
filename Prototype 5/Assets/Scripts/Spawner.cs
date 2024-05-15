using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public TextMeshProUGUI scorText;
    public static Spawner instance;
    public bool canStop;
    float counter;
    public static float spawnTimer;
    public static float minSpawnTimer;
    public int score;
    public GameObject gameOverScreen;

    
    void Start()
    {
        instance = this;
       
        StartCoroutine(Spawn());
    }

    private void Update()
    {
       
        scorText.text = "SCORE: " + score.ToString();
    }


    IEnumerator Spawn()
    {
        while (true && !canStop)
        {
            
            int randomIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randomIndex].transform, RandomPos(), Quaternion.identity);
            counter += 1;
            if(counter % 5 ==0)
                spawnTimer -= .01f;
            spawnTimer = Mathf.Clamp(spawnTimer, minSpawnTimer, 2);
            yield return new WaitForSeconds(spawnTimer);
        }


    }

    Vector3 RandomPos()
    {

        Vector3 pos = new Vector3(Random.Range(-4.5f,4.5f),-1.5f,0);
        return pos ;
    }

    public void RestartGame()
    {
        canStop = true;
        Target.stopVelocityForAll = false;
        SceneManager.LoadScene(1);
    }

    public void ShowGameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
    }
    public void MainMenu()
    {
        canStop = true;
        Target.stopVelocityForAll = false;
        SceneManager.LoadScene(0);   
    }

    private void OnEnable()
    {
        if (LevelChanger.dif == LevelChanger.LevelDif.Easy)
        {
            Target.difValues = new Vector2(12, 14);
            Spawner.minSpawnTimer = .8f;
            Spawner.spawnTimer = 2f;
        }
        if (LevelChanger.dif == LevelChanger.LevelDif.Easy)
        {
            Target.difValues = new Vector2(18, 20);
            Spawner.spawnTimer = 1.5f;
            Spawner.minSpawnTimer = .6f;
        }
        if (LevelChanger.dif == LevelChanger.LevelDif.Easy)
        {
            Target.difValues = new Vector2(20, 24);
            Spawner.spawnTimer = 1f;
            Spawner.minSpawnTimer = .3f;
        }
        print("Target.difValues: " + Target.difValues + "Spawner.spawnTimer:" + Spawner.spawnTimer + "Spawner.minSpawnTimer: " + Spawner.minSpawnTimer + "Dif: " +
           LevelChanger.dif);
    }

}
