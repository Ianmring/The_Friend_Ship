using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenu : MonoBehaviour
{
public void StartGame() {
        Application.LoadLevel(1);
    }

    public void Exit() {
        Application.Quit();
    }
}
