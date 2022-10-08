using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<waveConfig> WaveConfigs;
   [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    // Start is called before the first frame update
   IEnumerator Start()
    {

        // var curentWave = WaveConfigs[startingWave];
        //StartCoroutine(SpawnAllEnemiesInWave(curentWave));
        do
        {
            yield return StartCoroutine(SpawnAllWave());
        }
        while (looping);
    }
    private IEnumerator SpawnAllWave()
    {
        for(int waveIndex=startingWave;waveIndex<WaveConfigs.Count;waveIndex++)
        {
            var currentWave = WaveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        } 
    }
    private IEnumerator SpawnAllEnemiesInWave(waveConfig waveConfig)
    {
        for(int enemyCount=0;enemyCount < waveConfig.GetNumberOfEnemies();enemyCount++)
        {
            var newEnemy=Instantiate(waveConfig.GetEnemyPrefeb(), waveConfig.GetWayPoint()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
