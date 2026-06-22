using Exiled.API.Enums;
using Exiled.API.Features;

namespace DummySetup.API.Features
{
	public class RPEffect
	{
		public EffectType EffectType { get; set; }
		public byte Intensity { get; set; }
		public int Duration { get; set; }
    
		public RPEffect() { }

		public void Apply(Player player)
		{
			player.EnableEffect(EffectType, Intensity, Duration);
		}
	}
}