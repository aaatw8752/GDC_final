using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class maincontorler : MonoBehaviour
{
    public GameObject player;
    public GameObject sing;
    public GameObject scene;
    public GameObject bullet;
    public GameObject Blackbackground;

    private GameObject currentScene;
    private GameObject currentspawnPoint;
    private GameObject currentBoxfloder;
    private GameObject currentTurretcontorl;
    private GameObject flag;
    private int sceneIndex = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Go to the first Scene when the game starts;
        currentScene = scene.transform.GetChild(sceneIndex).gameObject;

        Vector3 nowposition = currentScene.transform.position;

        sing.transform.position = new Vector3(nowposition.x, nowposition.y, -10);

        currentspawnPoint = currentScene.transform.Find("spawnpoint").gameObject;

        currentBoxfloder = currentScene.transform.Find("boxfloder").gameObject;

        // Set the first endPoint;
        flag = scene.transform.GetChild(0).Find("flag").gameObject;

        //Debug.Log("currentScene: " + currentScene.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            reset();
        }

        if(Manager.dead)
        {
            Debug.Log("Player hit by bullet, resetting level.");
            playerDead();
            Manager.dead = false;
        }

        if (Manager.reset)
        {
            reset();
        }

        if(Manager.is_reset)
        {
            Time.timeScale = 1f;
            Manager.is_reset = false;
        }

        if (flag.GetComponent<flagcorn>().isEnd) //To turn to next scene;
        {
            completeTheLeve();
        }
    }

    private void completeTheLeve() // To turn to next scene(need to update new Spawnpoint , Boxfolder, and Flag);
    {
        if (sceneIndex < scene.transform.childCount - 1)
        {
            if(currentScene.transform.Find("turretcontorl") != null)
            {
                currentTurretcontorl = currentScene.transform.Find("turretcontorl").gameObject;

                for (int i = 0; i < currentTurretcontorl.transform.childCount; i++)
                {
                    currentTurretcontorl.transform.GetChild(i).GetComponent<turretcorn>().wakeUp = false;
                }
            }

            for (int i = 0; i < currentBoxfloder.transform.childCount; i++)
            {
                currentBoxfloder.transform.GetChild(i).GetComponent<boxcorn>().ResetBox();
            }

            sceneIndex++;
            currentScene = scene.transform.GetChild(sceneIndex).gameObject;

            Vector3 nowposition = currentScene.transform.position;

            sing.transform.position = new Vector3(nowposition.x, nowposition.y, -10);

            currentspawnPoint = currentScene.transform.Find("spawnpoint").gameObject;

            currentBoxfloder = currentScene.transform.Find("boxfloder").gameObject;

            flag = currentScene.transform.Find("flag").gameObject;

            if (currentScene.transform.Find("turretcontorl") != null)
            {
                currentTurretcontorl = currentScene.transform.Find("turretcontorl").gameObject;

                for (int i = 0; i < currentTurretcontorl.transform.childCount; i++)
                {
                    currentTurretcontorl.transform.GetChild(i).GetComponent<turretcorn>().wakeUp = true;
                }
            }
            else
            {
                Debug.Log("No turret in this scene");
            }

            player.transform.position = currentspawnPoint.transform.position;
        }
        else
        {
            //end of the game;
            Time.timeScale = 0f;
            Debug.Log("Game Over");
        }

        flag.GetComponent<flagcorn>().isEnd = false;
    }

    private void reset()
    {
        Debug.Log("reset");
        player.transform.position = currentspawnPoint.transform.position;

        for (int i = 0; i < currentBoxfloder.transform.childCount; i++)
        {
            currentBoxfloder.transform.GetChild(i).GetComponent<boxcorn>().ResetBox();
        }
        if(currentScene.transform.Find("turret") != null)
        {
            currentScene.transform.Find("turret").GetComponent<turretcorn>().fireTime = 0;
        }
        Manager.is_shoot = true;
        Manager.dead = false;
        Manager.reset = false;
    }

    private void playerDead()
    {
        Time.timeScale = 0f;

        Instantiate(Blackbackground, sing.transform.position + new Vector3(0, 20, 9), Quaternion.identity);

    }
}
