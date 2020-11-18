using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("Input Settings:")]
    public int playerId;
    Player player;
    bool isPaused = false;

    [Space]
    [Header("Character Attributes:")]
    public float CROSSHAIR_DISTANCE = 2;
    public float MOVEMENT_BASE_SPEED = 3;
    public float PROJECTILE_FORCE = 20f;
    public float DASH_COOLDOWN = 2.0f;
    public float DASH_SPEED = 800;
    public float DASH_DURATION;

    [Space]
    [Header("Character Statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;
    Vector2 mousePos;
    Vector2 firePointPos;
    public float angle;
    public int score = 0;
    public float health = 100;
    public bool invulnerable = false;
    public bool dashCD = false;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public Animator animator;
    public Transform firePoint;
    public GameObject crosshair;
    public bool hasKey = false;

    public GameObject fireBoltPrefab;
    public GameObject aoeBoltPrefab;
    public GameObject piercingBoltPrefab;

    public InventoryScript inventoryScript;
    public GameObject pauseCanvas;
    bool pauseMenuSet = false;
    [Space]
    [Header("Slot References:")]
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;

    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
        DontDestroyOnLoad(gameObject);
        //canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            PlayerDeath();
        }
        if(!isPaused)
        {
            Aim();

            if (player.GetButtonDown("UseAbility1"))
            {
                UseAbility(1);
            }
            if (player.GetButtonDown("UseAbility2"))
            {
                UseAbility(2);
            }
            if (player.GetButtonDown("UseAbility3"))
            {
                UseAbility(3);
            }
            if (player.GetButtonDown("UseAbility4"))
            {
                UseAbility(4);
            }
            if (player.GetButtonDown("Dash"))
            {
                Dash();
            }

            ProcessInputs();
            Move();
            Animate();
        }
        
        if (player.GetButtonDown("Pause"))
        {
            if(!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(player.GetAxis("Horizontal"), player.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void PlayerDeath()
    {
        GameObject observer = GameObject.FindWithTag("GameController");
        observer.GetComponent<GameObserverBehaviour>().SetUIScreen();
        SceneManager.LoadScene("Defeat Screen");
        health = 100;
        score = 0;
    }

    void UseAbility(int slotNumber)
    {
        GameObject spellToInvoke;
        switch (slotNumber)
        {
            case 1:
                if (inventoryScript.isFull[0])
                {
                    spellToInvoke = slot1.transform.GetChild(0).gameObject;
                    spellToInvoke.GetComponent<Button>().onClick.Invoke();
                    inventoryScript.isFull[0] = false;
                }
                break;
            case 2:
                if (inventoryScript.isFull[slotNumber - 1])
                {
                    spellToInvoke = slot2.transform.GetChild(0).gameObject;
                    spellToInvoke.GetComponent<Button>().onClick.Invoke();
                    inventoryScript.isFull[1] = false;
                }
                break;
            case 3:
                if (inventoryScript.isFull[slotNumber - 1])
                {
                    spellToInvoke = slot3.transform.GetChild(0).gameObject;
                    spellToInvoke.GetComponent<Button>().onClick.Invoke();
                    inventoryScript.isFull[2] = false;
                }
                break;
            case 4:
                if (inventoryScript.isFull[slotNumber - 1])
                {
                    spellToInvoke = slot4.transform.GetChild(0).gameObject;
                    spellToInvoke.GetComponent<Button>().onClick.Invoke();
                    inventoryScript.isFull[3] = false;
                }
                break;
            default:
                Debug.Log("Invalid ability slot used");
                break;
        }
    }

    void Move()
    {
        rb.velocity = (movementDirection * movementSpeed) * MOVEMENT_BASE_SPEED;
    }

    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Movement Speed", movementSpeed);
    }

    public void Fire()
    {
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        GameObject bullet = Instantiate(fireBoltPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = shootingDirection * PROJECTILE_FORCE;
        bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg + 90);
        Destroy(bullet, 2.0f);
    }

    void Aim()
    {
        if (movementDirection != Vector2.zero)
        {
            //crosshair.transform.localPosition = movementDirection * CROSSHAIR_DISTANCE;
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        dashCD = false;
    }   

    void Dash()
    {
        Debug.Log("Dash");
        //gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if (!dashCD)
        {
            StartCoroutine(ExecuteAfterTime(DASH_DURATION));
            StartCoroutine(DashCooldown(DASH_COOLDOWN));
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

    public void Setup()
    {
        score = 0;
        health = 100;
        gameObject.transform.position = new Vector3(-25, 20, 0);
}

    IEnumerator ExecuteAfterTime(float time)
    {
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //rb.AddForce(movementDirection * DASH_SPEED);
        dashCD = true;
        gameObject.layer = 14;
        MOVEMENT_BASE_SPEED += DASH_SPEED;

        yield return new WaitForSeconds(time);

        //gameObject.GetComponent<BoxCollider2D>().enabled = true;
        MOVEMENT_BASE_SPEED -= DASH_SPEED;
        gameObject.layer = 8;
    }

    IEnumerator DashCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        dashCD = false;
    }
}
