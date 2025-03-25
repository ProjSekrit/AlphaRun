using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{



    public GameObject Panel;
    public void StartButton()
    {
        Panel.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
