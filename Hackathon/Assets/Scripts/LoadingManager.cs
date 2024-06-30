using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingManager : MonoBehaviour
{
    public Text loadingText; 
    public Slider loadingBar;
    public float fakeLoadingSpeed = 0.1f;
    public Text tipText;
    public string[] tips;

    void Start()
    {
        if (tips.Length > 0 && tipText != null)
        {
            tipText.text = tips[Random.Range(0, tips.Length)];
        }
        StartCoroutine(LoadAsync("SampleScene")); 
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        float progress = 0f;

        while (!operation.isDone)
        {
            
            if (progress < 1f)
            {
                progress += fakeLoadingSpeed * Time.deltaTime;
                progress = Mathf.Clamp01(progress);
            }

            
            float realProgress = Mathf.Clamp01(operation.progress / 0.9f);

            
            float displayProgress = Mathf.Min(progress, realProgress);

            
            if (loadingText != null)
            {
                loadingText.text = "Loading... " + (displayProgress * 100) + "%";
            }
            if (loadingBar != null)
            {
                loadingBar.value = displayProgress;
            }

            
            if (displayProgress >= 1f && realProgress >= 1f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
