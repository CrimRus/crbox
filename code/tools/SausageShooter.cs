namespace Sandbox.Tools
{
	[Library( "tool_sausagegun", Title = "Sausage Shooter", Description = "Shoot sausages", Group = "fun" )]
	public class SausageShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootBox();
				}

			if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootBox();
				}
			}
		}

		void ShootBox()
		{
			var ent = new Prop
			{
				Position = Owner.EyePos + Owner.EyeRot.Forward * 80,
				Rotation = Owner.EyeRot 
			};
			ent.SetModel( "models/citizen_props/hotdog01/hotdog01_lod02.vmdl" );
			
			// ent.SetModel( "models/errorr/error.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 1000;
		}
	}
}
