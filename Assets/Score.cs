using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //スコアを表示するテキスト
    private GameObject scoreText;
    //得点
    private int score = 0;

    // Use this for initialization
    void Start () {
        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnCollisionEnter(Collision other)
    {
        //障害物に当たった場合
            //大きな雲に当たった場合
        if (other.gameObject.tag == "LargeCloudTag")
        {
            // スコアを加算
            this.score += 50;
            //ScoreText獲得した点数を表示
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
        }
            //小さな星に当たった場合
        else if (other.gameObject.tag == "SmallStarTag")
        {
            this.score += 10;
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
            //大きな星に当たった場合
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.score += 20;
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
        }
            //小さな雲に当たった場合
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.score += 30;
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
        }
    }
}
