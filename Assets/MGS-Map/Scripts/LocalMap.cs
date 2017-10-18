/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  LocalMap.cs
 *  Description  :  Define local map.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  12/29/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.Map
{
    [AddComponentMenu("Developer/Map/LocalMap")]
    public class LocalMap : GlobalMap
    {
        #region Protected Method
        protected override void Update()
        {
            //Update flags.
            base.Update();
            UpdateMap();
        }

        /// <summary>
        /// Update map's position.
        /// </summary>
        protected void UpdateMap()
        {
            var tPos = GetTargetPosition(dynamicFlags[0]);
            rTrans.anchoredPosition = -new Vector2(tPos.x * wFactor, tPos.z * hFactor);
        }
        #endregion
    }
}