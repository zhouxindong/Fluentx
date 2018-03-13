using System;

namespace Fluentx
{
    /// <summary>
    /// Switch statement builder.
    /// </summary>
    public interface ISwitchBuilder : IFluent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="compare_operand"></param>
        /// <returns></returns>
        ISwitchCaseBuilder Case<T>(T compare_operand);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IAction Default(Action action);
    }

    /// <summary>
    /// Switch case statement builder.
    /// </summary>
    public interface ISwitchCaseBuilder : IFluent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        ISwitchBuilder Execute(Action action);
    }

    /// <summary>
    /// Switch statement for Types builder.
    /// </summary>
    public interface ISwitchTypeBuilder : IFluent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ISwitchTypeCaseBuilder Case<T>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IAction Default(Action action);
    }

    /// <summary>
    /// Switch case statement for types builder.
    /// </summary>
    public interface ISwitchTypeCaseBuilder : IFluent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        ISwitchTypeBuilder Execute(Action action);
    }
}
