using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Networking_Controller : MonoBehaviour
{
    
    [SerializeField]
    private List<Slideshow> ActiveSlideshows = new List<Slideshow>();
    [SerializeField]
    private Button networkingButton;
    public List<Slideshow> Allslideshows = new List<Slideshow>();
    [SerializeField]
    private Image image;
    [SerializeField]
    private List<Slideshow> TotalSlideshow = new List<Slideshow>();
    Slideshow currentSlideshow;
    private int index=0;
    public static Networking_Controller instance;
    public bool warning = false;
    [SerializeField]
    private RectTransform warningSign;
    [SerializeField]
    private Panel_Control rewardPanelControl;
    [SerializeField]
    Canvas OfficeCanvas;
    [SerializeField]
    private float pageHoldTime;
    [SerializeField]
    private Button UIButton=null;
    [SerializeField]
    private Button Phone_Button = null;
    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }


    public void AddSlider()
    {
        if (Allslideshows.Count > 0)
        {
            int x = Random.Range(0, Allslideshows.Count);
            ActiveSlideshows.Add(Allslideshows[x]);
            Allslideshows.RemoveAt(x);
            networkingButton.interactable = true;
            ShowWarning();
        }
        else
        {
            Allslideshows.Clear();
            foreach (Slideshow slide in TotalSlideshow)
            {
                Allslideshows.Add(slide);
            }
            AddSlider();
        }

    }


    private void OnEnable()
    {
        StartCoroutine(Startshow());
    }

    private IEnumerator Startshow()
    {              
        int x = Random.Range(0, ActiveSlideshows.Count);
        currentSlideshow = ActiveSlideshows[x];
        ActiveSlideshows.RemoveAt(x);

        index = 0;
        image.sprite = currentSlideshow.Slides[index];

        yield return new WaitForSeconds(0.5f);
        if (ActiveSlideshows.Count <= 0)
        {
            UIButton.interactable = false;
            Phone_Button.interactable = false;
        }
        StartCoroutine(HoldImage());
    }



    private IEnumerator HoldImage()
    {
        yield return new WaitForSeconds(pageHoldTime);
       
        if (index < currentSlideshow.Slides.Length-1)
        {
            index++;
            image.sprite = currentSlideshow.Slides[index];
            StartCoroutine(HoldImage());
        }
        else
        {
            // reward
            rewardPanelControl.OpenPanel();
            CanvasLoader.Instance.FadeTo(OfficeCanvas);           
        }
    }

    public void ShowWarning()
    {
        if (!warning)
        {
            warning = true;
            LeanTween.scale(warningSign.gameObject, new Vector3(1f, 1f, 1f), 0.5f).setOnComplete(WarningFollowUp);
        }
        Warning_Panel.Instance.ShowMessege("Νεo Networking");
    }


    private void WarningFollowUp()
    {
        LeanTween.scale(warningSign.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.5f).setLoopPingPong();
    }

    public void HideWarning()
    {
        if (warning)
        {
            warning = false;
            LeanTween.cancel(warningSign.gameObject);
            LeanTween.scale(warningSign.gameObject, Vector3.zero, 0.5f);
        }
      
    }

    public void NetworkingReward()
    {
        if (ActiveSlideshows.Count <= 0)
        {
            networkingButton.interactable = false;
            HideWarning();
        }
        GameMaster.Instance.StartCampaign();
    }

}
