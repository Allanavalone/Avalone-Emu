﻿namespace Stump.ORM.SubSonic.Repository
{
	internal static class SimpleRepositoryOptionsExtensions
	{
		public static bool Contains(this SimpleRepositoryOptions options, SimpleRepositoryOptions flag)
		{
			return (options & flag) == flag;
		}
	}
}