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

    /// <summary>
    /// Any late loop (e.g Do-While).
    /// </summary>
    public interface ILateLoop : IFluent
    {
        /// <summary>
        /// Performs the while statement using the specifed condition after it has evaluated the previous chained Do statement.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ILoopAction While(Func<bool> condition);
    }

    /// <summary>
    /// Any late loop builder (e.g Do-While)
    /// </summary>
    public interface ILateLoopBuilder : IFluent
    {
        /// <summary>
        /// Performs the while statement using the specified condition statement after evaluating the previous Do statement.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ILoopAction While(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition to be used to break the looping statment lately (before the end of the loop).
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ILateLoop LateBreakOn(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition to be used to break the looping statment early (at the begining of the loop).
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ILateLoop EarlyBreakOn(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition to be used to continue the looping statment lately (before the end of the loop).
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ILateLoop LateContinueOn(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition to be used to continue the looping statment early (at the begining of the loop).
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ILateLoop EarlyContinueOn(Func<bool> condition);
    }
}