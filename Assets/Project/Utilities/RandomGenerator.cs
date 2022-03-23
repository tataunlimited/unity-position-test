using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace Project.Utilities
{
    public static class RandomGenerator
    {
        public static async UniTask<int> GetRandomChoice()
        {
            var txt = (await UnityWebRequest.Get
                ("http://www.randomnumberapi.com/api/v1.0/random?min=0&max=2&count=1")
                .SendWebRequest())
                .downloadHandler.text;
            var index = int.Parse(txt.Substring(1,1));
            return index;
        }
    }
}
