using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class aoeProjectileBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public int damageValue = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            rb.velocity = new Vector3(0, 0, 0);
            gameObject.transform.localScale = new Vector3(45.0f, 30.0f, 1.0f);
            StartCoroutine(ExecuteAfterTime(1.5f));

            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<FillerEnemyBehaviour>().ReduceHealth(damageValue);
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
