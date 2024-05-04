using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
   
    public enum LevelDif
    {
        Easy,
        Medium,
        Hard
    }
    public static LevelDif dif;

    public void OnEasyDif()
    {
        Target.difValues = new Vector2(12, 14);
        Spawner.minSpawnTimer = .8f;
        Spawner.spawnTimer = 2f;
        dif = LevelDif.Easy;

        SceneManager.LoadScene(1);

    }
    public void OnMediumDif()
    {
        Target.difValues = new Vector2(18, 20);
        Spawner.spawnTimer = 1.5f;
        Spawner.minSpawnTimer = .6f;
        dif = LevelDif.Medium;
        SceneManager.LoadScene(1);

    }
    public void OnHardDif()
    {
        Target.difValues = new Vector2(20, 24);
        Spawner.spawnTimer = 1f;
        Spawner.minSpawnTimer = .3f;
        dif = LevelDif.Hard;
        SceneManager.LoadScene(1);
    }
}
