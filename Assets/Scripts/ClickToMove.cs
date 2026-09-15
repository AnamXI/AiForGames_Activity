using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Use physics raycast hit from mouse click to set agent destination
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClickToMove : MonoBehaviour
    {
        private NavMeshAgent m_Agent;
        private RaycastHit m_HitInfo = new RaycastHit();
        private Animator m_Animator;

        private void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            m_Animator = GetComponent<Animator>();
        }

        private void Update()
        {
            var mouse = Mouse.current;
            if (mouse == null)
                return;

            var keyboard = Keyboard.current;
            var shiftPressed = keyboard != null && keyboard.leftShiftKey.isPressed;

            if (mouse.leftButton.wasPressedThisFrame && !shiftPressed)
            {
                var ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                    m_Agent.destination = m_HitInfo.point;
            }

            if (m_Agent.velocity.magnitude != 0f)
            {
                m_Animator.SetBool("Running", true);
            }
            else
            {
                m_Animator.SetBool("Running", false);
            }
        }
    }
}