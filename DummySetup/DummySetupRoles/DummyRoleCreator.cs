/*
 * Copyright (c) 2026 Mrhootyhoot1. All rights reserved.
 * https://github.com/Mrhootyhoot1/DummySetup
 */

using System;
using System.Collections.Generic;
using DummySetup.API.Features;
using Exiled.API.Features;
using NetworkManagerUtils.Dummies;
using RaCustomMenuExiled.API;

namespace DummySetup.DummySetupRoles
{
	internal class DummyRoleCreator : Provider
	{
		private List<RPRole> _roles;
		public override string CategoryName { get; }

		public DummyRoleCreator(string categoryName, List<RPRole> roles)
		{
			if (String.IsNullOrEmpty(categoryName))
			{
				throw new NullReferenceException("[DummySetupPanel] Unable to assign roles to an action. CategoryName is null or empty.");
			}
			this.CategoryName = categoryName;
			this._roles = roles;
		}
		
		public override List<DummyAction> AddAction(ReferenceHub hub)
		{
			List<DummyAction> dummyAction = new List<DummyAction>();
			foreach (var role in _roles)
			{
				dummyAction.Add(new DummyAction(role.RoleName, () =>
				{
					role.Apply(Player.Get(hub));
				}));
			}
			return dummyAction;
		}
		
		public override bool IsDirty { get; } = true;
	}
}