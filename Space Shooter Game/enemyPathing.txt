using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] waveConfig WaveConfig;
    List<Transform> wayPoint;
    int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        wayPoint = WaveConfig.GetWayPoint();
        transform.position = wayPoint[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void SetWaveConfig(waveConfig WaveConfig)
    {
        this.WaveConfig = WaveConfig;
    }

    private void Move()
    {
        if (wayPointIndex <= wayPoint.Count - 1)
        {
            var targetPos = wayPoint[wayPointIndex].transform.position;
            var moveThisFrame = WaveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveThisFrame);
            if (transform.position == targetPos)
            {
                wayPointIndex++;
            }

        }
        else
        {
           Destroy(gameObject);
        }
    }
}
