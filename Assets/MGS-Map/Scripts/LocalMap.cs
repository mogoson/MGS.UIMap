/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: LocalMap.cs
 *  Author: Mogoson   Version: 1.0   Date: 12/29/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.           LocalMap               Ignore.
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