using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextThrailer : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(StartGameWithDelay());
    }

    private IEnumerator StartGameWithDelay()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(2);

        // Load the scene
        SceneManager.LoadScene("SAL");
    }
}
