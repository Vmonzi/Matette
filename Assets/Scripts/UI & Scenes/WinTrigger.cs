using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    static int _aux = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseCharacter>())
        {
            foreach (string scene in GameManager.InstanceGameManager.allLevels)
            {
                if (scene == SceneManager.GetActiveScene().name) _aux++;
            }

            PlayerPrefs.DeleteKey("checkpointX");
            PlayerPrefs.DeleteKey("checkpointY");
            PlayerPrefs.DeleteKey("checkpointZ");
            StartCoroutine(ChargeScene());
        }
    }

    private IEnumerator ChargeScene()
    {
        //ANDA PARA LEVEL1

        yield return new WaitForSeconds(1f);

        if (_aux > 0 && PlayerPrefs.GetString("currentScene") != GameManager.InstanceGameManager.allLevels[GameManager.InstanceGameManager.allLevels.Count - 1]) 
            GameManager.InstanceGameManager.LoadLevel(GameManager.InstanceGameManager.allLevels[_aux]);
        else 
            GameManager.InstanceGameManager.Win();
    }
}
