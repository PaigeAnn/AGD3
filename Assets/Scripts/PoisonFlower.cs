using UnityEngine;

public class PoisonFlower : MonoBehaviour
{
    public PlayerController playerScript;
    public bool isPoisoned = false;
    private void OnEnable()
    {
        Randomize();
    }
    public void Randomize()
    {
        int randomNum = Random.Range(0, 100);
        if (randomNum < 20)
        {
            Debug.Log("The plant is poisoned!");
                isPoisoned = true;
            Color newColor = new Color(1f, 0.8f, 0.55f); 
            GetComponent<SpriteRenderer>().color = newColor;
        }
        else
        {
            Debug.Log("The plant is safe.");
                isPoisoned = false;
            Color newColor = new Color(1f, 1f, 1f);//white color

            GetComponent<SpriteRenderer>().color = newColor;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Randomize();
            if (isPoisoned==true)
            {
                playerScript.deathPanel.SetActive(true);
            }
        }
    }
}
