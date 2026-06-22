using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DummySetup.API.Features;
using RaCustomMenuExiled.API;
using YamlDotNet.Serialization;

namespace DummySetup.DummySetupRoles
{
	public class DummySetupPanel
	{
		internal List<RPRole> AllRoles { get; set; } = new List<RPRole>();
		private Dictionary<string, List<RPRole>> _categories = new Dictionary<string, List<RPRole>>();
		private List<DummyRoleCreator> _creators = new List<DummyRoleCreator>();

		internal void DeserializeRoles()
		{
			AllRoles = new Deserializer().Deserialize<List<RPRole>>(File.ReadAllText(Path.Combine(Plugin.Instance.Config.ConfigDir,
				Plugin.Instance.Config.ConfigFileName)));
		}
		
		internal void CreateRoles()
		{
			DeserializeRoles();
			//Ig I could have publicized the assembly
			MethodInfo registerProvider = typeof(Provider).GetMethod(
				"RegisterProviders",
				BindingFlags.NonPublic | BindingFlags.Static,
				null, 
				new Type[] { typeof(Provider) }, 
				null 
			);

			if (registerProvider == null)
			{
				throw new MissingMethodException(
					"Could not find method RegisterProviders. Are you missing the CustomRAMenu dependency?");
			}
        
			foreach (var role in AllRoles)
			{
				if (!_categories.ContainsKey(role.Category))
				{
					_categories.Add(role.Category, new List<RPRole>() {role});
				}
				else
				{
					_categories[role.Category].Add(role);
				}
			}

			foreach (var kvp in _categories)
			{
				var creator = new DummyRoleCreator(kvp.Key, kvp.Value);
				registerProvider.Invoke(null, new object[] { creator });
				_creators.Add(creator);
			}
		}
	}
}