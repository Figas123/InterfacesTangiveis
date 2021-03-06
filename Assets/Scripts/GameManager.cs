﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Interactables = new GameObject[5];
    public Text textItems;
    public Text textCorrect;
    public int ItemCounter;
    public int CorrectCounter;

    void Start()
    {
        for (int i = 0; i < Interactables.Length; i++)
        {
            int r = Random.Range(0, 3);
            
            if (r == 0)
            {
                Interactables[i].GetComponent<InteractableController>().Grupo1 = true;
                Interactables[i].GetComponent<InteractableController>().Grupo2 = false;
                Interactables[i].GetComponent<InteractableController>().Grupo3 = false;
            }
            if (r == 1)
            {
                Interactables[i].GetComponent<InteractableController>().Grupo1 = false;
                Interactables[i].GetComponent<InteractableController>().Grupo2 = true;
                Interactables[i].GetComponent<InteractableController>().Grupo3 = false;
            }
            if (r == 2)
            {
                Interactables[i].GetComponent<InteractableController>().Grupo1 = false;
                Interactables[i].GetComponent<InteractableController>().Grupo2 = false;
                Interactables[i].GetComponent<InteractableController>().Grupo3 = true;
            }
        }
    }

    void Update()
    {
        textItems.GetComponent<Text>().text = ItemCounter.ToString();
        textCorrect.GetComponent<Text>().text = CorrectCounter.ToString();
    }
}
