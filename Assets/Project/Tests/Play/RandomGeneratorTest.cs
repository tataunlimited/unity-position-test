using System.Collections;
using Cysharp.Threading.Tasks;
using NUnit.Framework;
using Project.Utilities;
using UnityEngine.TestTools;

namespace Project.Tests.Play
{
    public class RandomGeneratorTest
    {

        [UnityTest]
        public IEnumerator GenerateRandomChoice()=> UniTask.ToCoroutine(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                var randomChoice = await RandomGenerator.GetRandomChoice();
                Assert.That(()=>randomChoice>=0 && randomChoice<3);
            }
        });
    }
}
