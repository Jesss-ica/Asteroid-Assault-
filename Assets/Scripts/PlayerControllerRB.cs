using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerRB : MonoBehaviour
{
    public Vector2 ThrustValue = Vector2.up;
    public float TorqueValue = 1.0f;
    public int HitPoints = 3;
    public GameManager gameManager;
    public PauseMenu pauseMenu;
    private AstroidController astroidController;
    private AudioSource playerDestroyed;
    private bool InvincibilityFrame = false;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // =================================== HEALTH

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Astroid"))
        {
            astroidController = collision.gameObject.GetComponent<AstroidController>();
            astroidController.DestroyAstroid(true);

            if (InvincibilityFrame == false)
            {
                OnHitEffect();
            }
        }
    }

    private void OnHitEffect()
    {
            InvincibilityFrame = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            RemoveHP(1);
            Invoke("RemoveIFrames", 1f);
    }
    private void RemoveIFrames()
    {
        InvincibilityFrame = false;
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public void IncreaseHP(int HP)
    {
        HitPoints += HP;
        gameManager.UpdatePlayerLives(HitPoints);
    }

    public void RemoveHP(int HP)
    {
        HitPoints -= HP;
        gameManager.UpdatePlayerLives(HitPoints);

        if (HitPoints == 0)
        {
            DestroyPlayer();
        }
    }

    private void DestroyPlayer()
    {

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        playerDestroyed = gameObject.GetComponent<AudioSource>();
        playerDestroyed.Play();
        pauseMenu.GameRunning = false;
        Invoke("GameOverInvoke", 1.5f);
    }

    void GameOverInvoke()
    {
        pauseMenu.GameOverMenu();
    }

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        rb2d.AddRelativeForce(ThrustValue * verticalInput);
        rb2d.AddTorque(TorqueValue * -horizontalInput);

    }
}
