using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName ="Enemy wave config")]
public class waveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefeb;
    [SerializeField] GameObject pathPrefeb;
    [SerializeField] float timeBetweenSpawns=0.5f;
    [SerializeField] float spawnRandomFactor=0.3f;
    [SerializeField] int numberOfEnemies=5;
    [SerializeField] float moveSpeed=2f;
    public GameObject GetEnemyPrefeb() { return enemyPrefeb; }
    public List<Transform>GetWayPoint()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefeb.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
    
}
