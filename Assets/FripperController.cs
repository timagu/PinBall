using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;
    //タッチ位置
    int a;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //タッチ位置
        a = Input.touches[0].position;
        Debug.Log(a);

        //左矢印キーを押した時左フリッパーを動かす
        //左矢印を押さえた時
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle (this.flickAngle);
        }
            //画面左を押さえた時
        if (Input.touches[0].phase == TouchPhase.Began && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //タッチ位置
        a = Input.touches[0].position;
        Debug.Log(a);
        //右矢印キーを押した時右フリッパーを動かす
        //右矢印を押さえた時
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle (this.flickAngle);
        }
            //画面右を押さえた時
        if (Input.touches[0].phase == TouchPhase.Began && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
            //左矢印キー離された時
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle (this.defaultAngle);
        }
            //画面左を離された時
        if (Input.touches[0].phase == TouchPhase.Ended)
        {
            SetAngle(this.defaultAngle);
        }
            //右矢印キー離された時
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
            //画面右を離された時
        if (Input.touches[0].phase == TouchPhase.Ended)
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
