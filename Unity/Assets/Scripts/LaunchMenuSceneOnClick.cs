using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchMenuSceneOnClick : MonoBehaviour
{
    public GameObject Moving;

    public Transform pos;
    public Transform destination;

    private float moveSpeed;
    private Animator Anim;
    private bool isClicked = false;

    private void Start()
    {
        if (pos.position.x < 0)
            moveSpeed = 2.0f;
        else
            moveSpeed = -2.0f;
        Anim = Moving.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Anim.runtimeAnimatorController = Resources.Load("Animator" + Moving.name.ToString() + "Run") as RuntimeAnimatorController;
            isClicked = true;
        }

        if (isClicked)
        {
            if (Mathf.Abs(pos.position.x - destination.position.x) > 0.1)
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                Anim.runtimeAnimatorController = Resources.Load("Animator" + Moving.name.ToString() + "Idle") as RuntimeAnimatorController;
                StartCoroutine(LaunchNextSceneAfterPause());
            }
        }

    }

    private IEnumerator LaunchNextSceneAfterPause()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("Menu");
    }
}