using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerEnemyBehaviour : MonoBehaviour
{
    public int Health = 1;
    public float Speed = 3;
    public float Damage = 5;
    public int dropChance = 3;
    public bool willDropItem;
    public int scoreValue = 10;
    public GameObject[] dropTable;
    GameObject player;
    private Rigidbody2D rb;
    private CircleCollider2D hitBox;
    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        Health += (int)gameController.GetComponent<GameObserverBehaviour>().GameDifficultyScalar;
        int dropCheck = Random.Range(0, dropChance);
        if (dropCheck == dropChance - 1)
        {
            willDropItem = true;
        }
        else
        {
            willDropItem = false;
        }

        rb = gameObject.GetComponent<Rigidbody2D>();
        hitBox = gameObject.GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    // Note: Should probably call HealthCheck in a trigger function based on a change in health, so it's not wasting resources checking every frame.
    void Update()
    {
        HealthCheck();
    }
    
    void HealthCheck()
    {
        if (Health <= 0)
        {
            KillEnemy();
        }
    }

    public void ReduceHealth(int damageTaken)
    {

        StartCoroutine(DamageAnim(1));
        Health -= damageTaken;
    }

    public void KillEnemy()
    {
        if (willDropItem)
        {
            GameObject itemDrop = dropTable[Random.Range(0, dropTable.Length)];
            Instantiate(itemDrop, gameObject.transform.position, Quaternion.identity);
        }
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerController>().AddScore(scoreValue);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ExecuteAfterTime(1));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerController>().audioSource.PlayOneShot(player.GetComponent<PlayerController>().DamageSFX);
        gameObject.GetComponent<Animator>().SetInteger("AnimState", 3);
        player.GetComponent<PlayerController>().health -= Damage;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        hitBox.enabled = false;
        yield return new WaitForSeconds(time);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        hitBox.enabled = true;
        gameObject.GetComponent<Animator>().SetInteger("AnimState", 0);
    }

    IEnumerator DamageAnim(float time)
    {
        gameObject.GetComponent<Animator>().SetInteger("AnimState", 4);
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<Animator>().SetInteger("AnimState", 0);
    }

}
