using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserprefeb;
    [SerializeField] float LaserSpeed=10f;
    [SerializeField] float LaserFiringPeriod;


    Coroutine fireCoroutine;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            fireCoroutine=StartCoroutine(fireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }
    IEnumerator fireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserprefeb, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, LaserSpeed);
           // Destroy(laser,3f);
            yield return new WaitForSeconds(LaserFiringPeriod);
        }
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal")*Time.deltaTime*speedX;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speedY;
        var newXpos = Mathf.Clamp( transform.position.x + deltaX,xMin,xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }
}
