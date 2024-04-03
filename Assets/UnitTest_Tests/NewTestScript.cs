using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

public class NewTestScript : IPrebuildSetup , IPostBuildCleanup
{
    //[Test]
    //[UnityPlatform(RuntimePlatform.WindowsPlayer)]
    [TestCase(1, 3, ExpectedResult = 4)]
    [TestCase(2, 3, ExpectedResult = 5)]
    [TestCase(22, 3, ExpectedResult = 26)]
    public int Add(int num1, int num2)
    {
        return Extensions.TestAdd(num1, num2);

        //Color Compare
        //var colorcomparer = new ColorEqualityComparer(10e-6f);
        //var firstColor = new Color(0f, 0f, 0f, 1f);
        //var secondColor = new Color(10e-6f, 0f, 0f, 1f);
        //Assert.That(firstColor, Is.EqualTo(secondColor).Using(colorcomparer));

        //Float Compare
        //var floatcomparer = new FloatEqualityComparer(10e-6f);
        //var firstfloat = -0.00009f;
        //var secondfloat = 0.00009f;
        //Assert.That(firstfloat, Is.EqualTo(secondfloat).Using(floatcomparer));

        //Quaternion compare
        //var quaternioncomparer = new QuaternionEqualityComparer(10e-6f);
        //var firstRot = new Quaternion(10f, 0f, 0f, 0f);
        //var secondRot = new Quaternion(1f, 10f, 0f, 0f);
        //Assert.That(firstRot, Is.EqualTo(secondRot).Using(quaternioncomparer));

        //Vector Compare
        //var v2comparer = new Vector2EqualityComparer(10e-6f);
        //var v3comparer = new Vector3EqualityComparer(10e-6f);
        //var v4comparer = new Vector4EqualityComparer(10e-6f);
        //var firstVector = new Vector2();
        //var secondVector = new Vector2();
        //Assert.That(firstVector, Is.EqualTo(secondVector).Using(Vector2ComparerWithEqualsOperator.Instance));
        //Assert.That(firstVector, Is.EqualTo(secondVector).Using(Vector3ComparerWithEqualsOperator.Instance));
        //Assert.That(firstVector, Is.EqualTo(secondVector).Using(Vector4ComparerWithEqualsOperator.Instance));
    }

    [Test]
    [Category("Add2")]
    [Repeat(10)]
    public void Add2()
    {
        var add = Extensions.TestAdd(3, 4);
        Assert.AreEqual(add, 3 + 4);
    }



    [UnityTest]
    public IEnumerator GameObject_WithRigidBody_WillBeAffectedByPhysics()
    {
        var go = new GameObject();
        go.AddComponent<Rigidbody>();
        var originalPosition = go.transform.position.y;

        GameObject go2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

        yield return new WaitForFixedUpdate();

        yield return new MonoBehaviourTest<UnitTest>();

        Assert.AreNotEqual(originalPosition, go.transform.position.y);
    }



    //Prebuild Setup, Do things like modifying unity editor values apllication settings etc.
    public void Setup()
    {
        
    }
    //PostBuild Changes
    public void Cleanup()
    {
        
    }
}

public class UnitTest : MonoBehaviour, IMonoBehaviourTest
{
    public bool IsTestFinished => throw new System.NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
