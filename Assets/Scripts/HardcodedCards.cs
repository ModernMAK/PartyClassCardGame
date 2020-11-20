
using CardGames;
using System.Resources;
using UnityEditor;

public static class HardcodedCards
{
    [MenuItem("Cards/Write")]
    public static void Test()
    {
        // var 
        // using (var resx = new ResXResourceWriter(@".\Localization\Test.resx"))
        // {
        //     resx.AddResource("Title", "Classic American Cars");
        //     resx.AddResource("HeaderString1", "Make");
        //     resx.AddResource("HeaderString2", "Model");
        //     resx.AddResource("HeaderString3", "Year");
        //     resx.AddResource("HeaderString4", "Doors");
        //     resx.AddResource("HeaderString5", "Cylinders");
        //     // resx.AddResource("Information", SystemIcons.Information);
        //     // resx.AddResource("EarlyAuto1", car1);
        //     // resx.AddResource("EarlyAuto2", car2);
        // }
    }
    public static Card CreateAttackCard()
    {
        var builder = new CardBuilder()
        {
            UnlocalizedName = "Attack"
        };
        return builder.Create();
    }
    public static Card CreateDefenseCard()
    {
        var builder = new CardBuilder()
        {
            UnlocalizedName = "Attack"
        };
        return builder.Create();
    }

}
