/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MapFlag.cs
 *  Description  :  Define map flag.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UIMap
{
    /// <summary>
    /// Flag on map.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class MapFlag : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Flag's target.
        /// </summary>
        [Tooltip("Flag's target.")]
        public Transform target;

        /// <summary>
        /// RectTransform of MapFlag UI.
        /// </summary>
        protected RectTransform rectTrans;
        #endregion

        #region Protected Method
        /// <summary>
        /// Component awake.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize MapFlag.
        /// </summary>
        protected virtual void Initialize()
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
        #endregion
    }
}