﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Workflow
{
	/// <summary>
	/// A directged graph of states representing a workflow.
	/// </summary>
	[Serializable]
	public class WorkflowGraph : EntityWithID<long>
	{
		#region Private fields

		private ICollection<StateGroup> stateGroups;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The code name of the workflow graph.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// The name of the workflow graph.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// The description of the workflow graph.
		/// </summary>
		public virtual string Description { get; set; }

		/// <summary>
		/// The full name of the <see cref="StateTransition{U}"/> descendant type which
		/// is assigned to work in this workflow graph.
		/// It defines the type of <see cref="IStateful{U, ST}"/> objects 
		/// this workflow graph works on, since ST is the type of the state transition.
		/// </summary>
		[Required]
		[MaxLength(256)]
		public virtual string StateTransitionTypeName { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The groups of states in this workflow.
		/// </summary>
		public virtual ICollection<StateGroup> StateGroups
		{
			get
			{
				return stateGroups ?? (stateGroups = new HashSet<StateGroup>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				stateGroups = value;
			}
		}

		#endregion
	}
}
