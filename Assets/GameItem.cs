using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameItem : MonoBehaviour
{
    public Text titleField;
    public Text developerField;
    public Text descriptionField;
    public Image image;
    public Image mask;
    public GameData data;

    public void Init(GameData data)
    {
        this.data = data;
        titleField.text = data.title;
        developerField.text = data.developer;
        descriptionField.text = data.description;
        StartCoroutine(LoadImage());
    }
    public void SetState(bool isOn)
    {
        mask.gameObject.SetActive(!isOn);
    }
    private IEnumerator LoadImage()
    {
        string imageName = "C:/videogames/games/" + data.folder  + "/" + data.image;
        string url = string.Format("file://{0}", imageName);

        Texture2D temp = new Texture2D(400, 300);
        WWW www = new WWW(url);
        yield return www;
        temp = www.texture;
        Sprite sprite = Sprite.Create(temp, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;
    }
}
