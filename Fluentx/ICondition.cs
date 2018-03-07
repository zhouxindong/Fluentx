using System;

namespace Fluentx
{
    /// <summary>
    /// Any condition action.
    /// </summary>
    public interface IConditionalAction : IAction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IAction Else(Action action);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder ElseIf(Func<bool> condition);
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder And(Func<bool> condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder And(bool condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder AndNot(Func<bool> condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder AndNot(bool condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Or(Func<bool> condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Or(bool condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder OrNot(Func<bool> condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder OrNot(bool condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Xor(Func<bool> condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Xor(bool condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Xnor(Func<bool> condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder Xnor(bool condition);
    }
}