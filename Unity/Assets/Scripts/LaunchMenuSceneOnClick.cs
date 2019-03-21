using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchMenuSceneOnClick : MonoBehaviour
{
    public GameObject FirstObj;
    public GameObject SecondObj;

    public Transform FirstObjPos;
    public Transform SecondObjPos;

    public Transform Destination;

    public string SceneName;
    public float WaitBeforeLaunchScene;

    public bool IsClicked = false;

    private float firstMoveSpeed;
    private float secondMoveSpeed;

    private Animator firstAnim;
    private Animator secondAnim;

    private bool firstArrived = false;
    private bool secondArrived = false;

    private void Start()
    {
        if (FirstObjPos.position.x < 0)
            firstMoveSpeed = 2.0f;
        else
            firstMoveSpeed = -2.0f;

        if (SecondObjPos.position.x < 0)
            secondMoveSpeed = 2.0f;
        else
            secondMoveSpeed = -2.0f;

        firstAnim = FirstObj.GetComponent<Animator>();
        secondAnim = SecondObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            IsClicked = true;

        if (IsClicked)
        {
            firstAnim.runtimeAnimatorController = Resources.Load("Animator" + FirstObj.name.ToString() + "Run") as RuntimeAnimatorController;
            secondAnim.runtimeAnimatorController = Resources.Load("Animator" + SecondObj.name.ToString() + "Run") as RuntimeAnimatorController;

            if (Mathf.Abs(FirstObjPos.position.x - Destination.position.x) > 0.1)
                FirstObj.GetComponent<Rigidbody2D>().velocity = new Vector2(firstMoveSpeed, 0);
            else
                firstArrived = true;
            if (Mathf.Abs(SecondObjPos.position.x - Destination.position.x) > 0.1)
                SecondObj.GetComponent<Rigidbody2D>().velocity = new Vector2(secondMoveSpeed, 0);
            else
                secondArrived = true;

            if (firstArrived && secondArrived)
            {
                FirstObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                SecondObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                firstAnim.runtimeAnimatorController = Resources.Load("Animator" + FirstObj.name.ToString() + "Idle") as RuntimeAnimatorController;
                secondAnim.runtimeAnimatorController = Resources.Load("Animator" + SecondObj.name.ToString() + "Idle") as RuntimeAnimatorController;
                StartCoroutine(LaunchNextSceneAfterPause());
            }
        }

    }

    private IEnumerator LaunchNextSceneAfterPause()
    {
        yield return new WaitForSeconds(WaitBeforeLaunchScene);
        SceneManager.LoadScene(SceneName);
    }
}