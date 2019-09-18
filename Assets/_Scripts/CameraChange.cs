﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{

    [Header("Game cameras")]
    [Space]


    [SerializeField] private Camera BedCamera;
    
    [SerializeField] private Camera PlayerCamera;
    

    [SerializeField] private TextMeshPro RMBInstruction;
    [SerializeField] private TextMeshPro LMBInstruction;

    [Header("Game UIs")]
    [Space]

    [SerializeField] private Canvas NormalUI;
    [SerializeField] private Canvas BedUI;

    [Header("Anxiety manager")]
    [Space]

    [SerializeField] private AnxietyManager manager;

    void Start()
    {
        if (!BedCamera || !PlayerCamera)
        {
            Debug.Log("CAMERA NOT SET PROPERLY FOR CAMERA CHANGER");
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            //keep the bed camera
            BedCamera.enabled = true;
            BedUI.enabled = true;

            PlayerCamera.enabled = false;
            NormalUI.enabled = false;

            //LMBInstruction = BedUI.transform.GetChild(0).GetComponent<TextMeshPro>();

            //RMBInstruction = BedUI.transform.GetChild(1).GetComponent<TextMeshPro>();
            //RMBInstruction =RMBInstruction. GetComponent<TextMeshPro>();
            //LMBInstruction =LMBInstruction. GetComponent<TextMeshPro>();
        }
    }

    private int PTSDCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (PTSDCount >= 1)
        {
            if (Input.GetMouseButtonDown(0) && !PlayerCamera.enabled)
            {
                //change camera
                BedCamera.enabled = false;
                BedUI.enabled = false;
                RMBInstruction.enabled = false;
                LMBInstruction.enabled = false;
                
                PlayerCamera.enabled = true;
                NormalUI.enabled = true;

            }

            if (Input.GetMouseButtonDown(1) && !PlayerCamera.enabled)
            {
                //34 so you can press up to 3 times
                manager.IncreaseAnxiety(40);
            }
        }

        if (Input.GetMouseButtonDown(0) && !PlayerCamera.enabled)
        {

            RMBInstruction.text = "Press right click to snooze...";
            LMBInstruction.fontSize = LMBInstruction.fontSize - 2;
            PTSDCount++;
        }


    }
}
