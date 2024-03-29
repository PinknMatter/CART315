using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BedController : MonoBehaviour

{

    public float xLoc = 0;
    public float yLoc = 0;
    public SpriteRenderer sr;
    // Start is called before the first frame update

    public float score;
    void Start()
    {
        score = 0;
        sr = this.GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && xLoc > -9f)
        {
            xLoc -= .01f;
        }

        if (Input.GetKey(KeyCode.X) && xLoc < 9f)
        {
            xLoc += .01f;
        }

        this.transform.position = new Vector3(xLoc, transform.position.y, transform.position.z);



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Sleepy")
        {
            score += 1;
        }
        else score -= 1;

        Destroy(other.gameObject);
        Debug.Log(other.gameObject.name);
    }

}
