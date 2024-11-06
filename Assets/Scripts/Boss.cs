using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject maxLeft;
    [SerializeField] private GameObject maxRight;
    [SerializeField] private float shootCooldown;
    private bool canMove;
    private float nextShoot;

    private void Start()
    {
        canMove = true;
        nextShoot = Time.time + shootCooldown;
    }

    private void Update()
    {
        if (canMove)
        {
            Vector3 nextPos = transform.position - new Vector3(transform.position.x - player.transform.position.x, 0, 0) * Time.deltaTime * 4;
            if (nextPos.x >= maxLeft.transform.position.x && nextPos.x <= maxRight.transform.position.x)
            {
                transform.position = nextPos;
            }
        }
        if (Time.time > nextShoot) shoot();
        
    }

    private void shoot()
    {
        GetComponent<Animator>().Play("BossShoot");
        StartCoroutine(timeBeforeCanMove(2f));
        nextShoot = Time.time + shootCooldown;
    }

    IEnumerator timeBeforeCanMove(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}
