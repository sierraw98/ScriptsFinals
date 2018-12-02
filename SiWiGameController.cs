using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SiWiGameController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public Text GameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    private bool gameOn;
    

    void Start()
    {
       
        StartCoroutine(SpawnWaves());

        gameOn = true;
        
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
        if (player == null)
        {
            gameOver = true;
            GameOverText.text = "YOU COULDN'T SAVE THE BEES!!!!";
            gameOn = false;

        }
 

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 180f);
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            

            if (gameOver==true)
            {
                Application.Quit();
                break;
                
            }

            
            }
   
    }
    


}
