using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Level.instance != null)
        {
            Level.instance.AddDestructable();
        }
        else
        {
            Debug.LogError("Level.instance is not set. Make sure Level script is loaded before Destructable objects try to access it.");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < 17f && !canBeDestroyed)
        {
            canBeDestroyed = true;
            Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
                gun.autoShoot = true;
            }
        }
    }

    /// <summary>   
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!canBeDestroyed)
        {
            return;
        }
        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);

            }

        }
    }


    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    private void OnDestroy()
    {
        Level.instance.RemoveDestructable();
    }
}
