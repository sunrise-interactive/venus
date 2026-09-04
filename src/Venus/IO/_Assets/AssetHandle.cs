using System.Diagnostics.CodeAnalysis;

namespace Venus.IO;

public readonly struct AssetHandle<TValue> : IEquatable<AssetHandle<TValue>> where TValue : class
{
    /// <summary>
    ///     The invalid asset handle.
    /// </summary>
    public static readonly AssetHandle<TValue> Invalid = new(ulong.MaxValue);

    /// <summary>
    ///     The value of the asset handle.
    /// </summary>
    public readonly ulong Value;

    /// <summary>
    ///     Gets a value indicating whether the asset handle is valid.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the asset handle is valid; otherwise, <see langword="false" />.
    /// </value>
    public readonly bool Valid => Value != ulong.MaxValue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AssetHandle{TValue}" /> struct with the specified
    ///     value.
    /// </summary>
    /// <param name="value">
    ///     The value of the asset handle.
    /// </param>
    internal AssetHandle(ulong value) => Value = value;

    /// <inheritdoc />
    public readonly override int GetHashCode() => Value.GetHashCode();

    /// <summary>
    ///     Determines whether the current asset handle is equal to an object.
    /// </summary>
    /// <param name="obj">
    ///     The object to compare with the current asset handle.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the current asset handle is equal to the object; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public readonly override bool Equals([NotNullWhen(true)] object? obj) => obj is AssetHandle<TValue> other && Equals(other);

    /// <summary>
    ///     Determines whether the current asset handle is equal to another asset handle.
    /// </summary>
    /// <param name="other">
    ///     The other asset handle to compare with the current asset handle.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the current asset handle is equal to the other asset handle;
    ///     otherwise, <see langword="false" />.
    /// </returns>
    public readonly bool Equals(AssetHandle<TValue> other) => Value == other.Value;

    public static bool operator ==(AssetHandle<TValue> left, AssetHandle<TValue> right) => left.Equals(right);

    public static bool operator !=(AssetHandle<TValue> left, AssetHandle<TValue> right) => !left.Equals(right);
}