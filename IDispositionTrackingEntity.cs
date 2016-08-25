﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Contract for entities supporting user disposition ownership and change tracking.
	/// These are entities that inherently belong to a <see cref="Segregation{U}"/>.
	/// </summary>
	public interface IDispositionTrackingEntity : IUserTrackingEntity, ISegregationTrackingEntity
	{
		/// <summary>
		/// The ID of the disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		long OwnerDispositionID { get; set; }
	}

	/// <summary>
	/// Strong-type contract for entities supporting user disposition ownership and change tracking.
	/// These are entities that inherently belong to a <see cref="Segregation{U}"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	/// <typeparam name="D">The type of the disposition, derived from <see cref="Disposition{U}"/>.</typeparam>
	public interface IDispositionTrackingEntity<U, S, D> : 
		IDispositionTrackingEntity, IUserTrackingEntity<U>, ISegregationTrackingEntity<U, S>
		where U : User
		where S : Segregation<U>
		where D : Disposition<U>
	{
		/// <summary>
		/// The disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		D OwnerDisposition { get; set; }
	}
}
