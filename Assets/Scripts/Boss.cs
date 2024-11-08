using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject maxLeft;
    [SerializeField] private GameObject maxRight;
    [SerializeField] private float actionCooldown;
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<GameObject> lifeList;
    private float nextAction;
    private bool canMove;
    private int actionCount;
    private int life;

    private void Start()
    {
        canMove = true;
        nextAction = Time.time + actionCooldown;
        life = 3;
    }

    private void Update()
    {
        if (canMove)
        {
            if (transform.position.x < player.transform.position.x && transform.position.x + moveSpeed * Time.deltaTime < maxRight.transform.position.x)
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            }
            else if (transform.position.x > player.transform.position.x && transform.position.x - moveSpeed * Time.deltaTime > maxLeft.transform.position.x)
            {
                transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            }


            if (Time.time > nextAction)
            {
                if (actionCount == 1)
                {
                    smash();
                    actionCount = 0;
                }
                else
                {
                    shoot();
                    actionCount++;
                }
            }
        }
        else
        {
            if (Time.time > nextAction) nextAction = Time.time + actionCooldown;
        }
        
        for (int i = 0; i < life; i++)
        {
            lifeList[i].SetActive(true);
        }

    }

    private void shoot()
    {
        GetComponent<Animator>().Play("BossShoot");
        canMove = false;
        nextAction = Time.time + actionCooldown + 2f;
    }

    private void smash()
    {
        GetComponent<Animator>().Play("BossSmash");
        canMove= false;
        nextAction = Time.time + actionCooldown + 4.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            life--;
            if (life >= 0) GetComponent<Animator>().SetTrigger("hit");
            else GetComponent<Animator>().
            collision.GetComponent<Rigidbody2D>().velocity += Vector2.up * 20;
        }
    }

    public void setCanMoveTrue()
    {
        canMove = true;
    }
}
