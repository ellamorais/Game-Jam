using UnityEngine;
using System.Collections;

public class MouseHover : MonoBehaviour
{
    MeshRenderer m_Renderer;
    Color og_Colour;
    Color m_Colour = Color.red;
    void Start() {
        m_Renderer = GetComponent<MeshRenderer>();
        og_Colour = m_Renderer.material.color;
    }

    private void OnMouseEnter()
    {
        m_Renderer.material.color = m_Colour;
    }

    private void OnMouseExit()
    {
        m_Renderer.material.color = og_Colour;
    }
}
