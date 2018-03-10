using System;

namespace Fluentx
{
    /// <summary>
    /// Any loop action.
    /// </summary>
    public interface ILoopAction : IAction
    {
    }

    /// <summary>
    /// Any early loop (e.g while).
    /// </summary>
    public interface IEarlyLoop : IFluent
    {
        /// <summary>
        /// Performs the Do statement after evaluating the previous looping statement.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        ILoopAction Do(Action action);
    }

    /// <summary>
    /// Any early loop builder (e.g while)
    /// </summary>
    public interface IEarlyLoopBuilder : IFluent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        ILoopAction Do(Action action);

        /// <summary>
        /// Evaluates the specified condition to be used to break the looping statment lately (before the end of the loop).
        /// While-Do-LateBreakOn
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEarlyLoop LateBreakOn(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition to be used to break the looping statment early (at the begining of the loop).
        /// While-EarlyBreakOn-Do
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEarlyLoop EarlyBreakOn(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition to be used to continue the looping statment lately (before the end of the loop).
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEarlyLoop LateContinueOn(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition to be used to continue the looping statment early (at the begining of the loop).
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEarlyLoop EarlyContinueOn(Func<bool> condition);
    }
}