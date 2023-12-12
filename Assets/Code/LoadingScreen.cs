using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TMP_Text[] loadingText;
    [SerializeField] private Image backgroundImage;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        loadingBar = GetComponent<Slider>();
        loadingBar.value = 0;
        loadingText = GetComponentsInChildren<TMP_Text>();
        backgroundImage = GetComponent<Image>();

        LoadingHandler.EventUpdateProgress += UpdateLoadingBar;
    }

    public virtual void UpdateLoadingBar(float progress)
    {
        loadingBar.value = progress;
    }

    public virtual void UpdateTextToolTip(string text)
    {
        loadingText[0].text = text;
    }

    public virtual void UpdateLoadingBarProgres(string text)
    {
        loadingText[1].text = text;
    }

    public virtual void RandomizeLoadingBackground(Image image)
    {
        backgroundImage = image;
    }


}
