namespace SpiderX.Template.Common.Process
{
    public interface ICmdProcessCaller
    {
        System.Diagnostics.Process Call(string init);
    }
}