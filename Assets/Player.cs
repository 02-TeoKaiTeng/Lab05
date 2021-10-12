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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            scoreValue += 10;
            ScoreText.text = "Score: " + scoreValue;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
        }
    }
}
