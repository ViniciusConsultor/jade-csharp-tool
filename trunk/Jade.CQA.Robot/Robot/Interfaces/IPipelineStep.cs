namespace Jade.CQA.Robot.Interfaces
{
    /// <summary>
    /// 管道步骤
    /// </summary>
    public interface IPipelineStep
    {
        void Process(Crawler crawler, PropertyBag propertyBag);
    }
}