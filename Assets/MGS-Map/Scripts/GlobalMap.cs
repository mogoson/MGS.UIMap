/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: GlobalMap.cs
 *  Author: Mogoson   Version: 1.0   Date: 12/29/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.           GlobalMap              Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     12/29/2016       1.0        Build this file.
 *************************************************************************/

namespace Developer.Map
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Terrain Info.
    /// </summary>
    [Serializable]
    public struct TerrainInfo
    {
        /// <summary>
        /// Center of terrain.
        /// </summary>
        public Transform center;

        /// <summary>
        /// Width of terrain.
        /// </summary>
        public float width;

        /// <summary>
        /// Length of terrain.
        /// </summary>
        public float length;

        public TerrainInfo(Transform center, float width, float length)
        {
            this.center = center;
            this.width = width;
            this.length = length;
        }
    }

    [AddComponentMenu("Developer/Map/GlobalMap")]
    [RequireComponent(typeof(RectTransform))]
    public class GlobalMap : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Terrain info.
        /// </summary>
        public TerrainInfo terrainInfo = new TerrainInfo(null, 500, 500);

        /// <summary>
        /// Dynamic flags.
        /// </summary>
        public List<MapFlag> dynamicFlags;

        /// <summary>
        /// Static flags.
        /// </summary>
        public List<MapFlag> staticFlags;

        /// <summary>
        /// RectTransform of map UI.
        /// </summary>
        protected RectTransform rTrans;

        /// <summary>
        ///  Width Factor(Map width / Terrain width).
        /// </summary>
        protected float wFactor = 0;

        /// <summary>
        /// Height Factor(Map height / Terrain length).
        /// </summary>
        protected float hFactor = 0;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            rTrans = GetComponent<RectTransform>();
            wFactor = rTrans.rect.width / terrainInfo.width;
            hFactor = rTrans.rect.height / terrainInfo.length;
            UpdateFlags(staticFlags);
        }

        protected virtual void Update()
        {
            UpdateFlags(dynamicFlags);
        }

        /// <summary>
        /// Update flags position and rotation.
        /// </summary>
        /// <param name="flags">Map flags.</param>
        protected void UpdateFlags(List<MapFlag> flags)
        {
            foreach (var flag in flags)
            {
                var tPos = GetTargetPosition(flag);
                flag.UpdateFlagPosition(new Vector2(tPos.x * wFactor, tPos.z * hFactor));
                flag.UpdateFlagRotation();
            }
        }

        /// <summary>
        /// Get flag's target position.
        /// </summary>
        /// <param name="flag">Map flag.</param>
        /// <returns></returns>
        protected Vector3 GetTargetPosition(MapFlag flag)
        {
            return flag.target.position - terrainInfo.center.position;
        }
        #endregion
    }
}