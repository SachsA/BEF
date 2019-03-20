using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeKeyScript : MonoBehaviour
{
    private Transform keyboardMenuPanel;
    private Event keyEvent;
    private TextMeshProUGUI buttonText;
    private KeyCode key;
    private bool waitingForKey;

    private void Start()
    {
        keyboardMenuPanel = transform.Find("KeyboardMenu");
        waitingForKey = false;

        for (int i = 0; i < keyboardMenuPanel.childCount; i++)
        {
            if (keyboardMenuPanel.GetChild(i).name == "PlayerOneForward")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.PlayerOneForward.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "PlayerOneBackward")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.PlayerOneBackward.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "PlayerOneAbility")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.PlayerOneAbility.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "PlayerTwoForward")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.PlayerTwoForward.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "PlayerTwoBackward")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.PlayerTwoBackward.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "PlayerTwoAbility")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.PlayerTwoAbility.ToString();
            else if (keyboardMenuPanel.GetChild(i).name == "PlayerTwoInteract")
                keyboardMenuPanel.GetChild(i).GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.PlayerTwoInteract.ToString();
        }
    }

    private void OnGUI()
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

    private IEnumerator WaitForKey()
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

        switch (name)
        {
            case "PlayerOneForward":
                GameManager.GM.PlayerOneForward = key;
                buttonText.text = GameManager.GM.PlayerOneForward.ToString();
                PlayerPrefs.SetString("PlayerOneForward", GameManager.GM.PlayerOneForward.ToString());
                break;
            case "PlayerOneBackward":
                GameManager.GM.PlayerOneBackward = key;
                buttonText.text = GameManager.GM.PlayerOneBackward.ToString();
                PlayerPrefs.SetString("PlayerOneBackward", GameManager.GM.PlayerOneBackward.ToString());
                break;
            case "PlayerOneAbility":
                GameManager.GM.PlayerOneAbility = key;
                buttonText.text = GameManager.GM.PlayerOneAbility.ToString();
                PlayerPrefs.SetString("PlayerOneAbility", GameManager.GM.PlayerOneAbility.ToString());
                break;
            case "PlayerTwoForward":
                GameManager.GM.PlayerTwoForward = key;
                buttonText.text = GameManager.GM.PlayerTwoForward.ToString();
                PlayerPrefs.SetString("PlayerTwoForward", GameManager.GM.PlayerTwoForward.ToString());
                break;
            case "PlayerTwoBackward":
                GameManager.GM.PlayerTwoBackward = key;
                buttonText.text = GameManager.GM.PlayerTwoBackward.ToString();
                PlayerPrefs.SetString("PlayerTwoBackward", GameManager.GM.PlayerTwoBackward.ToString());
                break;
            case "PlayerTwoAbility":
                GameManager.GM.PlayerTwoAbility = key;
                buttonText.text = GameManager.GM.PlayerTwoAbility.ToString();
                PlayerPrefs.SetString("PlayerTwoAbility", GameManager.GM.PlayerTwoAbility.ToString());
                break;
            case "PlayerTwoInteract":
                GameManager.GM.PlayerTwoInteract = key;
                buttonText.text = GameManager.GM.PlayerTwoInteract.ToString();
                PlayerPrefs.SetString("PlayerTwoInteract", GameManager.GM.PlayerTwoInteract.ToString());
                break;
        }
        yield return null;
    }

}