using System;

namespace Fluentx
{
    /// <summary>
    /// Any action might or might not complete successfully.
    /// </summary>
    public interface ITriableAction : IAction
    {
        /// <summary>
        /// Performs the previously chained Try action and swallow any exception that might occur.
        /// </summary>
        /// <returns></returns>
        IAction Swallow();

        /// <summary>
        /// Performs the previously chained Try action and swallow only the specified Exception(s).
        /// </summary>
        /// <typeparam name="TException1"></typeparam>
        /// <returns></returns>
        IAction SwallowIf<TException1>() where TException1 : Exception;

        /// <summary>
        /// Performs the previously chained Try action and swallow only the specified Exception(s).
        /// </summary>
        /// <typeparam name="TException1"></typeparam>
        /// <typeparam name="TException2"></typeparam>
        /// <returns></returns>
        IAction SwallowIf<TException1, TException2>()
            where TException1 : Exception
            where TException2 : Exception;

        /// <summary>
        /// Performs the previously chained Try action and swallow only the specified Exception(s).
        /// </summary>
        /// <typeparam name="TException1"></typeparam>
        /// <typeparam name="TException2"></typeparam>
        /// <typeparam name="TException3"></typeparam>
        /// <returns></returns>
        IAction SwallowIf<TException1, TException2, TException3>()
            where TException1 : Exception
            where TException2 : Exception
            where TException3 : Exception;

        /// <summary>
        /// Performs the previously chained Try action and swallow only the specified Exception(s).
        /// </summary>
        /// <typeparam name="TException1"></typeparam>
        /// <typeparam name="TException2"></typeparam>
        /// <typeparam name="TException3"></typeparam>
        /// <typeparam name="TException4"></typeparam>
        /// <returns></returns>
        IAction SwallowIf<TException1, TException2, TException3, TException4>()
            where TException1 : Exception
            where TException2 : Exception
            where TException3 : Exception
            where TException4 : Exception;

        /// <summary>
        /// Performs the previously chained Try action and catches any exception and performs the specified action for the catch.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IAction Catch(Action<Exception> action);

        /// <summary>
        /// Performs the previously chained Try action and catches the specified exception(s) and performs the specified action for each catch.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        IAction Catch<T>(Action<T> action) where T : Exception;

        /// <summary>
        /// Performs the previously chained Try action and catches the specified exception(s) and performs the specified action for each catch.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="action1"></param>
        /// <param name="action2"></param>
        /// <returns></returns>
        IAction Catch<T1, T2>(Action<T1> action1, Action<T2> action2)
            where T1 : Exception
            where T2 : Exception;
    }
}