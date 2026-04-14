using System.Collections;
using UnityEngine;

public class PlantingScript : MonoBehaviour
{
    public GameObject plant;
    public PlayerController playerScript;

    public bool coroutineDone= false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("PlantingScript Start");
        //StartCoroutine(Planted());
    }

    // Update is called once per frame
    void Update()
    {
        Planted();
    }

    public void Planted()
    {
        if (playerScript.isPlanted == true && playerScript.canPlant == true)
        {
            Debug.Log("Planted");
          //  StartCoroutine(time());

        //    if (coroutineDone == true)
         //   {
                Debug.Log("Plant Instantiated");
                Instantiate(plant, transform.position, Quaternion.identity);

                playerScript.isPlanted = false;
                playerScript.canPlant = false;
           // }
        }
        coroutineDone = false;
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(5f);
        coroutineDone = true;
    }
}
