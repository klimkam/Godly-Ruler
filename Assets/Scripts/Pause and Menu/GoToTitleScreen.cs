using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitleScreen : MonoBehaviour
{
    public void GoToTitleScreenButton()
    {
        SceneManager.LoadScene(2);
    }
}
