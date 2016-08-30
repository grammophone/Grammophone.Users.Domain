﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// The credit system, which represents a financial institution or a gateway
	/// through which
	/// </summary>
	[Serializable]
	public class CreditSystem : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// The name of the credit system.
		/// </summary>
		[Required]
		public virtual string Name { get; set; }

		/// <summary>
		/// The code name of the credit system.
		/// </summary>
		[Required]
		public virtual string Code { get; set; }

		#endregion
	}
}