/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: MapFlag.cs
 *  Author: Mogoson   Version: 1.0   Date: 12/29/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.            MapFlag               Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     12/29/2016       1.0        Build this file.
 *************************************************************************/

namespace Developer.Map
{
    using UnityEngine;

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
        }//Awake()_end
        #endregion

        #region Public Method
        /// <summary>
        /// Update flag's position.
        /// </summary>
        /// <param name="anchored">Anchored position.</param>
        public void UpdateFlagPosition(Vector2 anchored)
        {
            rTrans.anchoredPosition = anchored;
        }//UpdateF...()_end

        /// <summary>
        /// Update flag's rotation.
        /// </summary>
        public void UpdateFlagRotation()
        {
            rTrans.localEulerAngles = Vector3.back * target.eulerAngles.y;
        }//UpdateF...()_end
        #endregion
    }//class_end
}//namespace_end