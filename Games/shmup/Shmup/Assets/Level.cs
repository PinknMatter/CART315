using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static Level instance;

    uint numDestructables = 0;
    bool startNextLevel = false;
    float nextLevelTimer = 3;

    string[] levels = { "Level1", "Level2" };
    int currentLevel = 1;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <= 0)
            {
                currentLevel++;
                if (currentLevel <= levels.Length)
                {
                    string sceneName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else
                {
                    Debug.Log("GAME OVER!!!");
                }
                nextLevelTimer = 3;
                startNextLevel = false;
            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }

    public void AddDestructable()
    {
        numDestructables++;
    }


    public void RemoveDestructable()
    {
        numDestructables--;

        if (numDestructables == 0)
        {
            startNextLevel = true;
        }

    }
}
