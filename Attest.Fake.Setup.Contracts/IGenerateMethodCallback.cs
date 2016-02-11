namespace Attest.Fake.Setup.Contracts
{    
    /// <summary>
    /// Generates method callback by evaluating provided parameters.
    /// This contract is internal and is not meant to be used from the code.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>    
    public interface IGenerateMethodCallback<T>
    {
        /// <summary>
        /// Generates callback.
        /// </summary>
        /// <param name="arg">The parameter.</param>        
        void GenerateCallback(T arg);
    }

    /// <summary>
    /// Generates method callback by evaluating provided parameters.
    /// This contract is internal and is not meant to be used from the code.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>    
    public interface IGenerateMethodCallback<T1, T2>
    {
        /// <summary>
        /// Generates callback.
        /// </summary>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>       
        void GenerateCallback(T1 arg1, T2 arg2);
    }

    /// <summary>
    /// Generates method callback by evaluating provided parameters.
    /// This contract is internal and is not meant to be used from the code.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    public interface IGenerateMethodCallback<T1, T2, T3>
    {
        /// <summary>
        /// Generates callback.
        /// </summary>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        void GenerateCallback(T1 arg1, T2 arg2, T3 arg3);
    }

    /// <summary>
    /// Generates method callback by evaluating provided parameters.
    /// This contract is internal and is not meant to be used from the code.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    public interface IGenerateMethodCallback<T1, T2, T3, T4>
    {
        /// <summary>
        /// Generates callback.
        /// </summary>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        void GenerateCallback(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    /// <summary>
    /// Generates method callback by evaluating provided parameters.
    /// This contract is internal and is not meant to be used from the code.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    public interface IGenerateMethodCallback<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Generates callback.
        /// </summary>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        void GenerateCallback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }
}