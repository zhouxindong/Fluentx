using System;

namespace Fluentx
{
    /// <summary>
    /// Any condition action.
    /// </summary>
    public interface IConditionalAction : IAction
    {
        /// <summary>
        /// Performs the else part of the if statement its chained to.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IAction Else(Action action);

        /// <summary>
        /// Prepares for the extra ElseIf condition, this requires the call to Then eventually.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder ElseIf(Func<bool> condition);

        /// <summary>
        /// Prepares for the extra ElseIf condition, this requires the call to Then eventually.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder ElseIf(bool condition);
    }

    /// <summary>
    /// Any condition builder.
    /// </summary>
    public interface IConditionBuilder : IFluent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IConditionalAction Then(Action action);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using AND.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder And(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using AND.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder And(bool condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using AND NOT.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder AndNot(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using AND NOT.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder AndNot(bool condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using OR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Or(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using OR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Or(bool condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using OR NOT.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder OrNot(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using OR NOT.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder OrNot(bool condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using XOR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Xor(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using XOR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Xor(bool condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using XNOR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Xnor(Func<bool> condition);

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using XNOR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Xnor(bool condition);
    }
}