/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  MapFlag.cs
 *  Description  :  Define map flag.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  12/29/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.Map
{
    [AddComponentMenu("Developer/Map/MapFlag")]
    [RequireComponent(typeof(RectTransform))]
    public class MapFlag : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Flag's target.
        /// </summary>
        public Transform target;

        /// <summary>
        /// RectTransform of MapFlag UI.
        /// </summary>
        protected RectTransform rTrans;
        #endregion

        #region Protected Method
        protected virtual void Awake()
        {
            rTrans = GetComponent<RectTransform>();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Update flag's position.
        /// </summary>
        /// <param name="anchored">Anchored position.</param>
        public void UpdateFlagPosition(Vector2 anchored)
        {
            rTrans.anchoredPosition = anchored;
        }

        /// <summary>
        /// Update flag's rotation.
        /// </summary>
        public void UpdateFlagRotation()
        {
            rTrans.localEulerAngles = Vector3.back * target.eulerAngles.y;
        }

#if UNITY_EDITOR
        /// <summary>
        /// Initialise MapFlag in edit mode (Only call this method in editor script).
        /// </summary>
        public void InitialiseInEditMode()
        {
            Awake();
        }
#endif
        #endregion
    }
}