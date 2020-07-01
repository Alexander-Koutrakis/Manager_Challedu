using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement_Button : MonoBehaviour
{
    public GameObject achievement_List;
    public Sprite highlight_Sprite, neutral_Sprite;
    private Image sprite;
    private void Awake()
    {
        sprite = GetComponent<Image>();
    }

    public void Click()
    {
        Button thisButton = GetComponent<Button>();
         SpriteState st = new SpriteState();
        if (sprite.sprite == neutral_Sprite)
        {
            sprite.sprite = highlight_Sprite;
            achievement_List.SetActive(true);            
            st.highlightedSprite = highlight_Sprite;
            
        }
        else
        {
            sprite.sprite = neutral_Sprite;
            achievement_List.SetActive(false);
            st.highlightedSprite = neutral_Sprite;
        }
        thisButton.spriteState = st;
    }

    
}
