using System;

namespace Fluentx
{
    /// <summary>
    /// Flux is the main class for Fluentx and its a shortened name for Fluentx
    /// </summary>
    public class Flux : IConditionBuilder, IConditionalAction, ILoopAction, IEarlyLoop, IEarlyLoopBuilder
    {
        private Flux()
        {
        }

        private Func<bool> ConditionValue { get; set; }
        private bool StopConditionEvaluation { get; set; }

        private enum LoopStoperLocations
        {
            BeginingOfTheLoop,
            EndOfTheLoop
        }

        private LoopStoperLocations LoopStoperLocation { get; set; }
        private Func<bool> LoopStoperConditionalAction { get; set; }

        private enum LoopStopers
        {
            Break,
            Continue
        };
        private LoopStopers LoopStoper { get; set; }
        private bool LoopStoperCondition { get; set; }


        #region conditional

        /// <summary>
        /// Prepare for the excution of IF statement, requires the call to Then eventually.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IConditionBuilder If(Func<bool> condition)
        {
            var instance = new Flux {ConditionValue = condition};
            return instance;
        }

        public static IConditionBuilder If(bool condition)
        {
            return If(() => condition);
        }

        /// <summary>
        /// Performs the action for the previous conditional control statment (If, ElseIf).
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IConditionalAction IConditionBuilder.Then(Action action)
        {
            if (!ConditionValue() || StopConditionEvaluation) return this;
            StopConditionEvaluation = true;
            action();
            return this;
        }

        /// <summary>
        /// Performs the else part of the if statement its chained to.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IAction IConditionalAction.Else(Action action)
        {
            if (ConditionValue() || StopConditionEvaluation) return this;
            StopConditionEvaluation = true;
            action();
            return this;
        }

        /// <summary>
        /// Prepares for the extra ElseIf condition, this requires the call to Then eventually.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionalAction.ElseIf(Func<bool> condition)
        {
            ConditionValue = condition;
            return this;
        }

        /// <summary>
        /// Prepares for the extra ElseIf condition, this requires the call to Then eventually.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionalAction.ElseIf(bool condition)
        {
            ConditionValue = () => condition;
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using AND.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.And(Func<bool> condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation && condition();
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using AND.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.And(bool condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation && condition;
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using AND NOT.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.AndNot(Func<bool> condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation && !condition();
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using AND NOT.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.AndNot(bool condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation && !condition;
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using OR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.Or(Func<bool> condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation || condition();
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using OR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.Or(bool condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation || condition;
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using OR NOT.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.OrNot(Func<bool> condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation || !condition();
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using OR NOT.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.OrNot(bool condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation || !condition;
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using XOR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.Xor(Func<bool> condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation ^ condition();
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using XOR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.Xor(bool condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => previous_evaluation ^ condition;
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using XNOR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.Xnor(Func<bool> condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => !(previous_evaluation ^ condition());
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition with the previously chained condition using XNOR.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IConditionBuilder IConditionBuilder.Xnor(bool condition)
        {
            var previous_evaluation = ConditionValue();
            ConditionValue = () => !(previous_evaluation ^ condition);
            return this;
        }

        #endregion

        #region loop

        /// <summary>
        /// Performs a while control using the evaluation condition for the specified action.
        /// While condition, Do action
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IAction While(Func<bool> condition, Action action)
        {
            var instance = new Flux();
            while (condition())
            {
                action();
            }
            return instance;
        }

        /// <summary>
        /// Prepare for the excution of a while statement using the specified condition, this requires the call to Do eventually.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IEarlyLoopBuilder While(Func<bool> condition)
        {
            var instance = new Flux { ConditionValue = condition };
            return instance;
        }

        /// <summary>
        /// Performs the specified action after evaluating the previous looping statement.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        ILoopAction IEarlyLoopBuilder.Do(Action action)
        {
            while (ConditionValue())
            {
                action();
            }
            return this;
        }

        /// <summary>
        /// Performs the Do statement after evaluating the previous looping statement.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        ILoopAction IEarlyLoop.Do(Action action)
        {
            while (ConditionValue())
            {
                if (LoopStoperLocation == LoopStoperLocations.BeginingOfTheLoop)
                {
                    if (LoopStoperConditionalAction != null)
                    {
                        if (LoopStoperConditionalAction())
                        {
                            if (LoopStoper == LoopStopers.Break)
                            {
                                break;
                            }
                            continue;
                        }
                    }
                    else
                    {
                        if (LoopStoperCondition)
                        {
                            if (LoopStoper == LoopStopers.Break)
                            {
                                break;
                            }
                            continue;
                        }
                    }
                }
                action();

                if (LoopStoperLocation == LoopStoperLocations.EndOfTheLoop)
                {
                    if (LoopStoperConditionalAction != null)
                    {
                        if (LoopStoperConditionalAction())
                        {
                            if (LoopStoper == LoopStopers.Break)
                            {
                                break;
                            }
                            continue;
                        }
                    }
                    else
                    {
                        if (LoopStoperCondition)
                        {
                            if (LoopStoper == LoopStopers.Break)
                            {
                                break;
                            }
                            continue;
                        }
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition to be used to break the looping statment lately (before the end of the loop).
        /// While-Do-LateBreakOn
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEarlyLoop IEarlyLoopBuilder.LateBreakOn(Func<bool> condition)
        {
            LoopStoperConditionalAction = condition;
            LoopStoperLocation = LoopStoperLocations.EndOfTheLoop;
            LoopStoper = LoopStopers.Break;
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition to be used to break the looping statment early (at the begining of the loop).
        /// While-EarlyBreakOn-Do
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEarlyLoop IEarlyLoopBuilder.EarlyBreakOn(Func<bool> condition)
        {
            LoopStoperConditionalAction = condition;
            LoopStoperLocation = LoopStoperLocations.BeginingOfTheLoop;
            LoopStoper = LoopStopers.Break;
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition to be used to continue the looping statment lately (before the end of the loop).
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEarlyLoop IEarlyLoopBuilder.LateContinueOn(Func<bool> condition)
        {
            LoopStoperConditionalAction = condition;
            LoopStoperLocation = LoopStoperLocations.EndOfTheLoop;
            LoopStoper = LoopStopers.Continue;
            return this;
        }

        /// <summary>
        /// Evaluates the specified condition to be used to continue the looping statment early (at the begining of the loop).
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEarlyLoop IEarlyLoopBuilder.EarlyContinueOn(Func<bool> condition)
        {
            LoopStoperConditionalAction = condition;
            LoopStoperLocation = LoopStoperLocations.BeginingOfTheLoop;
            LoopStoper = LoopStopers.Continue;
            return this;
        }

        #endregion
    }
}