using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.Networking;
using System.Collections;
using System.IO;

public class Demo : MonoBehaviour
{
    public GameObject prefabs;
    public GameObject content;

    public Sprite defaultIcon;

    AudioSource audioSource;
    AudioClip myClip;

    void Start()
    {
        StartCoroutine(GetSongs());
    }

    IEnumerator GetSongs()
    {
        string url = "https://thaingoc29.000webhostapp.com/baihatnhom1.php";
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.chunkedTransfer = false;
        yield return request.Send();

        if (request.isNetworkError)
        {

        }
        else
        {
            if (request.isDone)
            {
                Songs[] allSongs = JsonHelper.FromJson<Songs>(request.downloadHandler.text);
                GameObject Song = transform.GetChild(0).gameObject;
                GameObject g;

                int N = allSongs.Length;

                //string[] urlMP3;
                //urlMP3 = new string[N];

                for (int i = 0; i < N; i++)
                {
                    //Lấy url hình ảnh từ lớp ObjectSong
                    WWW w = new WWW(allSongs[i].Image);
                    yield return w;



                    if (w.error != null)
                    {
                        //set default icon
                        allSongs[i].Icon = defaultIcon;
                    }
                    else
                    {
                        if (w.isDone)
                        {
                            Texture2D tx = w.texture;
                            g = Instantiate(prefabs);
                            g.transform.SetParent(content.transform, false);
                            g.transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(tx, new Rect(0f, 0f, tx.width, tx.height), Vector2.zero, 10f);
                            g.transform.GetChild(1).GetComponent<Text>().text = allSongs[i].Name;
                            g.transform.GetChild(2).GetComponent<Text>().text = allSongs[i].Singer;
                            g.transform.GetChild(4).GetComponent<Text>().text = allSongs[i].Mp3;
                            //g.transform.GetChild(4).GetComponent<Button>().StartCoroutine(GetAudioClip(allSongs[i].Mp3));
                        }
                    }
                }
            }
        }
    }

    //public void GetAudioClip(string url, ObjectSongs songs, Action<AudioClip> onComplete)
    //{
    //    string[] fileStruct = url.Split('/');
    //    string fileName = fileStruct[fileStruct.Length - 1];
    //    fileName = fileName.Split('.')[0];
    //    fileName = Uri.UnescapeDataString(fileName);

    //    if (isFileExist(fileName, songs.Mp3))
    //    {
    //        StartCoroutine(LoadAudioLocal(fileName, onComplete));
    //    }
    //    else
    //    {
    //        StartCoroutine(DownloadAndSaveFile(url, songs, (f, d) => { StartCoroutine(LoadAudioLocal(fileName, onComplete)); }));
    //    }
    //}

    //public IEnumerator DownloadAndSaveFile(string url, Extension ex,Action<string, string> onComplete = null)
    //{
    //    string[] fileStruct = url.Split('/');
    //    string fileName = fileStruct[fileStruct.Length - 1];
    //    fileName = fileName.Split('.')[0];
    //    fileName = Uri.UnescapeDataString(fileName);
    //    using(UnityWebRequest www = UnityWebRequest.Get(url))
    //    {
    //        yield return www.SendWebRequest();
    //        if (www.isNetworkError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            File.WriteAllBytes(string.Format("{0}/{1}/{2}.{3}",
    //                        Application.dataPath,
    //                        LOCAL_PATH, fileName, ex.ToString()), www.downloadHandler.data);

    //            if (onComplete != null)
    //            {
    //                onComplete.Invoke(fileName, Application.dataPath + "/" + LOCAL_PATH);
    //            }
    //        }
    //    }
    //}


    //IEnumerator GetAudioClip(string url)
    //{
    //    lấy url mp3 từ json
    //    UnityWebRequest wwwMp3 = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
    //    yield return wwwMp3;
    //    if (wwwMp3.isNetworkError)
    //    {
    //        Debug.Log(wwwMp3.error);
    //    }
    //    else
    //    {
    //        myClip = DownloadHandlerAudioClip.GetContent(wwwMp3);
    //        audioSource.clip = myClip;
    //        audioSource.Play();
    //    }
    //}

    //IEnumerator DowLoadAudioClipFromUrl(string urlMp3)
    //{
    //    while (!Caching.ready)
    //        yield return null;

    //    using (var www = WWW.LoadFromCacheOrDownload(urlMp3, 5))
    //    {
    //    1    yield return www;
    //        if (!string.IsNullOrEmpty(www.error))
    //        {
    //            Debug.Log(www.error);
    //            yield return null;
    //        }
    //        var myLoadedAssetBundle = www.assetBundle;

    //        var asset = myLoadedAssetBundle.mainAsset;
    //    }
    //}
}
