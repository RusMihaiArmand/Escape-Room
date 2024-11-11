using UnityEngine;

public class Loader : MonoBehaviour
{
    public bool startActive = true;

    void Start()
    {
        GameManager._instance.ObjectLoaded();
        gameObject.SetActive(startActive);
    }

    void Update()
    {

    }
}
