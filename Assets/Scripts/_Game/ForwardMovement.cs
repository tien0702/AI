using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TT.Movement.Common
{
    public class ForwardMovement : MonoBehaviour, ITypeMovement
    {
        public Vector3 GetDirectionMove()
        {
             return transform.forward;
        }
    }
}