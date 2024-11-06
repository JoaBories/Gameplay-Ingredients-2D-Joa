using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        transform.position -= new Vector3(transform.position.x- player.transform.position.x, 0, 0) * Time.deltaTime * 4;
    }

    private void shoot()
    {
        GetComponent<Animator>().Play("BossShoot");
    }
}
