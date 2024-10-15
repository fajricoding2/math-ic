
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void pindah(string namaspace)
    {
        SceneManager.LoadScene(namaspace);
    }

    public void scale(float scale)
    {
        transform.localScale = new Vector2(1f / scale, 1f / scale);
    }
}