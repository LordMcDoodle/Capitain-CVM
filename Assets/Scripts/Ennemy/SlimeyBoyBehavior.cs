using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeyBoyBehavior : MonoBehaviour
{
    /// <summary>
    /// Point de vie du personnage
    /// </summary>
    [SerializeField]
    private int _pv = 1;
    /// <summary>
    /// Angle de tolérange pour le calcul du saut sur la tête
    /// </summary>
    [SerializeField]
    private float _toleranceAngle = 1.5f;
    /// <summary>
    /// Décrit la durée de l'invulnaribilité
    /// </summary>
    public const float DelaisInvulnerabilite = 1f;
    /// <summary>
    /// Décrit si l'entité est invulnérable
    /// </summary>
    private bool _invulnerable = false;
    /// <summary>
    /// Représente le moment où l'invulnaribilité a commencé
    /// </summary>
    private float _tempsDebutInvulnerabilite;
    /// <summary>
    /// Nombre de points octroyer lors de la destruction
    /// </summary>
    [SerializeField]
    private int _pointDestruction = 5;
    /// <summary>
    /// Défini si l'objet est en cours de destruction
    /// </summary>
    private bool _destructionEnCours = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this._pv <= 0)
        {
            if (this.name == ("BigSlimey"))
            {
              
                gameObject.transform.Find("MediumSlimey1").gameObject.SetActive(true);
                gameObject.transform.Find("MediumSlimey2").gameObject.SetActive(true);
                GameObject.Find("MediumSlimeyTarget1").SetActive(true);
                GameObject.Find("MediumSlimeyTarget2").SetActive(true);
                
            }
            if (this.name == ("MediumSlimey1") || this.name == ("MediumSlimey2"))
            {

                gameObject.transform.Find("SmallSlimey1").gameObject.SetActive(true);
                gameObject.transform.Find("SmallSlimey2").gameObject.SetActive(true);
                GameObject.Find("SmallSlimeyTarget1").SetActive(true);
                GameObject.Find("SmallSlimeyTarget2").SetActive(true);
                
            }

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !_invulnerable)
        {
            PlayerBehaviour pb = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (pb != null)
                pb.CallEnnemyCollision();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            this._pv --;
        }
    }
}
