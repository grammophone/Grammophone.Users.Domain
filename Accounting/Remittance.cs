﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// A single-entry accounting record intended to represent
	/// external system inflow or outflow, where a double-entry recording cannot be kept.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="A">The type of account, derived from <see cref="Account{U}"/>.</typeparam>
	[Serializable]
	public abstract class Remittance<U, A> : JournalLine<U, A>
		where U : User
		where A : Account<U>
	{
		#region Primitive properties

		/// <summary>
		/// The ID of the external system transaction.
		/// </summary>
		[Required]
		[MaxLength(256)]
		public virtual string TransactionID { get; set; }

		/// <summary>
		/// Optional ID of the line, when the remittance is part of a batch.
		/// </summary>
		[MaxLength(256)]
		public virtual string LineID { get; set; }

		#endregion

		#region Relationships

		/// <summary>
		/// The ID of the credit system through which 
		/// the <see cref="JournalLine{U, A}.Amount"/> is being transferred.
		/// </summary>
		public virtual long CreditSystemID { get; set; }

		/// <summary>
		/// The credit system through which 
		/// the <see cref="JournalLine{U, A}.Amount"/> is being transferred.
		/// </summary>
		public virtual CreditSystem CreditSystem { get; set; }

		#endregion
	}
}
