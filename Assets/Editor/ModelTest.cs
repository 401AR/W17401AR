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
     

        var testFinding = new ColorFinding();

        var testFinding2 = new TextureFinding();

        testBaby.addFinding(testFinding);
        testBaby.addFinding(testFinding2);

        var contentLength = testBaby.findings.Count;

        Assert.True(testBaby.findings.Contains(testFinding), "Error, the baby does not contain TestFinding");
        Assert.True(testBaby.findings.Contains(testFinding2), "Error, the baby does not contain TestFInding2");

    }


    [Test]
    public void testRemoveFindings()
    //test that findings are being removed 
    {
        var testBaby = new Baby();

        var textureFinding = new TextureFinding();

        testBaby.addFinding(textureFinding);

        Assert.True(testBaby.findings.Contains(textureFinding), "Error, baby does not contain expected finding");

        testBaby.removeFinding(textureFinding);

        Assert.False(testBaby.findings.Contains(textureFinding), "Error, expected finding to be deleted");
    }

}
