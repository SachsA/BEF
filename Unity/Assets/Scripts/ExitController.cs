using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitController : MonoBehaviour
{
    List<Collider2D> collidedObjects = new List<Collider2D>();

    public string nextLevel;

    void FixedUpdate()
    {
        int numberOfColliders = collidedObjects.Count; // this should give you the number you need
        Debug.Log(numberOfColliders);
        if (numberOfColliders >= 2)
        {
            SceneManager.LoadScene(nextLevel);

        }
        collidedObjects.Clear(); //clear the list of all tracked objects.
    }


    // if there is collision with an object in either Enter or Stay, add them to the list 
    // (you can check if it already exists in the list to avoid double entries, 
    // just in case, as well as the tag).

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("touché");
        if (!collidedObjects.Contains(col.collider) && col.collider.tag == "Players")
        {
            collidedObjects.Add(col.collider);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        OnCollisionEnter2D(col); //same as enter
    }



/*    void Update()
    {
        int numberOfColliders = collidedObjects.Count; // this should give you the number you need
        Debug.Log(numberOfColliders);

        collidedObjects.Clear(); // You can also clear the list here
    }*/
}
