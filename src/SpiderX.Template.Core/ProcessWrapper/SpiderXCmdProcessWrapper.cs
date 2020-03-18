using SpiderX.Template.Common.Enums;
using SpiderX.Template.Common.Process;

namespace SpiderX.Template.Core.ProcessWrapper
{
    public abstract class SpiderXCmdProcessWrapper
    {
        protected abstract ICmdProcessCaller Caller { get; }

        public abstract ResultCodeEnum Generate();
    }
}