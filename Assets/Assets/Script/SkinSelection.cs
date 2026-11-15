using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelection : MonoBehaviour
{
    public SpriteChange data;
    public Image img;
    public TextMeshProUGUI name;
    public void setsprite()
    {
        // buat btn
        GameManager.Instance.playerskin.sprite = data.sprite;
    }

    void Awake()
    {
        img.sprite = data.sprite;
        name.SetText(data.name);
    }
}
