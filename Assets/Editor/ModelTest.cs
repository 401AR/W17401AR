using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Vuforia;

public class NewEditorTest
{
    [Test]
    public void testCreateConn()
    /*ensure connection is established*/
    {

    }


    [Test]
    public void testGetAvailableTextures()
    /*test that we get an updated current 
     list of available textures*/
    {

    }



    [Test]
    public void testAddFindingBaby()
    //test that findings ar being added to the baby
    {
        var testBaby = new Baby();

        SyncListFinding testFinding1 = new SyncListFinding();
        SyncListFinding testFinding2 = new SyncListFinding();

        string testFinding1String = JsonUtility.ToJson(testFinding1);
        string testFinding2String = JsonUtility.ToJson(testFinding2);


        testBaby.addFinding(testFinding1);
        testBaby.addFinding(testFinding2);

        var contentLength = testBaby.findings.Count;

        Assert.True(testBaby.findings.Count==2, "Error, the baby does not contain TestFinding");

    }



    [Test]
    public void testRemoveFindings()
    //test that findings are being removed 
    {
        var testBaby = new Baby();

        SyncListFinding testFinding = new SyncListFinding();
        string testFindingString = JsonUtility.ToJson(testFinding);

        testBaby.addFinding(testFinding);

        Assert.True(testBaby.findings.Contains(testFindingString), "Error, baby does not contain expected finding");

        testBaby.removeFinding(testFinding);

        Assert.False(testBaby.findings.Contains(testFindingString), "Error, expected finding to be deleted");
    }
}
