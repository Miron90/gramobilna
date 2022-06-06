using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayableGameMap : MonoBehaviour
{
    public GameObject door;
    public GameObject player;
    public bool gameOver = false;
    private void Awake()
    {
        
    }
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies.Length <= 0&&!gameOver)
        {
            door.GetComponent<Animation>().Play();
            door.GetComponent<BoxCollider>().size = new Vector3(0,0,0);
            gameOver = true;
        }
        if (player.transform.position.z - 34.25 > 2.37 && gameOver)
        {
            //todo dodaj golda;
            SceneManager.LoadScene(0);
        }
    }
}
