/*
 * Copyright (c) 2026 Mrhootyhoot1. All rights reserved.
 * https://github.com/Mrhootyhoot1/DummySetup
 */

using System.IO;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace DummySetup
{
	public class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;
		public bool Debug { get; set; } = false;
		public string ConfigDir { get; set; } = Path.Combine(Paths.Configs, "DummySetup");
		public string ConfigFileName { get; set; } = "DummySetupRoles.yaml";
	}
}