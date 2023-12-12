using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneSorter
{
    MainMenu,
    Warehouse
}
public class LoadingHandler : MonoBehaviour
{

    private static List<AsyncOperation> operations = new List<AsyncOperation>();
    private static AsyncOperation activeAsyncOperation;
    private static List<string> customScenes = new List<string>();
    public static event Action<float> EventUpdateProgress;
    private void Start()
    {
        //TO Do: Implement event form another class to load Scene 
    }
    public static void ChangeInitialScene(SceneSorter index)
    {
        SceneManager.LoadScene((int)index);
    }

    public static void ChangeScene(SceneSorter index)
    {
        operations.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()));
        operations.Add(SceneManager.LoadSceneAsync((int)index));
    }
    public static void UnloadScene(string sceneName)
    {
        operations.Add(SceneManager.UnloadSceneAsync(sceneName));
    }
    public static void UnloadScene(int sceneIndex)
    {
        operations.Add(SceneManager.UnloadSceneAsync(sceneIndex));
    }
    public static void UnLoadScene(string sceneName)
    {
        operations.Add(SceneManager.UnloadSceneAsync(sceneName));
    }
    public static void LoadSceneAndWait(SceneSorter sceneName)
    {
        operations.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()));
        activeAsyncOperation = SceneManager.LoadSceneAsync((int)sceneName);
        activeAsyncOperation.allowSceneActivation = false;
        operations.Add(activeAsyncOperation);
    }
    public static void CreateNewScene(string sceneName)
    {
        SceneManager.CreateScene(sceneName);
        customScenes.Add(sceneName);
    }
    private void ActivateScene()
    {
        if (activeAsyncOperation != null)
        {
            activeAsyncOperation.allowSceneActivation = true;
        }
    }
  
    public virtual void Update()
    {
        if(operations.Count > 0)
        {
            for (int i = operations.Count; i > 0; i--)
            {
                if (!operations[i].isDone)
                {
                    EventUpdateProgress?.Invoke(operations[i].progress);
                }
                else 
                {
                    operations.RemoveAt(i);
                }
            }
        }
      
    }



}