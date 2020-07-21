using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PieGraph : MonoBehaviour
{
    public float[] values=new float[17];
    public Sprite[] SDG_Sprites;
    private float total;
    private Image[] images;
    private float zRotation;
    [SerializeField]
    private Transform ImageParentGO=null;
    public static PieGraph Instance;
    [SerializeField]
    private Image[] TopSDGs = new Image[3];
    [SerializeField]
    private Sprite[,] StrategySprites=new Sprite[6,3];
    [SerializeField]
    private Sprite[] initialStrategySprites;
    [SerializeField]
    private Image[] strategyImages;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RefreshGraph();
        FillSpriteImages();
    }


    public void RefreshGraph()
    {

        values = Player.Instance.SDGs;
        total = 0;
        images = GetComponentsInChildren<Image>();
        for (int i = 0; i < values.Length; i++)
        {
            total += values[i];
        }

        if (total > 0)
        {
            for (int i = 0; i < values.Length; i++)
            {

                images[i].fillAmount = values[i] / total;
                images[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
                zRotation -= (values[i] / total) * 360f;

            }

        }
        else
        {
            for (int i = 0; i < values.Length; i++)
            {
                images[i].fillAmount = 0;
            }
        }
        GetTopSDGValues(values);

    }

    



    private void GetTopSDGValues(float[] Sdgs)
    {
        float top1 = 0;
        float top2 = 0;
        float top3 = 0;


        for (int i = 0; i < Sdgs.Length; i++)
        {
            if (Sdgs[i] > top1)
            {
                top1 = Sdgs[i];
                TopSDGs[0].sprite = GameMaster.Instance.SDG_Sprites[i];

                Color sliderColor = new Color();
                if (ColorUtility.TryParseHtmlString("#" + GameMaster.Instance.SDG_Sprites[i].name, out sliderColor))
                {
                    TopSDGs[0].transform.GetComponentsInChildren<Image>()[1].color = sliderColor;
                }

                TopSDGs[0].transform.GetComponentInChildren<Slider>().value = Sdgs[i];


            }
            else if (Sdgs[i] > top2)
            {
                top2 = Sdgs[i];
                TopSDGs[1].sprite = GameMaster.Instance.SDG_Sprites[i];

                Color sliderColor = new Color();
                if (ColorUtility.TryParseHtmlString("#" + GameMaster.Instance.SDG_Sprites[i].name, out sliderColor))
                {
                    TopSDGs[1].transform.GetComponentsInChildren<Image>()[1].color = sliderColor;
                }

                TopSDGs[1].transform.GetComponentInChildren<Slider>().value = Sdgs[i];
            }
            else if (Sdgs[i] > top3)
            {
                top3 = Sdgs[i];
                TopSDGs[2].sprite = GameMaster.Instance.SDG_Sprites[i];

                Color sliderColor = new Color();
                if (ColorUtility.TryParseHtmlString("#" + GameMaster.Instance.SDG_Sprites[i].name, out sliderColor))
                {
                    TopSDGs[2].transform.GetComponentsInChildren<Image>()[1].color = sliderColor;
                }

                TopSDGs[2].transform.GetComponentInChildren<Slider>().value = Sdgs[i];
            }


        }


    }


    public void AddStrategySprites()
    {
        foreach (Image image in strategyImages)
        {
            image.sprite = null;
        }


        Sprite selectedSprite=null;
        int count = 0;
        for(int i = 0; i < GameMaster.Instance.CampaignStars.Length; i++)
        {
            if (GameMaster.Instance.CampaignStars[i] > 0)
            {
                selectedSprite = StrategySprites[i,GameMaster.Instance.CampaignStars[i]-1];
                strategyImages[count].sprite = selectedSprite;
                
                Debug.Log(count);
                count++;
                //if (strategyImages[0].sprite == null)
                //{
                //    strategyImages[0].sprite = selectedSprite;
                //}
                //else if (strategyImages[1].sprite == null)
                //{
                //    strategyImages[1].sprite = selectedSprite;
                //}
                //else if (strategyImages[2].sprite == null)
                //{
                //    strategyImages[2].sprite = selectedSprite;
                //}
            }
        }

       
    }


    private void FillSpriteImages()
    {
        int counter=0;
        for (int i=0;i< 6; i++)
        {
           for(int j = 0; j < 3; j++)
            {
                StrategySprites[i,j] = initialStrategySprites[counter];
                counter++;
            }
          
        }

        foreach(Image image in strategyImages)
        {
            image.sprite = null;
        }


    }
}
