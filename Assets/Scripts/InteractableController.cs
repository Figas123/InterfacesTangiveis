using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractableController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Canvas;
    public GameObject PerguntaCanvas;
    public GameObject Resposta1Canvas;
    public GameObject Resposta2Canvas;
    public GameObject Resposta3Canvas;
    public GameObject Door;
    public GameObject DoorBonus;
    public Material Green;
    public Material Red;

    public bool Interactable = false;
    public bool Grupo1 = false;
    public string PerguntaGrupo1;
    public string Resposta1Grupo1;
    public string Resposta2Grupo1;
    public string Resposta3Grupo1;
    public bool Grupo2 = false;
    public string PerguntaGrupo2;
    public string Resposta1Grupo2;
    public string Resposta2Grupo2;
    public string Resposta3Grupo2;
    public bool Grupo3 = false;
    public string PerguntaGrupo3;
    public string Resposta1Grupo3;
    public string Resposta2Grupo3;
    public string Resposta3Grupo3;

    public GameObject LinesGrupo1;
    public GameObject LinesGrupo2;
    public GameObject LinesGrupo3;

    public enum SelectAnswer { None, First, Second, Third };

    public SelectAnswer myAnswer;
    public SelectAnswer theAnswer;
    public SelectAnswer theAnswerGrupo1;
    public SelectAnswer theAnswerGrupo2;
    public SelectAnswer theAnswerGrupo3;

    bool loop = true;

    void Start()
    {
        Canvas.SetActive(false);
        LinesGrupo1.SetActive(false);
        LinesGrupo2.SetActive(false);
        LinesGrupo3.SetActive(false);

        myAnswer = SelectAnswer.None;
    }

    void Update()
    {
        if (Grupo1)
        {
            PerguntaCanvas.GetComponent<Text>().text = PerguntaGrupo1;
            Resposta1Canvas.GetComponent<Text>().text = Resposta1Grupo1;
            Resposta2Canvas.GetComponent<Text>().text = Resposta2Grupo1;
            Resposta3Canvas.GetComponent<Text>().text = Resposta3Grupo1;
            theAnswer = theAnswerGrupo1;
        }
        else if (Grupo2)
        {
            PerguntaCanvas.GetComponent<Text>().text = PerguntaGrupo2;
            Resposta1Canvas.GetComponent<Text>().text = Resposta1Grupo2;
            Resposta2Canvas.GetComponent<Text>().text = Resposta2Grupo2;
            Resposta3Canvas.GetComponent<Text>().text = Resposta3Grupo2;
            theAnswer = theAnswerGrupo2;
        }
        else if (Grupo3)
        {
            PerguntaCanvas.GetComponent<Text>().text = PerguntaGrupo3;
            Resposta1Canvas.GetComponent<Text>().text = Resposta1Grupo3;
            Resposta2Canvas.GetComponent<Text>().text = Resposta2Grupo3;
            Resposta3Canvas.GetComponent<Text>().text = Resposta3Grupo3;
            theAnswer = theAnswerGrupo3;
        }

        if (Interactable && myAnswer == SelectAnswer.None)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Joystick1Button0)))
            {
                myAnswer = SelectAnswer.First;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) || (Input.GetKeyDown(KeyCode.Joystick1Button1)))
            {
                myAnswer = SelectAnswer.Second;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) || (Input.GetKeyDown(KeyCode.Joystick1Button2)))
            {
                myAnswer = SelectAnswer.Third;
            }
        }
        if (myAnswer != SelectAnswer.None)
        {
            gameObject.GetComponent<Animator>().SetBool("Open", true);
            Door.GetComponent<Animator>().SetBool("Open", true);
            if (myAnswer == theAnswer && loop == true)
            {
                loop = false;
                gameObject.GetComponentInChildren<MeshRenderer>().material = Green;
                DoorBonus.GetComponent<Animator>().SetBool("Open", true);
                gameManager.CorrectCounter++;
            }
            else if (myAnswer != theAnswer && loop == true)
                gameObject.GetComponentInChildren<MeshRenderer>().material = Red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Canvas.SetActive(true);
            if (Grupo1)
                LinesGrupo1.SetActive(true);
            else if (Grupo2)
                LinesGrupo2.SetActive(true);
            else if (Grupo3)
                LinesGrupo3.SetActive(true);
            Interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Canvas.SetActive(false);
            LinesGrupo1.SetActive(false);
            LinesGrupo2.SetActive(false);
            LinesGrupo3.SetActive(false);
            Interactable = false;
        }
    }
}
