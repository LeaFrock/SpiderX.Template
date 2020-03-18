using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppNameX.BllNameX
{
	public sealed partial class BllNameXBll
	{
		private abstract class SchemeBase
		{
			public CollectorBase Collector { get; set; }

			public abstract Task RunAsync(SchemeRunSetting setting);
		}
	}
}