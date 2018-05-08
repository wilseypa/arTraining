using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMenuControl : MonoBehaviour {
    Vector3 distanceMag;

    GameObject target;
    GameObject MenuBackground;
    GameObject MenuCollection;
    GameObject LessonButton;
    GameObject ExitButton;

    GameObject LessonMenu;

    int childIndex;
    public Renderer rend;
    public Collider MenuCollider;
    //private Text 
    public Canvas CanvasText; 

    public bool isMenuDisplayed = true;
    public bool Main_Menu_Up = true;
    public bool Lesson_Menu_Up = false;

    // Use this for initialization
    void Start () {
        distanceMag = this.transform.position;
        MenuCollection = this.transform.Find("Collection").gameObject;
        MenuBackground = (this.transform.Find("Collection").gameObject).transform.Find("Main_Menu_Background").gameObject;
        //LessonButton = this.transform.Find("Collection").gameObject.transform.Find("Lesson_Button").gameObject;
        //ExitButton = this.transform.Find("Collection").gameObject.transform.Find("Exit_Button").gameObject;

        LessonMenu = this.transform.Find("Collection").gameObject.transform.Find("Lesson_Menu_Background").gameObject;
        //LessonMenu.transform.position = new Vector3(0f, .448f, -.439f);
        //Debug.Log(MenuBackground.transform.name, this);

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            if (isMenuDisplayed)
            {
                if (Main_Menu_Up)
                {
                    MainMenuDisplay(false);                  
                } else if (Lesson_Menu_Up)
                {
                    LessonMenuDisplay(false);
                }
                isMenuDisplayed = false;
            }
            else
            {
                if (Main_Menu_Up)
                {
                    MainMenuDisplay(true);

                }
                else if (Lesson_Menu_Up)
                {
                    LessonMenuDisplay(true);
                }
                isMenuDisplayed = true;
            }
        }

        if (!isMenuDisplayed)
        {
            positionAndOrientation();
        }

        //Debug.Log("Pos: " + this.transform.position, this);
    }

    void MainMenuDisplay(bool input)
    {
        GameObjectDisplay(MenuBackground, input);
    }

    void MainMenuBool()
    {
        Main_Menu_Up = true;
        Lesson_Menu_Up = false;
    }

    void LessonMenuBool()
    {
        Main_Menu_Up = false;
        Lesson_Menu_Up = true;
    }

    void LessonMenuDisplay(bool input)
    {
        GameObjectDisplay(LessonMenu, input);
    }

    // Recursevly turns off or on Mesh Renders, Canvases, and Mesh Colliders
    void GameObjectDisplay(GameObject gameObjectIn, bool input)
    {
        //Debug.Log(gameObjectIn.transform.name + " " + gameObjectIn.transform.childCount, this);
        if (gameObjectIn.transform.childCount > 0)
        {
            for (int i = 0; i < gameObjectIn.transform.childCount; i++)
            {
                GameObjectDisplay(gameObjectIn.transform.GetChild(i).gameObject, input);
            }

        }

        if (gameObjectIn.transform.name == "Button")
        {
            rend = gameObjectIn.GetComponent<Renderer>();
            rend.enabled = input;

            MenuCollider = gameObjectIn.GetComponent<Collider>();
            MenuCollider.enabled = input;
        } else if (gameObjectIn.transform.name == "Indent")
        {
            rend = gameObjectIn.GetComponent<Renderer>();
            rend.enabled = input;

            MenuCollider = gameObjectIn.GetComponent<Collider>();
            MenuCollider.enabled = input;
        }
        else if (gameObjectIn.transform.name == "Background")
        {
            rend = gameObjectIn.GetComponent<Renderer>();
            rend.enabled = input;

            MenuCollider = gameObjectIn.GetComponent<Collider>();
            MenuCollider.enabled = input;
        }
        else if (gameObjectIn.transform.name == "Canvas")
        {
            CanvasText = gameObjectIn.GetComponent<Canvas>();
            CanvasText.enabled = input;
        }
        return;
    }

    void positionAndOrientation()
    {
        this.transform.position = Camera.main.transform.forward * distanceMag.magnitude;
        Vector3 targetPosition = new Vector3(Camera.main.transform.position.x,
                                                this.transform.position.y,
                                                Camera.main.transform.position.y);
        this.transform.LookAt(2 * this.transform.position - targetPosition);
    }
}
