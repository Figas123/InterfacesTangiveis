using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public GameObject Item;
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Item.SetActive(false);
            gameManager.ItemCounter++;
        }
    }
}
