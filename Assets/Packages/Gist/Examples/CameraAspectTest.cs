using UnityEngine;
using System.Collections;

namespace Gist {
        
    [ExecuteInEditMode]
    public class CameraAspectTest : MonoBehaviour {
        public Camera targetCam;
        public Positioner[] positions;

        void Update() {
            if (positions == null || targetCam == null)
                return;

            for (var i = 0; i < positions.Length; i++) {
                var pos = positions[i];
                if (pos == null || pos.target == null)
                    continue;

                var vp = pos.viewportPos;
                vp.z = vp.z * (targetCam.farClipPlane - targetCam.nearClipPlane) + targetCam.nearClipPlane;
                pos.target.position = targetCam.ViewportToWorldPoint (vp);
            }
        }

        [System.Serializable]
        public class Positioner {
            public Transform target;
            public Vector3 viewportPos;
        }
    }
}