using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDeCenário : MonoBehaviour
{
    float velChao = 0.4f;
    float velPredio = 0.3f;
    public Renderer Chao;
    public Renderer Predio;
       
    void Update()
    {
        Vector2 offset = new Vector2(velChao * Time.deltaTime, 0);
        Chao.material.mainTextureOffset += offset;

        Vector2 offset2 = new Vector2(velPredio * Time.deltaTime, 0);
        Predio.material.mainTextureOffset += offset2;
    }
}
