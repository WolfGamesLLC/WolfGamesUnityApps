using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tests
{
    class MockPlayerController : IMovementController
    {
        public Vector3 Force;

        public void MoveObject(Vector3 force)
        {
            Force = force;
        }

        public Vector3 Position()
        {
            return Vector3.one;
        }
    }
}
