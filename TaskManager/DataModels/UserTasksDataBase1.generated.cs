//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/t4models).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : UserTasks
	/// Data Source    : UserTasks
	/// Server Version : 3.14.2
	/// </summary>
	public partial class UserTasksDB : LinqToDB.Data.DataConnection
	{
		public ITable<NotifyDate> NotifyDates { get { return this.GetTable<NotifyDate>(); } }
		public ITable<TaskDate>   TaskDates   { get { return this.GetTable<TaskDate>(); } }
		public ITable<UserTask>   UserTasks   { get { return this.GetTable<UserTask>(); } }

		public UserTasksDB()
		{
			InitDataContext();
		}

		public UserTasksDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
		}

		partial void InitDataContext();
	}

	[Table("NotifyDates")]
	public partial class NotifyDate
	{
		[Column("id"),   PrimaryKey, Identity] public long   Id   { get; set; } // integer
		[Column("date"), NotNull             ] public string Date { get; set; } // text(max)

		#region Associations

		/// <summary>
		/// FK_UserTasks_0_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="NotifyDateID", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<UserTask> UserTasks { get; set; }

		#endregion
	}

	[Table("TaskDates")]
	public partial class TaskDate
	{
		[Column("id"),   PrimaryKey, Identity] public long   Id   { get; set; } // integer
		[Column("date"), NotNull             ] public string Date { get; set; } // text(max)

		#region Associations

		/// <summary>
		/// FK_UserTasks_1_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TaskDateID", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<UserTask> UserTasks { get; set; }

		#endregion
	}

	[Table("UserTasks")]
	public partial class UserTask
	{
		[Column("id"),           PrimaryKey,  Identity] public long   Id           { get; set; } // integer
		[Column("name"),         NotNull              ] public string Name         { get; set; } // text(max)
		[Column("description"),     Nullable          ] public string Description  { get; set; } // text(max)
		[Column("priority"),     NotNull              ] public string Priority     { get; set; } // text(max)
		[Column("taskDateID"),   NotNull              ] public long   TaskDateID   { get; set; } // integer
		[Column("notifyDateID"), NotNull              ] public long   NotifyDateID { get; set; } // integer

		#region Associations

		/// <summary>
		/// FK_UserTasks_0_0
		/// </summary>
		[Association(ThisKey="NotifyDateID", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_UserTasks_0_0", BackReferenceName="UserTasks")]
		public NotifyDate NotifyDate { get; set; }

		/// <summary>
		/// FK_UserTasks_1_0
		/// </summary>
		[Association(ThisKey="TaskDateID", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_UserTasks_1_0", BackReferenceName="UserTasks")]
		public TaskDate TaskDate { get; set; }

		#endregion
	}

	public static partial class TableExtensions
	{
		public static NotifyDate Find(this ITable<NotifyDate> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TaskDate Find(this ITable<TaskDate> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static UserTask Find(this ITable<UserTask> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}
