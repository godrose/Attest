namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">The type of the method callback.</typeparam>
    public interface IHaveNoCallbacks<TCallback> : IAddCallback<TCallback>
    {

    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>    
    /// <typeparam name="T">Type of parameter</typeparam>
    public interface IHaveNoCallbacks<TCallback, T> : IAddCallback<TCallback, T>
    {
    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    public interface IHaveNoCallbacks<TCallback, T1, T2> : IAddCallback<TCallback, T1, T2>
    {
    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    public interface IHaveNoCallbacks<TCallback, T1, T2, T3> : IAddCallback<TCallback, T1, T2, T3>
    {
    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>    
    public interface IHaveNoCallbacks<TCallback, T1, T2, T3, T4> : IAddCallback<TCallback, T1, T2, T3, T4>
    {
    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    public interface IHaveNoCallbacks<TCallback, T1, T2, T3, T4, T5> : IAddCallback<TCallback, T1, T2, T3, T4, T5>
    {
    }    
}