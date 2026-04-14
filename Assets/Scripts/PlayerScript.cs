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
    public int numOfFlower1 = 0;
    public int numOfFlower2 = 0;
    public int numOfPlant1 = 0;
    public int numOfPlant2 = 0;
    public int numOfPlant3 = 0;

    public bool isPlanted = false;
    public bool canPlant = false;

    public PlantingScript plantingScript;

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
       // Debug.Log(ctx.ReadValue<Vector2>());
        moveInputX = ctx.ReadValue<Vector2>().x;
        moveInputY = ctx.ReadValue<Vector2>().y;
    }

    public void plant(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canPlant==true)
        {
            Debug.Log("Planting");
            isPlanted = true;

            //plantingScript.Planted();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GoodFlower"))
        {
            other.gameObject.SetActive(false);
            numOfFlower1 = numOfFlower1 + 1;
            //score = score + 5;
            //scoreText.text = "Money: $" + score.ToString();
        }

        if (other.gameObject.CompareTag("GoodFlower2"))
        {
            other.gameObject.SetActive(false);
            numOfFlower2 = numOfFlower2 + 1;
            // score = score + 10;
            //scoreText.text = "Money: $" + score.ToString();
        }
        if (other.gameObject.CompareTag("Plant1"))
        {
            other.gameObject.SetActive(false);
            numOfFlower2 = numOfPlant1 + 1;
        }
        if (other.gameObject.CompareTag("Plant2"))
        {
            other.gameObject.SetActive(false);
            numOfPlant2 = numOfPlant2 + 1;
        }
        if (other.gameObject.CompareTag("Plant3"))
        {
            other.gameObject.SetActive(false);
            numOfPlant3 = numOfPlant3 + 1;
        }
        else if (other.gameObject.CompareTag("BadFlower"))
        {
            //die
            Debug.Log("You lose!");
            deathPanel.SetActive(true);
        }

        if (other.gameObject.CompareTag("Planter"))
        {
            canPlant = true;
        }
        else
        {
            canPlant = false;
        }

        if (other.gameObject.CompareTag("Money"))
        {

            score = score + (numOfFlower1 * 5) + (numOfFlower2 * 10) + (numOfPlant1 * 2) + (numOfPlant2 * 2) + (numOfPlant3);
            scoreText.text = "Money: $" + score.ToString();
        }
    }

    
}
