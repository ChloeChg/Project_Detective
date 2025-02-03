using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPolaroid : MonoBehaviour
{
    public PolaroidCombining slot1;
    public PolaroidCombining slot2;
    public Color ogColor;
    public Color resultColor;
    public Color wrongColor;
    public Image image;
    public GameObject polaroid;
    public GameObject logicPolaroid;
    public GameObject polaroidInventory;
    public HorizontalPolaroidHolder horizontalPolaroidHolder;
    public GameObject thinkButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slot1.currentPolaroid != null && slot2.currentPolaroid != null)
        {
            if (slot1.currentPolaroid.ableToCombineWithID == slot2.currentPolaroid.ID && transform.childCount == 0)
            {
                image.color = resultColor;
                thinkButton.SetActive(true);
            }
            else { image.color = wrongColor; }
        }
    }

    public void combinePolaroid()
    {
        image.color = ogColor;
        thinkButton.SetActive(false);
        slot1.currentPolaroid = null;
        slot2.currentPolaroid = null;
        Destroy(slot1.currentPolaroidObject);
        Destroy(slot2.currentPolaroidObject);
        Instantiate(polaroid, new Vector2(0, 0), Quaternion.identity, polaroidInventory.transform);
        GameObject logicPolaroidToAdd = Instantiate(logicPolaroid, new Vector2(0, 0), Quaternion.identity, transform);
        logicPolaroidToAdd.GetComponent<LogicPolaroid>().ID = UnityEngine.Random.Range(10, 15);
        logicPolaroidToAdd.GetComponent<LogicPolaroid>().ableToCombineWithID = 0;
        horizontalPolaroidHolder.AddPolaroid(logicPolaroidToAdd.GetComponent<LogicPolaroid>());
    }
}
