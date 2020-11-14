using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonBehaviour : MonoBehaviour
{
    private GameObject player;
    PlayerController playerScript;
    private int triShotLimiter = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnHealthPotionUsed()
    {
        Debug.Log("Health Potion Used");
    }

    public void OnScrollOfDestructionUsed()
    {
        StartCoroutine(TriShotDelay(0.2f));
        StartCoroutine(TriShotDelay(0.4f));
        StartCoroutine(TriShotDelay(0.6f));

        //Destroy(gameObject);
    }

    public void OnDoransHourglassUsed()
    {
        Debug.Log("Health Potion Used");
    }

    public void OnConductiveSurgeUsed()
    {
        ExplosiveProjectile();
        Destroy(gameObject);
    }

    public void OnCurseOfAkhlysUsed()
    {
        Debug.Log("Health Potion Used");
    }

    public void OnDefenseRuneUsed()
    {
        Debug.Log("Health Potion Used");
    }

    public void OnOffenseRuneUsed()
    {
        Debug.Log("Health Potion Used");
    }

    public void OnNullifierUsed()
    {
        Debug.Log("Health Potion Used");
    }

    public void OnLargeCoinsUsed()
    {
        Debug.Log("Health Potion Used");
    }

    public void OnExplosivesUsed()
    {
        Debug.Log("Health Potion Used");
    }


    public void OnDeadmansCurseUsed()
    {
        StartCoroutine(PiercingShotDelay(2.0f));
    }

    public void OnSmallCoindsUsed()
    {
        Debug.Log("Health Potion Used");
    }

    /*
     * 
     * NON-SPELL FUNCTIONS
     * 
     */

    public void ExplosiveProjectile()
    {
        Vector2 shootingDirection = playerScript.crosshair.transform.localPosition;
        shootingDirection.Normalize();
        GameObject bullet = Instantiate(playerScript.aoeBoltPrefab, playerScript.firePoint.position, Quaternion.identity);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = shootingDirection * playerScript.PROJECTILE_FORCE;
        bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg + 90);
    }

    public void BasicTriShot()
    {
        Vector2 shootingDirection1 = playerScript.crosshair.transform.localPosition;
        Vector2 shootingDirection2 = playerScript.crosshair.transform.localPosition;
        Vector2 shootingDirection3 = playerScript.crosshair.transform.localPosition;

        shootingDirection1.Normalize();

        shootingDirection2 = new Vector2(shootingDirection2.x + 0.75f, shootingDirection2.y);
        shootingDirection2.Normalize();

        shootingDirection3 = new Vector2(shootingDirection3.x - 0.75f, shootingDirection3.y);
        shootingDirection3.Normalize();

        GameObject bullet1 = Instantiate(playerScript.fireBoltPrefab, playerScript.firePoint.position, Quaternion.identity);
        GameObject bullet2 = Instantiate(playerScript.fireBoltPrefab, playerScript.firePoint.position, Quaternion.identity);
        GameObject bullet3 = Instantiate(playerScript.fireBoltPrefab, playerScript.firePoint.position, Quaternion.identity);


        Rigidbody2D bulletRB1 = bullet1.GetComponent<Rigidbody2D>();
        bulletRB1.velocity = shootingDirection1 * playerScript.PROJECTILE_FORCE;
        bullet1.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection1.y, shootingDirection1.x) * Mathf.Rad2Deg + 90);


        Rigidbody2D bulletRB2 = bullet2.GetComponent<Rigidbody2D>();
        bulletRB2.velocity = shootingDirection2 * playerScript.PROJECTILE_FORCE;
        bullet2.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection2.y, shootingDirection2.x) * Mathf.Rad2Deg + 90);


        Rigidbody2D bulletRB3 = bullet3.GetComponent<Rigidbody2D>();
        bulletRB3.velocity = shootingDirection3 * playerScript.PROJECTILE_FORCE;
        bullet3.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection3.y, shootingDirection3.x) * Mathf.Rad2Deg + 90);

        Destroy(bullet1, 2.0f);
        Destroy(bullet2, 2.0f);
        Destroy(bullet3, 2.0f);
    }

    IEnumerator TriShotDelay(float time)
    {
        yield return new WaitForSeconds(time);

        BasicTriShot();
        triShotLimiter++;
        if (triShotLimiter == 3)
        {
            triShotLimiter = 0;
            Destroy(gameObject);
        }
    }

    IEnumerator PiercingShotDelay(float time)
    {
        Vector2 shootingDirection = playerScript.crosshair.transform.localPosition;
        shootingDirection.Normalize();
        GameObject bullet = Instantiate(playerScript.piercingBoltPrefab, playerScript.firePoint.position, Quaternion.identity);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = shootingDirection * playerScript.PROJECTILE_FORCE;
        bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg + 90);
        Destroy(gameObject);

        yield return new WaitForSeconds(time);
        Destroy(bullet);
    }
}

/*
 * Scroll of Destruction
 * Dorans Hourglass
 * Conductive Surge
 * Curse of Akhlys
 * Defense Rune
 * Offense Rune
 * Nullifier
 * Large Coins
 * Explosives
 * Deadmans Curse
 * Small Coins
 */