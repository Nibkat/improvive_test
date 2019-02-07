using UnityEngine;

public class QuitButton : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}