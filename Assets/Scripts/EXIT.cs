using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EXIT : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject MainCanvas;
    public GameObject ExitCanvas;
    public Text Text;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<CharacterController>().enabled = false;
            MainCanvas.SetActive(false);
            ExitCanvas.SetActive(true);
            if (gameManager.CorrectCounter > 0 && gameManager.ItemCounter > 0)
                Text.text = $"Encontraste a Saida!\n\nAcertaste {gameManager.CorrectCounter} perguntas e apanhaste {gameManager.ItemCounter} reliquias perdidas!";
            else if (gameManager.CorrectCounter > 0 && gameManager.ItemCounter == 0)
                Text.text = $"Encontraste a Saida!\n\nAcertaste {gameManager.CorrectCounter} perguntas mas não apanhaste nenhuma reliquia...\nDevias explorar melhor o templo!";
            else if (gameManager.CorrectCounter == 0)
                Text.text = $"Encontraste a Saida!\n\nFalhaste todas as perguntas, felizmente conseguiste encontrar a saida mesmo assim!";
        }
    }
}
