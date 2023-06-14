using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private ElevatorManager elevatorManager;
    [SerializeField] private ElevatorDown elevatorDown;
    [SerializeField] private pushables pushables;

    [SerializeField] private TextMeshProUGUI text;

    private int textToChange;

    // Update is called once per frame
    void Update()
    {
        GetNbToDisplay();
        ChangingText();
    }

    private void ChangingText()
    {
        text.text = textToChange.ToString();
    }

    private void GetNbToDisplay()
    {
        if (elevatorDown != null)
        {
            textToChange = elevatorDown.playersOnTop - elevatorDown.nOnTop;
            return;
        }

        if (elevatorManager != null)
        {
            textToChange =  elevatorManager.nPlayers - elevatorManager.nOnTop;
            return;
        }

        if (pushables != null)
        {
            textToChange = pushables.nTriggers - pushables.triggering;
            return;
        }
    }
}
