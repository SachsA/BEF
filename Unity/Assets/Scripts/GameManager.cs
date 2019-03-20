using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager GM;

    public KeyCode PlayerOneForward { get; set; }
    public KeyCode PlayerOneBackward { get; set; }
    public KeyCode PlayerOneAbility { get; set; }

    public KeyCode PlayerTwoForward { get; set; }
    public KeyCode PlayerTwoBackward { get; set; }
    public KeyCode PlayerTwoAbility { get; set; }
    public KeyCode PlayerTwoInteract { get; set; }

    private void Awake()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }

        PlayerOneForward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerOneForward", "D"));
        PlayerOneBackward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerOneBackward", "Q"));
        PlayerOneAbility = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerOneAbility", "E"));

        PlayerTwoForward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerTwoForward", "M"));
        PlayerTwoBackward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerTwoBackward", "K"));
        PlayerTwoAbility = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerTwoAbility", "P"));
        PlayerTwoInteract = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerTwoInteract", "O"));
    }

}
