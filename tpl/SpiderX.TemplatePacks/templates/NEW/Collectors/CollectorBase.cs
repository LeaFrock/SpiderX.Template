using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNameX.BllNameX
{
	public sealed partial class BllNameXBll
	{
		private abstract class CollectorBase
		{
			public abstract Task<CollectResult> CollectAsync(CollectSetting setting);

			protected virtual IProxyUriLoader CreateProxyUriLoader()
			{
			}
		}
	}
}