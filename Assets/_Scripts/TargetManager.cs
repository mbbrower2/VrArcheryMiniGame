using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance { get; private set; }

    [SerializeField] private string nextSceneName;
    private int remainingTargets;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterTarget()
    {
        remainingTargets++;
        Debug.Log("ABCD Debug: Register Target called, total: " + remainingTargets);
    }

    public void ReportTargetDown()
    {
        remainingTargets--;
        Debug.Log("ABCD Debug: Target Down called, remaining: " + remainingTargets);

        if (remainingTargets <= 0)
        {
            Debug.Log("ABCD Debug: Load next scene");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}