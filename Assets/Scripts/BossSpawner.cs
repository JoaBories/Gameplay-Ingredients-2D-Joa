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

    private bool died;
    private bool spawned;

    private void Start()
    {
        spawned = false;
        died = false;
        key.SetActive(false);
        walls.SetActive(false);
    }

    private void Update()
    {
        if (spawned && !died)
        {
            if (!boss.activeSelf)
            {
                key.SetActive(true);
                GetComponent<Animator>().Play("despawn");
                died = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !spawned)
        {
            spawned = true;
            GetComponent<Animator>().Play("spawn");
            boss = Instantiate(bossPrefab, new Vector3(61.5f, 9, 0), Quaternion.identity);
            Boss currentBoss = boss.GetComponent<Boss>();
            currentBoss.maxLeft = maxLeft;
            currentBoss.maxRight = maxRight;
            currentBoss.player = collision.gameObject;
        }
    }

    public void despawn()
    {
        gameObject.SetActive(false);
    }
}
