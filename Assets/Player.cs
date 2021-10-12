using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public Text ScoreText;
    private float scoreValue;
    public float totalcoins;
    public Text Timetext;
    private float TimerValue;
    public float timeleft;
    public int timeRemaining;
    public GameObject Effects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeleft % 60);
        Timetext.text = "Timer: " + timeRemaining.ToString();

        if (scoreValue == totalcoins)
        {
            if (timeleft <= TimerValue)
            {
                SceneManager.LoadScene("GameWinScene");
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
            }
        }
        else if (timeleft <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            scoreValue += 10;
            ScoreText.text = "Score: " + scoreValue;
            Destroy(other.gameObject);
            Destroy(Instantiate(Effects, other.transform.position, Quaternion.identity), 5);
        }
        if(other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
        }
    }
}
