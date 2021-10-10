using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Cinemachine;


using UnityEngine;

public class ShrineCollider : MonoBehaviour
{
    public GameObject finishpoint;
    public string LevelNext = "";

    public CinemachineVirtualCamera vcam;
    public float zoomOut = 20f;
    public float Default = 10f;

    public GameObject light;

    void Start()
    {
        light.SetActive(false);
        vcam.m_Lens.OrthographicSize = Default;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lantern") {
            collision.gameObject.transform.position = finishpoint.transform.position;
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel() {
        vcam.m_Lens.OrthographicSize = zoomOut;
        light.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(LevelNext);
    }
}
