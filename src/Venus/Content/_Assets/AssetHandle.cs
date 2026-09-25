using System.Diagnostics.CodeAnalysis;

namespace Venus.Content;

public readonly struct AssetHandle<TValue> : IEquatable<AssetHandle<TValue>> where TValue : class
{
    /// <summary>
    ///     Represents an invalid asset handle.
    /// </summary>
    public static readonly AssetHandle<TValue> Invalid = default;

    private readonly ulong _pack;

    /// <summary>
    ///     Gets a value indicating whether the asset handle is valid.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the asset handle is valid; otherwise, <see langword="false" />.
    /// </value>
    public readonly bool Valid => _pack != 0;
    
    /// <summary>
    ///     Gets the index of the asset handle.
    /// </summary>
    public readonly uint Index => (uint)_pack;
        
    /// <summary>
    ///     Gets the generation of the asset handle.
    /// </summary>
    public readonly uint Generation => (uint)(_pack >> 32);

    /// <summary>
    ///     Initializes a new instance of the <see cref="AssetHandle{TValue}"/> struct.
    /// </summary>
    /// <param name="index">
    ///     The index of the asset handle.
    /// </param>
    /// <param name="generation">
    ///     The generation of the asset handle.
    /// </param>
    internal AssetHandle(uint index, uint generation) => _pack = ((ulong)generation << 32) | index;

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
    public readonly bool Equals(AssetHandle<TValue> other) => _pack == other._pack;
    
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
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is AssetHandle<TValue> other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => _pack.GetHashCode();

    /// <summary>
    ///     Determines whether two asset handles are equal.
    /// </summary>
    /// <param name="left">
    ///     The left asset handle to compare.
    /// </param>
    /// <param name="right">
    ///     The right asset handle to compare.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the two asset handles are equal; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator ==(AssetHandle<TValue> left, AssetHandle<TValue> right) => left.Equals(right);

    /// <summary>
    ///     Determines whether two asset handles are not equal.
    /// </summary>
    /// <param name="left">
    ///     The left asset handle to compare.
    /// </param>
    /// <param name="right">
    ///     The right asset handle to compare.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the two asset handles are not equal; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator !=(AssetHandle<TValue> left, AssetHandle<TValue> right) => !left.Equals(right);
}