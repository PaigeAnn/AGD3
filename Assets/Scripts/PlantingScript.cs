using System.Collections;
using UnityEngine;

public class PlantingScript : MonoBehaviour
{
    public GameObject plant;
    public PlayerController playerScript;

    public PoisonFlower poisonFlower;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("PlantingScript Start");
        //StartCoroutine(Planted());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Planted()
    {
        if (playerScript.isPlanted == true && playerScript.canPlant == true)
        {
            Debug.Log("Planted");
            StartCoroutine(Planter());

        }
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.canPlant = true;
            Planted();
        }
        else
        {
            playerScript.canPlant = false;
        }
    }
    
    IEnumerator Planter()
    {
        yield return new WaitForSeconds(5f);
        plant.SetActive(true);
        playerScript.isPlanted = false;
        playerScript.canPlant = false;
        yield return new WaitForSeconds(15f);
        if (plant.activeInHierarchy)
        {
            plant.SetActive(false);
        }
    }
}
