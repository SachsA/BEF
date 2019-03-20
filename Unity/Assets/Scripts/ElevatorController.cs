using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    public Transform topPosition;

    public Transform highPosition;
    public Transform lowPosition;

    public GameObject lever;

    public float moveSpeed;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if (lever.GetComponent<Lever_Activation>().leverPosition > 0 && topPosition.position.y < highPosition.position.y)
        {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveSpeed);
        } else if (lever.GetComponent<Lever_Activation>().leverPosition < 0 && topPosition.position.y > lowPosition.position.y)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
