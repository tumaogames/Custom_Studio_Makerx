using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialUI : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Texture texture;
    [SerializeField] private GameObject gObject;

    public Material Material => material;
    public Texture Texture => texture;
    public GameObject GameObject => gameObject;
}
