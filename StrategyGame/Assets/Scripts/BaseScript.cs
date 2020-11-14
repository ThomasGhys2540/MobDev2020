using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour
{
    public static int MeleeUpgradeLevel;
    public static int SpearmanUpgradeLevel;
    public static int ShieldUpgradeLevel;
    public static int ArcherUpgradeLevel;
    public static int MagickaUpgradeLevel;
    public static int CavalryUpgradeLevel;

    private int InitialUpgradeLevel = 0;

    private string succeed = "BuyClick";
    private string fail = "ErrorClick";

    private int meleeUpgradeCost = 150;
    private int spearmanUpgradeCost = 150;
    private int shieldUpgradeCost = 150;
    private int archerUpgradeCost = 150;
    private int magickaUpgradeCost = 150;
    private int cavalryUpgradeCost = 150;

    private string maxtierresearch = "Reseach finished";

    private string meleeupgrade1 = "Melee Health: + 5";
    private string meleeupgrade2 = "Maximum troop Capacity: +2\nMelee Power: +5";
    private string meleeupgrade3 = "Melee Health: +10\nMaximum troop capacity: +3";
    private string meleeupgrade4 = "Melee Power: +15";
    private string meleeupgrade5 = "Unlock Reckless Charge";

    private string spearmanupgrade1 = "All unit Power: +5";
    private string spearmanupgrade2 = "All unit Health: +5";
    private string spearmanupgrade3 = "All unit Health: +5\nMaximum troop capacity: +6";
    private string spearmanupgrade4 = "All unit Power: +15";
    private string spearmanupgrade5 = "Unlock Spear Wall";

    private string shieldupgrade1 = "Maximum troop capacity: +5";
    private string shieldupgrade2 = "Shield Power: -5\nShield Health: +10";
    private string shieldupgrade3 = "Maximum troop capacity: +10";
    private string shieldupgrade4 = "Shield Power: +5\nShield Health: +10";
    private string shieldupgrade5 = "Unlock Fortify";

    private string archerupgrade1 = "Unlock Archer unit";
    private string archerupgrade2 = "Maximum troop capacity: +1\nArcher Power: +5";
    private string archerupgrade3 = "Archer Health: +10\nMaximum troop capacity: +2";
    private string archerupgrade4 = "Archer Power: +15";
    private string archerupgrade5 = "Unlock Volley";

    private string magickaupgrade1 = "Unlock Magicka unit";
    private string magickaupgrade2 = "Magicka Health: +10\n Magicka Power: +5";
    private string magickaupgrade3 = "Magicka Health: +10";
    private string magickaupgrade4 = "Magicka Power: +15\nMaximum troop capacity: +1";
    private string magickaupgrade5 = "Unlock Healing Pulse";

    private string cavalryupgrade1 = "Unlock Cavalry";
    private string cavalryupgrade2 = "Maximum troop capacity: +5";
    private string cavalryupgrade3 = "Cavalry Health: +10\nMaximum troop Capacity: +5";
    private string cavalryupgrade4 = "Cavalry Power: +10";
    private string cavalryupgrade5 = "Unlock Stampede";

    public Text MeleeUpgradeCost;
    public Text SpearmanUpgradeCost;
    public Text ShieldUpgradeCost;
    public Text ArcherUpgradeCost;
    public Text MagickaUpgradeCost;
    public Text CavalryUpgradeCost;

    public ButtonHandler buttonHandler;

    public Text MeleeUpgrade;
    public Text SpearmanUpgrade;
    public Text ShieldUpgrade;
    public Text ArcherUpgrade;
    public Text MagickaUpgrade;
    public Text CavalryUpgrade;

    private void Awake()
    {
        MeleeUpgradeLevel = InitialUpgradeLevel;
        SpearmanUpgradeLevel = InitialUpgradeLevel;
        ShieldUpgradeLevel = InitialUpgradeLevel;
        ArcherUpgradeLevel = InitialUpgradeLevel;
        MagickaUpgradeLevel = InitialUpgradeLevel;
        CavalryUpgradeLevel = InitialUpgradeLevel;
    }

    public void UpgradeInterfaceUpdate(string interfaceupdate)
    {
        switch (interfaceupdate)
        {
            case "Melee":
                meleeUpgradeCost = CalculateUpgradeCost(MeleeUpgradeLevel);
                break;
            case "Spearman":
                spearmanUpgradeCost = CalculateUpgradeCost(SpearmanUpgradeLevel);
                break;
            case "Shield":
                shieldUpgradeCost = CalculateUpgradeCost(ShieldUpgradeLevel);
                break;
            case "Archer":
                archerUpgradeCost = CalculateUpgradeCost(ArcherUpgradeLevel);
                break;
            case "Magicka":
                magickaUpgradeCost = CalculateUpgradeCost(MagickaUpgradeLevel);
                break;
            case "Cavalry":
                cavalryUpgradeCost = CalculateUpgradeCost(CavalryUpgradeLevel);
                break;
            case "All":
                break;
            default:
                break;
        }

        MeleeUpgradeCost.text = meleeUpgradeCost.ToString();
        SpearmanUpgradeCost.text = spearmanUpgradeCost.ToString();
        ShieldUpgradeCost.text = shieldUpgradeCost.ToString();
        ArcherUpgradeCost.text = archerUpgradeCost.ToString();
        MagickaUpgradeCost.text = magickaUpgradeCost.ToString();
        CavalryUpgradeCost.text = cavalryUpgradeCost.ToString();

        MeleeUpgradeText();
        SpearmanupgradeText();
        ShieldUpgradeText();
        ArcherUpgradeText();
        MagickaUpgradeText();
        CavalryUpgradeText();
    }

    private int CalculateUpgradeCost(int classlevel)
    {
        int UpgradeCost;

        UpgradeCost = 150 + (int)((float)classlevel * Random.Range(125f, 151f));
        return UpgradeCost;
    }

    public void BuyUpgrade(string toUpgrade)
    {
        switch (toUpgrade)
        {
            case "Melee":
                if (MeleeUpgradeLevel < 5)
                {
                    Buy(meleeUpgradeCost, "Melee");
                }
                break;
            case "Spearman":
                if (SpearmanUpgradeLevel < 5)
                {
                    Buy(spearmanUpgradeCost, "Spearman");
                }
                break;
            case "Shield":
                if (ShieldUpgradeLevel < 5)
                {
                    Buy(shieldUpgradeCost, "Shield");
                }
                break;
            case "Archer":
                if (ArcherUpgradeLevel < 5)
                {
                    Buy(archerUpgradeCost, "Archer");
                }
                break;
            case "Magicka":
                if (MagickaUpgradeLevel < 5)
                {
                    Buy(magickaUpgradeCost, "Magicka");
                }
                break;
            case "Cavalry":
                if (CavalryUpgradeLevel < 5)
                {
                    Buy(cavalryUpgradeCost, "Cavalry");
                }
                break;
            default:
                Debug.LogError("No Match found!");
                break;
        }
    }

    private void Buy(int price, string update)
    {
        if ((PlayerStats.Money - price) >= 0)
        {
            PlayerStats.Money -= price;
            buttonHandler.ShopSFX(succeed);
            switch (update)
            {
                case "Melee":
                    MeleeUpgradeLevel++;
                    break;
                case "Spearman":
                    SpearmanUpgradeLevel++;
                    break;
                case "Shield":
                    ShieldUpgradeLevel++;
                    break;
                case "Archer":
                    ArcherUpgradeLevel++;
                    break;
                case "Magicka":
                    MagickaUpgradeLevel++;
                    break;
                case "Cavalry":
                    CavalryUpgradeLevel++;
                    break;
                default:
                    break;
            }
            UpgradeInterfaceUpdate(update);
        }
        else
        {
            buttonHandler.ShopSFX(fail);
        }
    }

    private void MeleeUpgradeText()
    {
        switch (MeleeUpgradeLevel)
        {
            case 0:
                MeleeUpgrade.text = meleeupgrade1;

                break;
            case 1:
                MeleeUpgrade.text = meleeupgrade2;
                break;
            case 2:
                MeleeUpgrade.text = meleeupgrade3;
                break;
            case 3:
                MeleeUpgrade.text = meleeupgrade4;
                break;
            case 4:
                MeleeUpgrade.text = meleeupgrade5;
                break;
            case 5:
                MeleeUpgrade.text = maxtierresearch;
                break;
            default:
                Debug.LogError("Non Valid Level");
                break;
        }
    }

    private void SpearmanupgradeText()
    {
        switch (SpearmanUpgradeLevel)
        {
            case 0:
                SpearmanUpgrade.text = spearmanupgrade1;
                break;
            case 1:
                SpearmanUpgrade.text = spearmanupgrade2;
                break;
            case 2:
                SpearmanUpgrade.text = spearmanupgrade3;
                break;
            case 3:
                SpearmanUpgrade.text = spearmanupgrade4;
                break;
            case 4:
                SpearmanUpgrade.text = spearmanupgrade5;
                break;
            case 5:
                SpearmanUpgrade.text = maxtierresearch;
                break;
            default:
                Debug.LogError("Non Valid Level");
                break;
        }
    }

    private void ShieldUpgradeText()
    {
        switch (ShieldUpgradeLevel)
        {
            case 0:
                ShieldUpgrade.text = shieldupgrade1;
                break;
            case 1:
                ShieldUpgrade.text = shieldupgrade2;
                break;
            case 2:
                ShieldUpgrade.text = shieldupgrade3;
                break;
            case 3:
                ShieldUpgrade.text = shieldupgrade4;
                break;
            case 4:
                ShieldUpgrade.text = shieldupgrade5;
                break;
            case 5:
                ShieldUpgrade.text = maxtierresearch;
                break;
            default:
                Debug.LogError("Non Valid Level");
                break;
        }
    }

    private void ArcherUpgradeText()
    {
        switch (ArcherUpgradeLevel)
        {
            case 0:
                ArcherUpgrade.text = archerupgrade1;
                break;
            case 1:
                ArcherUpgrade.text = archerupgrade2;
                break;
            case 2:
                ArcherUpgrade.text = archerupgrade3;
                break;
            case 3:
                ArcherUpgrade.text = archerupgrade4;
                break;
            case 4:
                ArcherUpgrade.text = archerupgrade5;
                break;
            case 5:
                ArcherUpgrade.text = maxtierresearch;
                break;
            default:
                Debug.LogError("Non Valid Level");
                break;
        }
    }

    private void MagickaUpgradeText()
    {
        switch (MagickaUpgradeLevel)
        {
            case 0:
                MagickaUpgrade.text = magickaupgrade1;
                break;
            case 1:
                MagickaUpgrade.text = magickaupgrade2;
                break;
            case 2:
                MagickaUpgrade.text = magickaupgrade3;
                break;
            case 3:
                MagickaUpgrade.text = magickaupgrade4;
                break;
            case 4:
                MagickaUpgrade.text = magickaupgrade5;
                break;
            case 5:
                MagickaUpgrade.text = maxtierresearch;
                break;
            default:
                Debug.LogError("Non Valid Level");
                break;
        }
    }

    private void CavalryUpgradeText()
    {
        switch (CavalryUpgradeLevel)
        {
            case 0:
                CavalryUpgrade.text = cavalryupgrade1;
                break;
            case 1:
                CavalryUpgrade.text = cavalryupgrade2;
                break;
            case 2:
                CavalryUpgrade.text = cavalryupgrade3;
                break;
            case 3:
                CavalryUpgrade.text = cavalryupgrade4;
                break;
            case 4:
                CavalryUpgrade.text = cavalryupgrade5;
                break;
            case 5:
                CavalryUpgrade.text = maxtierresearch;
                break;
            default:
                Debug.LogError("Non Valid Level");
                break;
        }
    }
}
