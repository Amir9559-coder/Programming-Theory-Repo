using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] foods;
    int horizontalSide;
    int verticalSide;
    float horizontalRandomPos;
    float verticalRandomPos;
    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnFood()
    {
        if(GameManager.instance.isGameOver == false)
        {
            yield return new WaitForSeconds(0.5f);
            int foodRandomIndex = Random.Range(0, foods.Length);
            SpawnPositonRotation();
            Instantiate(foods[foodRandomIndex], spawnPos, transform.rotation);
            StartCoroutine(SpawnFood());
        }
    }
    void SpawnPositonRotation()
    {
        horizontalSide = Random.Range(-1, 2);
        switch (horizontalSide)
        {
            case -1:
                verticalRandomPos = Random.Range(-12, 12);
                spawnPos = new Vector3(horizontalSide * 12, 0, verticalRandomPos);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 1:
                verticalRandomPos = Random.Range(-12, 12);
                spawnPos = new Vector3(horizontalSide * 12, 0, verticalRandomPos);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                break;
            default:
                SpawnInVertical();
                break;
        }
    }
    void SpawnInVertical()
    {
        verticalSide = Random.Range(-1, 2);
        switch (verticalSide)
        {
            case -1:
                horizontalRandomPos = Random.Range(-12, 12);
                spawnPos = new Vector3(horizontalRandomPos, 0, verticalSide * 12);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 1:
                horizontalRandomPos = Random.Range(-12, 12);
                spawnPos = new Vector3(horizontalRandomPos, 0, verticalSide * 12);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            default:
                horizontalRandomPos = Random.Range(-12, 12);
                spawnPos = new Vector3(horizontalRandomPos, 0, 12);
                break;
        }
    }
}
