using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof (Text))]
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
        private Text m_Text;
        private bool m_Display = false;
        private Color m_DefaultColour;
        private Color m_DisabledColour;

        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<Text>();

            m_DefaultColour = m_Text.color;
            m_DisabledColour = m_DefaultColour;
            m_DisabledColour.a = 0;

            m_Text.color = m_Display ? m_DefaultColour : m_DisabledColour;
        }


        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.F1))
            {
                m_Display = !m_Display;
                m_Text.color = m_Display ? m_DefaultColour : m_DisabledColour;
            }


            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_Text.text = string.Format(display, m_CurrentFps);
            }
        }
    }
}
