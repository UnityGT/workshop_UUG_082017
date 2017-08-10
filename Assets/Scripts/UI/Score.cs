using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text text;

	void Awake () {
        text = GetComponent<Text>();
	}

    public void UpdateScore(int value)
    {
        text.text = value.ToString();
    }
}
