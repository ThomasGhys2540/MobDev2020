using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ButtonHandler buttonHandler;

    private string succeed = "BuyClick";
    private string fail = "ErrorClick";

    private int Meleeprice = 100;
    private int Spearmanprice = 120;
    private int Shieldprice = 150;
    private int Archerprice = 100;
    private int Magickaprice = 115;
    private int Cavalryprice = 120;
    
    public void BuyUnit(string Unit)
    {
        switch (Unit)
        {
            case "Melee":
                Buy(Meleeprice);
                break;
            case "Spearman":
                Buy(Spearmanprice);
                break;
            case "Shield":
                Buy(Shieldprice);
                break;
            case "Archer":
                if (BaseScript.ArcherUpgradeLevel >= 1)
                {
                    Buy(Archerprice);
                }
                else
                {
                    buttonHandler.ShopSFX(fail);
                }
                break;
            case "Magicka":
                if (BaseScript.MagickaUpgradeLevel >= 1)
                {
                    Buy(Magickaprice);
                }
                else
                {
                    buttonHandler.ShopSFX(fail);
                }
                break;
            case "Cavalry":
                if (BaseScript.CavalryUpgradeLevel >= 1)
                {
                    Buy(Cavalryprice);
                }
                else
                {
                    buttonHandler.ShopSFX(fail);
                }
                break;
            default:
                Debug.LogError("No Match");
                break;
        }
    }

    public void Buy(int price)
    {
        if ((PlayerStats.Money - price) >= 0)
        {
            PlayerStats.Money -= price;
            buttonHandler.ShopSFX(succeed);
        }
        else
        {
            buttonHandler.ShopSFX(fail);
        }
    }
}
