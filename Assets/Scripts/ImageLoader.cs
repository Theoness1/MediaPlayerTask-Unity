using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    [SerializeField] private RawImage[] _rawImages;
    [SerializeField] private GameObject[] _loadingRings;
    [SerializeField] private List<string> _imageUrls;

    private void Start()
    {
        StartCoroutine(LoadImage());
    }

    private IEnumerator LoadImage()
    {
        for (int i = 0; i < _imageUrls.Count; i++)
        {
            string url = _imageUrls[i];
            string cachePath = Path.Combine(
                Application.dataPath + "/Cache/Preview", "cachedImage" + i.ToString() + ".png");

            if (File.Exists(cachePath))
            {
                byte[] fileData = File.ReadAllBytes(cachePath);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(fileData);
                _rawImages[i].texture = texture;
                _loadingRings[i].SetActive(false);
            }
            else
            {
                using UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    _rawImages[i].texture = texture;
                    _loadingRings[i].SetActive(false);

                    byte[] textureBytes = texture.EncodeToPNG();
                    File.WriteAllBytes(cachePath, textureBytes);
                }
                else
                {
                    Debug.LogError("Ошибка загрузки изображения: " + www.error);
                }
            }
        }
    }
}
