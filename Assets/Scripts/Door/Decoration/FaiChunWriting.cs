using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaiChunWriting : MonoBehaviour
{
    public Camera cam;
    public Camera panoramic;
    public GameObject brush;
    //public GameObject brush2;

    LineRenderer currentLineRenderer;
    //LineRenderer mappingLineRenderer;

    Vector2 lastPos;
    Touch touch;
    Vector2 touchPos;
    //Vector2 mappingPos;

    public Button done;

    void Start()
    {
        done.onClick.AddListener(Done);
    }

    private void Update()
    {
        if (StateNameController.FuWriting == true)
        {
            done.gameObject.SetActive(true);
            Drawing();
        }
    }

    void Drawing()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Destroy(hit.collider.gameObject);
                touchPos = cam.ScreenToWorldPoint(touch.position);
                if (touch.phase == TouchPhase.Began)
                {
                    CreateBrush();
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    PointToMousePos();
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    currentLineRenderer = null;
                }
            }
            //mappingPos = new Vector2(touchPos.x / 8 + 10, touchPos.y / 8 + 10);
            //StateNameController.CanMove = false;
            
        }
        else
        {
            currentLineRenderer = null;
            //StateNameController.CanMove = true;
        }
    }

    void CreateBrush()
    {
        //for main screen
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        currentLineRenderer.SetPosition(0, touchPos);
        currentLineRenderer.SetPosition(1, touchPos);

        //for picture on the wall
        /*
        GameObject brushInstance2 = Instantiate(brush2);
        mappingLineRenderer = brushInstance2.GetComponent<LineRenderer>();
        mappingLineRenderer.SetPosition(0, mappingPos);
        mappingLineRenderer.SetPosition(1, mappingPos);
        */

    }

    void AddAPoint(Vector2 pointPos)
    {
        //main screen
        int positionIndex = currentLineRenderer.positionCount;
        currentLineRenderer.positionCount++;
        currentLineRenderer.SetPosition(positionIndex, pointPos);

        //display on the wall
        /*
        int positionIndex2 = mappingLineRenderer.positionCount;
        mappingLineRenderer.positionCount++;
        mappingLineRenderer.SetPosition(positionIndex2, pointPos2);
        */
    }

    void PointToMousePos()
    {
        //Vector2 touchPos = cam.ScreenToWorldPoint(touch.position);
        if (lastPos != touchPos)
        {
            AddAPoint(touchPos);
            lastPos = touchPos;
        }
    }

    void Done()
    {
        StateNameController.FuWriting = false;
        done.gameObject.SetActive(false);
        panoramic.gameObject.SetActive(true);
        StateNameController.DoorDialogue2 = true;
    }
}
