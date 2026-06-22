using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using Exiled.Events.Handlers;
using PlayerRoles;
using UnityEngine;
using YamlDotNet.Serialization;
using Player = Exiled.API.Features.Player;
using Server = Exiled.API.Features.Server;

namespace DummySetup.API.Features
{
	public class RPRole
	{
		public string RoleName { get; set; }
		public string Category { get; set; }
		public RoleTypeId RoleType { get; set; }
		public List<ItemType> LoadOut { get; set; }
		public List<RPAmmo> Ammo { get; set; }
		public List<RPEffect> Buffs { get; set; }
		public string[] RunCommandOnSet { get; set; }
		public float Maxhealth { get; set; }
		public ushort[] CustomItems { get; set; }

		public RPRole() { }

		public void Apply(Player player)
		{
			player.RoleManager.ServerSetRole(RoleType, RoleChangeReason.None, RoleSpawnFlags.None);
			
			foreach (var item in LoadOut.Where(i => i != ItemType.None))
			{
				if (player.Items.Count >= 8)
				{
					Log.Error($"[RPRole] Unable to add items to player when assigning the role {RoleName}. The player's inventory is full.");
					break;
				}
				player.AddItem(item);
			}

			foreach (var id in CustomItems)
			{
				CustomItem customItem = CustomItem.Get(id);
				if (customItem == null)
				{
					Log.Error($"[RPRole] CustomItem not found with id {id} in role {RoleName}. Skipping adding to player inventory.");
					continue;
				}

				if (player.Items.Count >= 8)
				{
					Log.Error($"[RPRole] Unable to add custom items to player when assigning the role {RoleName}. The player's inventory is full.");
					break;
				}
				customItem.Give(player);
			}

			foreach (var ammo in Ammo.Where(a => a.AmmoType != AmmoType.None))
			{
				player.AddAmmo(ammo.AmmoType, ammo.Count);
			}
			
			foreach (var effect in Buffs)
			{
				effect.Apply(player);
			}
			
			player.MaxHealth = Maxhealth;
			player.Health = Maxhealth;

			foreach (string command in RunCommandOnSet)
			{
				Server.ExecuteCommand(FormatCommand(command, player));
			}
		}

		private string FormatCommand(string command, Player player)
		{
			Dictionary<string, string> replaceWith = new Dictionary<string, string>()
			{
				{"%PLAYERID%", player.Id.ToString()},
				{"##", player.Id.ToString()}, // to maintain compatibility with configs that were written before the plugin was made public.
				{"%PLAYERDISPLAYNAME%", player.DisplayNickname},
				{"{NAMEHERE}", player.DisplayNickname}, // to maintain compatibility with configs that were written before the plugin was made public.
				{"%PLAYERNAME%", player.Nickname},
				{"%PLAYERUSERID%", player.UserId},
				{"%PLAYERIP%", player.IPAddress},
				{"%ROLENAME%", RoleName},
				{"%CATEGORY%", Category},
			};

			foreach (var replace in replaceWith)
			{
				command = command.Replace(replace.Key, replace.Value);
			}
			return command;
		}
	}
}