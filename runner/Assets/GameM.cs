using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameM : MonoBehaviour
{
    public Transform FireBall;
    private Vector3 nextFireBallSpawn = new Vector3(5, 3, 0);
    public Transform SnowBall;
    private Vector3 nextSnowBallSpawn = new Vector3(5, 0, 0);
    public Transform lava;
    private Vector3 nextLavaSpawn = new Vector3(60, 0, 0);
    public Transform snow;
    private Vector3 nextSnowSpawn = new Vector3(60, 3, 0);
    public Material snowskybox;
    private float randZ;
    private int it = 0;
    private int it2 = 0;
    void Start()
    {
        StartCoroutine(spawnLava());
    }

    void Update()
    {

    }
    IEnumerator spawnLava()
    {
        yield return new WaitForSeconds(1);

        nextLavaSpawn.x += 10;
        Instantiate(lava, nextLavaSpawn, lava.rotation);
        for (int i = 0; i < 2; i++)
            {
                nextFireBallSpawn.x += 2;
                for (int j = 0; j < 2; j++)
                {
                    randZ = Random.Range(-4, 5);
                    nextFireBallSpawn.z = randZ;
                    Instantiate(FireBall, nextFireBallSpawn, FireBall.rotation);
                }
            }

        it++;
        if (it < 10)
            StartCoroutine(spawnLava());
        else
        {
            StopCoroutine(spawnLava());
            StartCoroutine(spawnSnow());
            nextLavaSpawn.x = nextSnowSpawn.x;
            nextFireBallSpawn.x = nextSnowBallSpawn.x;
            RenderSettings.skybox = snowskybox;
        }
    }
    IEnumerator spawnSnow()
    {
        yield return new WaitForSeconds(1);
        nextSnowSpawn.x += 10;
        Instantiate(snow, nextSnowSpawn, snow.rotation);
        Physics.gravity = new Vector3(0, 9.81f, 0);
        for (int i = 0; i < 2; i++)
        {
            nextSnowBallSpawn.x += 2;
            for (int j = 0; j < 2; j++)
            {
                randZ = Random.Range(-4, 5);
                nextSnowBallSpawn.z = randZ;
                Instantiate(SnowBall, nextSnowBallSpawn, SnowBall.rotation);
            }
        }

        it2++;
        if(it2 < 10)
            StartCoroutine(spawnSnow());
    }
}
