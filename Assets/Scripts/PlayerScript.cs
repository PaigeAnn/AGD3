using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    float moveInputX;
    float moveInputY;
    public Vector3 spawnPoint;

    public TMP_Text scoreText;
    public int score = 0;

    public GameObject deathPanel;



    Rigidbody2D rb2d;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //moves player
        rb2d.linearVelocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<Vector2>());
        moveInputX = ctx.ReadValue<Vector2>().x;
        moveInputY = ctx.ReadValue<Vector2>().y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GoodFlower"))
        {
            other.gameObject.SetActive(false);
            score = score + 5;
            scoreText.text = "Money: $" + score.ToString();
        }
        if (other.gameObject.CompareTag("GoodFlower2"))
        {
            other.gameObject.SetActive(false);
            score = score + 10;
            scoreText.text = "Money: $" + score.ToString();
        }
        else if (other.gameObject.CompareTag("BadFlower"))
        {
            //die
            Debug.Log("You lose!");
            deathPanel.SetActive(true);
        }
    }
}
