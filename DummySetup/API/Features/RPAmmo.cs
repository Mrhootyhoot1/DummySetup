/*
 * Copyright (c) 2026 Mrhootyhoot1. All rights reserved.
 * https://github.com/Mrhootyhoot1/DummySetup
 */

using Exiled.API.Enums;

namespace DummySetup.API.Features
{
	public class RPAmmo
	{
		public AmmoType AmmoType { get; set; }
		public ushort Count { get; set; }

		public RPAmmo() { }
	}
}