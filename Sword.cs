using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sword_Mod
{
    public class Sword : ModItem
    {
        public const string TooltipDescription = "Description";
        public new const string DisplayName = "Sword Mod";

        public const int Damage = 60;
        public const int Width = 20;
        public const int Height = 20;
        public const int UseTime = 15;
        public const int UseAnimation = 15;
        public const int Knockback = 5;
        public const int MaxStack = 1;
        public const int Value = 1;
        public const int CriticalStrikeChance = 10;
        public const int AlternativeUse = 2;
        public const int AlternativeUseShootSpeed = 20;

        public override string Texture => "Terraria/Item_" + ItemID.FieryGreatsword;

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault(Sword.DisplayName);
            Tooltip.SetDefault(Sword.TooltipDescription);
        }

        public override void SetDefaults()
        {

            item.damage = Sword.Damage;
            item.melee = true;
            item.width = Sword.Width;
            item.height = Sword.Height;
            item.useTime = Sword.UseTime;
            item.useAnimation = Sword.UseAnimation;
            item.knockBack = Sword.Knockback;
            item.value = Item.buyPrice(gold: Sword.Value);
            item.maxStack = Sword.MaxStack;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = Sword.CriticalStrikeChance;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.color = Color.Navy;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FieryGreatsword);
            recipe.AddIngredient(ItemID.DarkShard);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == AlternativeUse)
            {
                item.useStyle = ItemUseStyleID.Stabbing;
                item.shoot = ProjectileID.DemonScythe;
                item.shootSpeed = Sword.AlternativeUseShootSpeed;
            }
            else
            {
                item.useStyle = ItemUseStyleID.SwingThrow;
                item.shoot = ProjectileID.None;
            }
            return base.CanUseItem(player);
        }


    }
}
