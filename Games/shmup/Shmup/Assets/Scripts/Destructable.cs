using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;
    public int scoreValue = 10;


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
                Level.instance.AddScore(scoreValue);
                Destroy(gameObject);
                Destroy(bullet.gameObject);

            }

        }
    }



    private void OnDestroy()
    {
        Level.instance.RemoveDestructable();
    }
}
