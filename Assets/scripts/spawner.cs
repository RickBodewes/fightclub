using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public Transform spawnpoint1;
    public Transform spawnpoint2;

    public GameObject zombie;
    public GameObject witch;
    public GameObject devil;
    public GameObject clown;

    public int maxSpawnAmountValue;

    private int currentEnemies;


    public float startTimeValue;
    private float timeValue;
    private float time;

    public float MinTimeInterval;

    public float decreaseTimeValue;
    private float decreaseTime;

    public float decreaseValue;

    private bool spawnChoser = true;

    // Start is called before the first frame update
    void Start()
    {

        timeValue = startTimeValue;
        time = timeValue;
        decreaseTime = decreaseTimeValue;


    }

    // Update is called once per frame
    void Update()
    {
        /*if (test <= 0)
        {
            if (currentEnemies <= maxSpawnAmountValue)
            {
                Instantiate(zombie, spawnpoint1.position, Quaternion.identity, GameObject.Find("enemies").transform);
                Instantiate(zombie, spawnpoint2.position, Quaternion.identity, GameObject.Find("enemies").transform);
                currentEnemies += 2;

            }
            
            test = 3f;
        }
        else
        {
            test -= Time.deltaTime;
        }*/

        int enemy = Random.Range(0, 4);

        //spawns enemy at set time interval
        if(time <= 0)
        {
            
            //checks if max amount of enemies hasn't been exceeded
            if(currentEnemies < maxSpawnAmountValue)
            {
                //chooses between spawnpoint
                if (spawnChoser)
                {
                    switch (enemy)
                    {
                        case 0:
                            Instantiate(zombie, spawnpoint1.position, Quaternion.identity, GameObject.Find("enemies").transform);
                            break;
                        case 1:
                            Instantiate(witch, spawnpoint1.position, Quaternion.identity, GameObject.Find("enemies").transform);
                            break;
                        case 2:
                            Instantiate(devil, spawnpoint1.position, Quaternion.identity, GameObject.Find("enemies").transform);
                            break;
                        case 3:
                            Instantiate(clown, spawnpoint1.position, Quaternion.identity, GameObject.Find("enemies").transform);
                            break;

                    }
                    spawnChoser = !spawnChoser;
                }
                else
                {
                    switch (enemy)
                    {
                        case 0:
                            Instantiate(zombie, spawnpoint2.position, Quaternion.identity, GameObject.Find("enemies").transform);
                            break;
                        case 1:
                            Instantiate(witch, spawnpoint2.position, Quaternion.identity, GameObject.Find("enemies").transform);
                            break;
                        case 2:
                            Instantiate(devil, spawnpoint2.position, Quaternion.identity, GameObject.Find("enemies").transform);
                            break;
                        case 3:
                            Instantiate(clown, spawnpoint2.position, Quaternion.identity, GameObject.Find("enemies").transform);
                            break;

                    }
                    spawnChoser = !spawnChoser;
                }
                currentEnemies++;
            }



            time = timeValue;
        }
        else
        {
            time -= Time.deltaTime;
        }

        //decreases spawn interval
        if (decreaseTime <= 0)
        {
            if (timeValue - decreaseValue > 1f)
            {
                timeValue -= decreaseValue;
            }
            else
            {
                timeValue = MinTimeInterval;
            }

            decreaseTime = decreaseTimeValue;
        }
        else
        {
            decreaseTime -= Time.deltaTime;
        }




    }
    //decreases enemy amount alive when enemy is killed
    public void removeEnemy()
    {
        currentEnemies--;
    }

}
