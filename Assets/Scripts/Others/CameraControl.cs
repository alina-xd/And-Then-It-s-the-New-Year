using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject WallCam;
    public GameObject WindowCam;

    public Button main;
    public Button wall;
    public Button window;

    //bool active;

    public GameObject buttons;
    public GameObject zoomout;
    
    void Start()
    {
        MainCam.SetActive(true);
        WallCam.SetActive(false);
        WindowCam.SetActive(false);
        buttons.SetActive(true);
        zoomout.SetActive(false);
        main.onClick.AddListener(ZoomOut);
        wall.onClick.AddListener(ZoomInWall);
        window.onClick.AddListener(ZoomInWindow);
    }

    void ZoomOut()
    {
        MainCam.SetActive(true);
        WallCam.SetActive(false);
        WindowCam.SetActive(false);
        buttons.SetActive(true);
        zoomout.SetActive(false);
        StateNameController.CleanWall = false;
        StateNameController.CleanWindow = false;
    }

    void ZoomInWall()
    {
        if (StateNameController.CleaningEnd == false && StateNameController.LivingRoomDialogue1Started == true)
        {
            StateNameController.CleanWall = true;
            MainCam.SetActive(false);
            WallCam.SetActive(true);
            WindowCam.SetActive(false);
            buttons.SetActive(false);
            zoomout.SetActive(true);
        }
    }

    void ZoomInWindow()
    {
        if (StateNameController.CleaningEnd == false && StateNameController.LivingRoomDialogue1Started == true)
        {
            StateNameController.CleanWindow = true;
            MainCam.SetActive(false);
            WallCam.SetActive(false);
            WindowCam.SetActive(true);
            buttons.SetActive(false);
            zoomout.SetActive(true);
        }
    }

    //public void SwitchCamera()
    //{
    //    Cam.SetActive(true);
    //    MainCam.SetActive(false);
    //    active = true;
    //    Debug.Log(active);
    //}

    //public void SwitchToMain()
    //{
    //    Cam.SetActive(false) ;
    //    MainCam.SetActive(true) ;
    //    active = false;
    //    Debug.Log(active);
    //}
}
