using UnityEngine;

public class ShowTheDead : MonoBehaviour
{
    public GameObject[] pawnsWhite;
    public GameObject[] rooksWhite;
    public GameObject[] bishopsWhite;
    public GameObject[] knightsWhite;
    public GameObject[] queensWhite;
    
    public GameObject[] pawnsBlack;
    public GameObject[] rooksBlack;
    public GameObject[] bishopsBlack;
    public GameObject[] knightsBlack;
    public GameObject[] queensBlack;

    public void updateTheDead(int indexOfEat, string type) { 
        
        switch (indexOfEat)
        {
            case 1:
                if (type[1] == 'l')
                {
                    showFunc(pawnsWhite);
                }
                else
                {
                    showFunc(pawnsBlack);

                }
                break;
            case 2:
                if (type[1] == 'l')
                {
                    showFunc(knightsWhite);
                }
                else
                {
                    showFunc(knightsBlack);

                }
                break;
            case 3:
                if (type[1] == 'l')
                {
                    showFunc(bishopsWhite);
                }
                else
                {
                    showFunc(bishopsBlack);

                }
                break;
            case 4:
                if (type[1] == 'l')
                {
                    showFunc(rooksWhite);
                }
                else
                {
                    showFunc(rooksBlack);

                }
                break;
            case 5:
                if (type[1] == 'l')
                {
                    showFunc(queensWhite);
                }
                else
                {
                    showFunc(queensBlack);
                    
                }
                break;
        }
        
    }
    public void showFunc(GameObject[] show)
    {
        foreach (GameObject child in show)
        {
            if (child.gameObject.activeSelf == true)
            {
                continue;
            }
            else
            {

                child.gameObject.SetActive(true);
                break;
            }
        }
    }
}
