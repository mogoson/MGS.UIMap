/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MapFlag.cs
 *  Description  :  Define map flag.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Map
{
    /// <summary>
    /// Flag on map.
    /// </summary>
    [AddComponentMenu("Mogoson/Map/MapFlag")]
    [RequireComponent(typeof(RectTransform))]
    public class MapFlag : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Flag's target.
        /// </summary>
        public Transform target;

        /// <summary>
        /// RectTransform of MapFlag UI.
        /// </summary>
        protected RectTransform rectTrans;
        #endregion

        #region Protected Method
        protected virtual void Awake()
        {
            rectTrans = GetComponent<RectTransform>();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Update flag's position.
        /// </summary>
        /// <param name="anchored">Anchored position.</param>
        public void UpdateFlagPosition(Vector2 anchored)
        {
            rectTrans.anchoredPosition = anchored;
        }

        /// <summary>
        /// Update flag's rotation.
        /// </summary>
        public void UpdateFlagRotation()
        {
            rectTrans.localEulerAngles = Vector3.back * target.eulerAngles.y;
        }

#if UNITY_EDITOR
        /// <summary>
        /// Initialise MapFlag (Only call this method in editor script).
        /// </summary>
        public void InitializeInEditor()
        {
            Awake();
        }
#endif
        #endregion
    }
}