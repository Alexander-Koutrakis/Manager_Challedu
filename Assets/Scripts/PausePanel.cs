using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Image SFX_image;
    [SerializeField]
    private Image BG_Image;

    [SerializeField]
    private Sprite MuteSFX_Sprite;
    [SerializeField]
    private Sprite NormalSFX_Sprite;
    [SerializeField]
    private Sprite MuteBG_Sprite;
    [SerializeField]
    private Sprite NormalBG_Sprite;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void PauseGame()
    {
        StartCoroutine(DelayedPause());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    

    private IEnumerator DelayedPause()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
    }


    private void Start()
    {
        if (Audio_Manager.Instance.SFXaudioSource.volume > 0)
        {
            SFX_image.sprite = NormalSFX_Sprite;
        }
        else
        {
            SFX_image.sprite = MuteSFX_Sprite;
        }

        if (Audio_Manager.Instance.BackMusicSource.volume > 0)
        {
            BG_Image.sprite = NormalBG_Sprite;
        }
        else
        {
            BG_Image.sprite = MuteBG_Sprite;
        }
    }



    public void CheckSFXSprite()
    {
        Audio_Manager.Instance.MuteSFX();

        if (Audio_Manager.Instance.SFXaudioSource.volume > 0)
        {
            SFX_image.sprite = NormalSFX_Sprite;
        }
        else
        {
            SFX_image.sprite = MuteSFX_Sprite;
        }
    }


    public void CheckBGSprite()
    {
        Audio_Manager.Instance.MuteBackMusic();

        if (Audio_Manager.Instance.BackMusicSource.volume > 0)
        {
            BG_Image.sprite = NormalBG_Sprite;
        }
        else
        {
            BG_Image.sprite = MuteBG_Sprite;
        }
    }

}
