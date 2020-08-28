using Stellarium.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Stellarium.Items.MagusClass;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Stellarium.Items.HoleClass;

namespace Stellarium
{
	public class Stellarium : Mod
	{
		private UserInterface _MagusCataBarUserInterface;
		private UserInterface _MagusDivineBarUserInterface;
		private UserInterface _MagusSataBarUserInterface;
		private UserInterface _HoleEnergyBarUserInterface;
		internal MagusCataBar MagusCataBar;
		internal MagusDivineBar MagusDivineBar;
		internal MagusSataBar MagusSataBar;
		internal HoleEnergyBar HoleEnergyBar;

		public static DynamicSpriteFont StellariumFont;

		public Stellarium()
		{

		}

		public override void Load()
		{
			Logger.InfoFormat("{0} Stellarium logging", Name);

			if (!Main.dedServ)
			{
				// Cata Bar
				MagusCataBar = new MagusCataBar();
				_MagusCataBarUserInterface = new UserInterface();
				_MagusCataBarUserInterface.SetState(MagusCataBar);

				// Divine Bar
				MagusDivineBar = new MagusDivineBar();
				_MagusDivineBarUserInterface = new UserInterface();
				_MagusDivineBarUserInterface.SetState(MagusDivineBar);

				// Sata Bar
				MagusSataBar = new MagusSataBar();
				_MagusSataBarUserInterface = new UserInterface();
				_MagusSataBarUserInterface.SetState(MagusSataBar);

				// Hole Bar
				HoleEnergyBar = new HoleEnergyBar();
				_HoleEnergyBarUserInterface = new UserInterface();
				_HoleEnergyBarUserInterface.SetState(HoleEnergyBar);
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			_MagusCataBarUserInterface?.Update(gameTime);
			_MagusDivineBarUserInterface?.Update(gameTime);
			_MagusSataBarUserInterface?.Update(gameTime);
			_HoleEnergyBarUserInterface?.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int ResourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (ResourceBarIndex != -1)
			{
				layers.Insert(ResourceBarIndex, new LegacyGameInterfaceLayer( //Cata
					"Stellarium: Magus Cata Bar",
					delegate
					{
						_MagusCataBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
				layers.Insert(ResourceBarIndex, new LegacyGameInterfaceLayer( //Divine
					"Stellarium: Magus Divine Bar",
					delegate
                    {
						_MagusDivineBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
                    },
					InterfaceScaleType.UI)
				);
				layers.Insert(ResourceBarIndex, new LegacyGameInterfaceLayer( //Sata
					"Stellarium: Magus Sata Bar",
					delegate
					{
						_MagusSataBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
				layers.Insert(ResourceBarIndex, new LegacyGameInterfaceLayer(
					"Stellarium: Hole Energy Bar",
					delegate
					{
						_HoleEnergyBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}