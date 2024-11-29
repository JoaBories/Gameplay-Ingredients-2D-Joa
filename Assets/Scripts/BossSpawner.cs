using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject walls;
    [SerializeField] private GameObject maxLeft;
    [SerializeField] private GameObject maxRight;
    private GameObject boss;

    private bool spawned;

    private void Start()
    {
        spawned = false;
        key.SetActive(false);
        walls.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !spawned)
        {
            spawned = true;
            boss = Instantiate(bossPrefab, new Vector3(61.5f, 9, 0), Quaternion.identity);
            Boss currentBoss = boss.GetComponent<Boss>();
            currentBoss.maxLeft = maxLeft;
            currentBoss.maxRight = maxRight;
            currentBoss.player = collision.gameObject;
        }
    }
}
