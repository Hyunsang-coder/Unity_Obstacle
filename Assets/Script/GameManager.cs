using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text playtimeTxt;
    public Text hitsCountTxt;
    public Text yourRecordTxt;
    float playTime = 0;
    int hitsCount = 0;

    public GameObject player;
    public GameObject playScreen;
    public GameObject endScreen;
    public GameObject readyScreen;
    public GameObject goScreen;
    PlayerMove playerMove;

    
    public void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();

        playerMove.isEnd = false;
        endScreen.SetActive(false);
    }

    private void Update()
    {
        
        
        // Time.time은 누적 시간 초기화 불가 
        if ((playerMove.isEnd == false) && (playerMove.isControl == true)) 
        {
            readyScreen.SetActive(false);
            playTime += Time.deltaTime;
            playScreen.SetActive(true);
        }

        if (playerMove.isEnd == true)
        {
            GameOver();
        }

        

        Quit();
    }


    public void ReStart()
    {
        
        SceneManager.LoadScene(1);

    }

    public void GameOver()
    {
        playScreen.SetActive(false);
        endScreen.SetActive(true);
        playerMove.isControl = false;

    }

    
    private void LateUpdate()
    {
        hitsCount = playerMove.hits;

        playtimeTxt.text = "Play Time: " + playTime.ToString("N2");
        hitsCountTxt.text = "Hit Count: " + hitsCount.ToString();
        yourRecordTxt.text = "You finished at " + playTime.ToString("N2") + " seconds with " + hitsCount.ToString() + " hit(s)";

        
    }

    
    private void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
