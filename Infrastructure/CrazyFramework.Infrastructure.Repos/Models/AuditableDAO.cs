﻿using System;

namespace CrazyFramework.Infrastructure.Repos.Models
{
	public abstract class AuditableDAO : BaseDAO
	{
		public DateTimeOffset? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTimeOffset? LastModifyDate { get; set; }
		public string LastModifiedBy { get; set; }
	}
}