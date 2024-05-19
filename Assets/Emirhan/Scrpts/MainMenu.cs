using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update    
    public GameObject gameName;
    public GameObject MenuBtn;
    public GameObject SettingsBtn;
    public GameObject BackBtn;
    public GameObject CreditsCanvas;
    public GameObject ExitButton;
    public RawImage Dark;
    public void Play()
    {
        StartCoroutine(Iterate());
    }
    IEnumerator Iterate()
    {
        Dark.gameObject.SetActive(true);
        StartCoroutine(FadeIn(Dark, 2));
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        gameName.SetActive(false);
        MenuBtn.SetActive(false);
        BackBtn.SetActive(true);
        CreditsCanvas.SetActive(true);
    }
    public void Settings()
    {

    }
    public void Back()
    {           
        gameName.SetActive(true);
        MenuBtn.SetActive(true);
        BackBtn.SetActive(false);
        CreditsCanvas.SetActive(false);              
    }       
    private YieldInstruction Instruction = new YieldInstruction();
    public IEnumerator FadeOut(RawImage image, float time)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < time)
        {
            yield return Instruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / time);
            image.color = c;
        }
    }

    public IEnumerator FadeIn(RawImage image, float time)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < time)
        {
            yield return Instruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / time);
            image.color = c;
        }
    }
}
