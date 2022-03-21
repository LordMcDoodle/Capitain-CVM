using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionBehavior : MonoBehaviour
{
    [SerializeField]
    private int _collectableId;
    private TextMeshProUGUI _text;
    public int CollectableId { get => _collectableId;}

    // Start is called before the first frame update
    void Start()
    {
        _text = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
      

        if(GameManager.Instance.PlayerData.PotionsRamassés[CollectableId]==true && _text != null)
        {
            _text.text = "1/1";
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayerData.PotionsRamassés[CollectableId] = true;
            GameManager.Instance.SaveData();
        }
    }
}
