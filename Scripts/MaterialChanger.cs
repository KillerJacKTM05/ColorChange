using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material[] mats = new Material[2];
    //[Range(0,10)]public int matCount = 2;

    public GameObject changer;
    private MeshRenderer render;
    private Material plyMat;
    void Start()
    {
        //mats = new Material[matCount];
        render = changer.GetComponent<MeshRenderer>();
        StartCoroutine(ChangeMat());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ChangeMat()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            render.sharedMaterial = mats[0];
            yield return new WaitForSeconds(1);
            render.sharedMaterial = mats[1];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            plyMat = other.gameObject.GetComponent<Renderer>().sharedMaterial;

            if(plyMat != render.sharedMaterial)
            {
                plyMat = render.sharedMaterial;
                other.gameObject.GetComponent<Renderer>().sharedMaterial = plyMat;
            }
            else if(plyMat == render.sharedMaterial)
            {
                Debug.Log("Same mat.");
            }
        }
    }
}
