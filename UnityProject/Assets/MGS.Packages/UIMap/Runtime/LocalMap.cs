/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LocalMap.cs
 *  Description  :  Define local map.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UIMap
{
    /// <summary>
    /// Local map.
    /// </summary>
    public class LocalMap : GlobalMap
    {
        #region Protected Method
        /// <summary>
        /// Component update.
        /// </summary>
        protected override void Update()
        {
            //Update flags position and rotation.
            base.Update();
            UpdateMapPos();
        }

        /// <summary>
        /// Update map's position.
        /// </summary>
        protected void UpdateMapPos()
        {
            rectTrans.anchoredPosition = -GetMappingPos(dynamicFlags[0]);
        }
        #endregion
    }
}