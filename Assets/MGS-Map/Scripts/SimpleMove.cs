/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  SimpleMove.cs
 *  Description  :  Simple move controller.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  12/29/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.Map
{
    [AddComponentMenu("Developer/Map/SimpleMove")]
    public class SimpleMove : MonoBehaviour
    {
        #region Property and Field
        public float moveSpeed = 10;
        public float rotateSpeed = 60;
        #endregion

        #region Private Method
        private void Update()
        {
            transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
            transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up, rotateSpeed * Time.deltaTime);
        }
        #endregion
    }
}