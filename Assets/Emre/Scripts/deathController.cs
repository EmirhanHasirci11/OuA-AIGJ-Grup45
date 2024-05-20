using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathController : MonoBehaviour
{
    private int hitCount = 0;
    public int heal = 5;
    private float defaultTimeScale;
    private void Start()
    {
        defaultTimeScale = Time.timeScale;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            hitCount++; 
            Debug.Log(hitCount);
            
            if (hitCount == heal)
            {
                Debug.Log("2. if");
                
                GetComponent<Animator>().SetTrigger("death");

                Invoke("StopTime", 5f);
                Invoke("ReloadScene", 8f);
            }
        }
        else if (collision.gameObject.tag == "bullet2")
        {
            hitCount += 2;

            if (hitCount >= heal)
            {
                GetComponent<Animator>().SetTrigger("death");

                Invoke("StopTime", 5f);
                Invoke("ReloadScene", 8f);
            }
        }
        else if (collision.gameObject.tag == "bullet3")
        {
            hitCount += 5; ;

            if (hitCount == heal)
            {
                GetComponent<Animator>().SetTrigger("death");

                Invoke("StopTime", 5f);
                Invoke("ReloadScene", 8f);
            }
        }
    }

    void StopTime()
    {
        Debug.Log("stopTimeee");
        Time.timeScale = 0.5f;
    }

    void ReloadScene()
    {
        Debug.Log("Reloaddd");
        Time.timeScale = defaultTimeScale;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
