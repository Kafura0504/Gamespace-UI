using UnityEngine;

public class bottomFunction : MonoBehaviour
{
    public GameObject seconbar;
public void closeBottomBar()
    {
        gameObject.SetActive(false);
    }

    public void SecondBarActive()
    {
        seconbar.SetActive(true);
    }
}
