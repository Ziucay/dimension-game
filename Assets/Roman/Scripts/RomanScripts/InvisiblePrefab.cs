using UnityEngine;

public class InvisiblePrefab : MonoBehaviour
{
    public bool isVisibleInFirstWorld;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    public void SetInitialVisibility()
    {
        gameObject.SetActive(isVisibleInFirstWorld);
    }

    public void ChangeVisibility()
    {
        isVisibleInFirstWorld = !isVisibleInFirstWorld;
        gameObject.SetActive(isVisibleInFirstWorld);
    }
}