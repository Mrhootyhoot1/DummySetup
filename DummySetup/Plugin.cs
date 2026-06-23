/*
 * Copyright (c) 2026 Mrhootyhoot1. All rights reserved.
 * https://github.com/Mrhootyhoot1/DummySetup
 */

using System;
using System.Collections.Generic;
using System.IO;
using DummySetup.API.Features;
using DummySetup.DummySetupRoles;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using YamlDotNet.Serialization;

namespace DummySetup
{
	public class Plugin : Plugin<Config>
	{
		public override string Name { get; } = "DummySetup";
		public override string Prefix { get; } = "DS";
		public override Version Version { get; } = new Version(2026, 6, 22);
		public override string Author { get; } = "Mrhootyhoot1";
		
		internal static Plugin Instance { get; private set; }

		public override void OnEnabled()
		{
			Instance = this;
			if (!Directory.Exists(Config.ConfigDir))
			{
				Log.Info("[Plugin] Config directory not found. Creating...");
				Directory.CreateDirectory(Config.ConfigDir);
			}

			if (!File.Exists(Path.Combine(Config.ConfigDir, Config.ConfigFileName)))
			{
				File.WriteAllText(Path.Combine(Config.ConfigDir, Config.ConfigFileName), new Serializer().Serialize(new List<RPRole> { new RPRole
				{
					RoleName = "ExampleRole",
					Category = "Example",
					RoleType = RoleTypeId.Tutorial,
					LoadOut = new List<ItemType>() 
					{
						ItemType.Coin,
						ItemType.Adrenaline,
					},
					Ammo = new List<RPAmmo>()
					{
						new RPAmmo
						{
							AmmoType = AmmoType.Ammo12Gauge,
							Count = 15
						}
					},
					Buffs = new List<RPEffect> () { 
						new RPEffect
						{
							Duration = 500,
							EffectType = EffectType.MovementBoost,
							Intensity = 100
						}
					},
					RunCommandOnSet = new string[]
					{
						"cinfo %PLAYERID% heylookitscinfo"
					},
					Maxhealth = 100,
					CustomItems = new ushort[]
					{
						1
					}
				}}));
			}
			new DummySetupPanel().CreateRoles();
			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			Instance = null;
			base.OnDisabled();	
		}
	}
}