using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutsceneScript : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    //public GameObject text5;
    public float sec = 5f;
    public string NewLevel = "Level1";
    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        //text5.SetActive(false);
        StartCoroutine(LoadLevelAfterDelay());
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(NewLevel);
        }
    }
    IEnumerator LoadLevelAfterDelay()
    {
        text1.SetActive(true);
        yield return new WaitForSeconds(sec);
        text1.SetActive(false);
        text2.SetActive(true);
        yield return new WaitForSeconds(sec);
        text2.SetActive(false);
        text3.SetActive(true);
        yield return new WaitForSeconds(sec);
        text3.SetActive(false);
        text4.SetActive(true);
        yield return new WaitForSeconds(sec);
        text4.SetActive(false);
        //text5.SetActive(true);
        //yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(NewLevel);
    }


}
