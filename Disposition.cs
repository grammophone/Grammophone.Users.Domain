﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A participation of a user to a segregation of the system.
	/// </summary>
	/// <remarks>
	/// In derived classes, if you want to create a foreign key from <see cref="SegregationID"/>
	/// to a strong-type navigation property, typically of type <see cref="Segregation{U}"/>,
	/// either add a [ForeignKey("SegregationID")] attribute to it or set it manually
	/// according to your data access implementation. 
	/// For Entity Framework 6.1.x, only the first approach seems to work.
	/// </remarks>
	/// <example>
	/// <code>
	/// [ForeignKey("SegregationID")]
	/// public virtual Companies.Company Company { get; set; }
	/// </code> 
	/// </example>
	[Serializable]
	public abstract class Disposition : UserTrackingEntityWithID<User, long>
	{
		#region Primitive properties

		/// <summary>
		/// The state of this disposition.
		/// </summary>
		public virtual DispositionState State { get; set; }

		/// <summary>
		/// The ID of the segregation.
		/// </summary>
		public virtual long SegregationID { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The owner of the disposition.
		/// </summary>
		/// <remarks>
		/// This override removes the inherited IgnoreMember attribute,
		/// in order to make the property accessible.
		/// </remarks>
		public override User OwningUser
		{
			get
			{
				return base.OwningUser;
			}
			set
			{
				base.OwningUser = value;
			}
		}

		/// <summary>
		/// The ID of the type of this disposition.
		/// </summary>
		public virtual long TypeID { get; set; }

		/// <summary>
		/// The type of this disposition.
		/// </summary>
		public virtual DispositionType Type { get; set; }

		#endregion
	}

	/// <summary>
	/// A participation of a user to a segregation of the system,
	/// with strong-type reference to the user.
	/// </summary>
	/// <typeparam name="U">The type of the user.</typeparam>
	/// <typeparam name="S">The type of segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	[Serializable]
	public abstract class Disposition<U, S> : Disposition
		where U : User
	{
		#region Relations

		/// <summary>
		/// The segregation.
		/// </summary>
		public virtual S Segregation { get; set; }

		#endregion
	}
}
