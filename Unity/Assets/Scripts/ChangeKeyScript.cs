using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ChangeKeyScript : MonoBehaviour
{

    Transform keyboardMenuPanel;
    Event keyEvent;
    TextMeshProUGUI buttonText;
    KeyCode key;

    bool waitingForKey;

    void Start()
    {
        keyboardMenuPanel = transform.Find("KeyboardMenu");
        waitingForKey = false;

        for (int i = 0; i < keyboardMenuPanel.childCount; i++)
        {
            if (keyboardMenuPanel.GetChild(i).name == "Forward")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Forward.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "Backward")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Backward.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "Left")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Left.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "Right")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Right.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "Ability")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Ability.ToString();
        }
    }

    void OnGUI()
    {
        keyEvent = Event.current;

        if (keyEvent.isKey && waitingForKey)
        {
            key = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void sendText(TextMeshProUGUI text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey(string name)
    {
        waitingForKey = true;

        yield return WaitForKey();

        switch(name)
        {
            case "forward":
                GameManager.GM.Forward = key;
                buttonText.text = GameManager.GM.Forward.ToString();
                PlayerPrefs.SetString("forward", GameManager.GM.Forward.ToString());
                break;
            case "backward":
                GameManager.GM.Backward = key;
                buttonText.text = GameManager.GM.Backward.ToString();
                PlayerPrefs.SetString("backward", GameManager.GM.Backward.ToString());
                break;
            case "left":
                GameManager.GM.Left = key;
                buttonText.text = GameManager.GM.Left.ToString();
                PlayerPrefs.SetString("left", GameManager.GM.Left.ToString());
                break;
            case "right":
                GameManager.GM.Right = key;
                buttonText.text = GameManager.GM.Right.ToString();
                PlayerPrefs.SetString("right", GameManager.GM.Right.ToString());
                break;
            case "ability":
                GameManager.GM.Ability = key;
                buttonText.text = GameManager.GM.Ability.ToString();
                PlayerPrefs.SetString("ability", GameManager.GM.Ability.ToString());
                break;
        }
        yield return null;
    }

}