using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyLevelCompletion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ActivateButtons();
    }

    private void Awake()
    {
        ActivateButtons();
    }

    public void ActivateButtons()
    {
        if (GameManager.Instance.PlayerData.NiveauxFaits[0])
        {
            GameObject.Find("ButtonNiv1").GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.PlayerData.NiveauxFaits[1])
        {
            GameObject.Find("ButtonNiv2").GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.PlayerData.NiveauxFaits[2])
        {
            GameObject.Find("ButtonNiv3").GetComponent<Button>().interactable = true;
        }
    }

}
