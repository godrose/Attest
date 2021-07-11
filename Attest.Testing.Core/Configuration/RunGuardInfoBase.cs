namespace Attest.Testing.Configuration
{
    /// <summary>
    /// Represents base class for run guard information holders.
    /// </summary>
    public abstract class RunGuardInfoBase : IRunGuardInfo
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RunGuardInfoBase"/>
        /// </summary>
        /// <param name="key">The associated key</param>
        protected RunGuardInfoBase(string key)
        {
            Key = key;
        }

        /// <inheritdoc />
        public string Key { get; }

        /// <summary>
        /// Override to provide the value which will allows to pass the guard.
        /// </summary>
        protected abstract object TruthyValue { get; }

        /// <summary>
        /// Override to inject custom parsing logic for the provided input.
        /// </summary>
        /// <param name="input">The provided input.</param>
        /// <returns>The parsed value.</returns>
        protected abstract object ParseValue(string input);

        /// <inheritdoc />
        public bool CanRun(string input)
        {
            var parsedValue = ParseValue(input);
            return TruthyValue == null ? 
                parsedValue == null : 
                parsedValue != null && parsedValue.Equals(TruthyValue);
        }
    }
}