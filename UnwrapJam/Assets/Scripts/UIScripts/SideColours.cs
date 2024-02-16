
using UnityEngine;
using UnityEngine.UI;

public class SideColours : MonoBehaviour
{
    public static SideColours instance; 
    [SerializeField]Image holdingItem;

    [SerializeField]Image parrying;

    Color Red = Color.red;

    Color Green = Color.green;

    void Start()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = this;


        holdingItem.color = Green;
        parrying.color = Green;
    }

    // Update is called once per frame
    public void ChangeParryingColour(bool active)
    {
        if (!active)
        {
            parrying.color = Green;
        }

        if (active)
        {
            parrying.color = Red;
        }

    }

    public void ChangeHoldingColour(bool active)
    {
        if (!active)
        {
            holdingItem.color = Green;
        }

        if (active)
        {
            holdingItem.color = Red;
        }

    }
}
