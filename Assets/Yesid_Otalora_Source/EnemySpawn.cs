using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public int maxEnemy = 100;
    private float xPos;
    private float zPos;
    private int enemyCount = 0;
    void Awake()
    {
        StartCoroutine(EnemyDrop());
    }

    void Update()
    {
        Debug.Log(enemyCount);
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < maxEnemy)
        {
           xPos = Random.Range(50, 140);
           zPos = Random.Range(0, 120);
            Instantiate(enemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.001f);
            enemyCount += 1;
        }
    }
}
