using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GREENGooBehavior : MonoBehaviour
{
    [SerializeField]
    private int _collectableId;
    private TextMeshProUGUI _text;
    public int CollectableId { get => _collectableId; }
    // Start is called before the first frame update
    void Start()
    {
        _text = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();


        if (_text != null)
        {
            int nbRamassés =0;
            foreach(bool b in GameManager.Instance.PlayerData.GreenGoosRamassés)
            {
                if (b)
                {
                    nbRamassés++;
                }
            }
            _text.text = $"{nbRamassés}/6";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayerData.GreenGoosRamassés[CollectableId] = true;
            GameManager.Instance.SaveData();
        }
    }
}
