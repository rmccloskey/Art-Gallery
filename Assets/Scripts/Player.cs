using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Camera m_Camera;
    [SerializeField]
    GameObject m_ArtworkPanel;
    Animator m_ArtworkPanelAnim;
    Text m_ArtworkTitleText;

    [SerializeField]
    LayerMask m_LayerMask;
    
    void Start()
    {
        m_Camera = Camera.main;
        m_ArtworkPanelAnim = m_ArtworkPanel.GetComponent<Animator>();
        m_ArtworkTitleText = m_ArtworkPanel.GetComponentInChildren<Text>();
    }
    
    void Update()
    {
        Ray ray = new Ray(m_Camera.transform.position, m_Camera.transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 1.5f, out hit, 4, m_LayerMask, QueryTriggerInteraction.UseGlobal))
        {
            string title = hit.collider.gameObject.GetComponent<Artwork>().title;
            Debug.Log("Artwork " + title + " is in view");
            if (!m_ArtworkPanelAnim.GetBool("Show"))
            {
                m_ArtworkTitleText.text = title;
                m_ArtworkPanelAnim.SetBool("Show", true);
            }
        }
        else
        {
            if (m_ArtworkPanelAnim.GetBool("Show"))
                m_ArtworkPanelAnim.SetBool("Show", false);
                
        }
    }
}
