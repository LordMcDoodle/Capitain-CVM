using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        { 
            Debug.Log("Félicitation, le niveau est terminé.");
            GameManager.Instance.SaveData();
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                GameManager.Instance.PlayerData.NiveauxFaits[2] = true;
                SceneManager.LoadScene("MainMenu");
            }
            else if (SceneManager.GetActiveScene().name == "Level1")
            {
                GameManager.Instance.PlayerData.NiveauxFaits[0] = true;
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                GameManager.Instance.PlayerData.NiveauxFaits[1] = true;
                SceneManager.LoadScene("Level3");
            }

            GameManager.Instance.SaveData();


        }
    }
}
