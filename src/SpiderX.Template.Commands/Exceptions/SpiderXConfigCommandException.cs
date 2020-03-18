using System;

namespace SpiderX.Template.Commands.Exceptions
{
    public class SpiderXConfigCommandException : ArgumentException
    {
        public SpiderXConfigCommandException(ISpiderXCommandBuilder builder, Exception exp = null) : base($"config error occurs in CommandBuilder: `{builder.ShortName}`", exp)
        {
        }
    }
}