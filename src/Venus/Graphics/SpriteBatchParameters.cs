using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Venus.Graphics;

file static class SpriteBatchParametersAccessor
{
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "sortMode")]
    internal static extern ref readonly SpriteSortMode GetSpriteSortMode(SpriteBatch spriteBatch);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "blendState")]
    internal static extern ref readonly BlendState GetBlendState(SpriteBatch spriteBatch);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "samplerState")]
    internal static extern ref readonly SamplerState GetSamplerState(SpriteBatch spriteBatch);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "depthStencilState")]
    internal static extern ref readonly DepthStencilState GetDepthStencilState(SpriteBatch spriteBatch);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "rasterizerState")]
    internal static extern ref readonly RasterizerState GetRasterizerState(SpriteBatch spriteBatch);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "customEffect")]
    internal static extern ref readonly Effect GetEffect(SpriteBatch spriteBatch);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "transformMatrix")]
    internal static extern ref readonly Matrix GetTransformMatrix(SpriteBatch spriteBatch);
}

public record struct SpriteBatchParameters
{
    public required SpriteSortMode SpriteSortMode { readonly get; set; }

    public required BlendState BlendState { readonly get; set; }

    public required SamplerState SamplerState { readonly get; set; }

    public required DepthStencilState DepthStencilState { readonly get; set; }

    public required RasterizerState RasterizerState { readonly get; set; }

    public required Effect Effect { readonly get; set; }

    public required Matrix TransformMatrix { readonly get; set; }

    [SetsRequiredMembers]
    internal SpriteBatchParameters(SpriteBatch spriteBatch)
    {
        ArgumentNullException.ThrowIfNull(spriteBatch);

        SpriteSortMode = SpriteBatchParametersAccessor.GetSpriteSortMode(spriteBatch);
        BlendState = SpriteBatchParametersAccessor.GetBlendState(spriteBatch);
        SamplerState = SpriteBatchParametersAccessor.GetSamplerState(spriteBatch);
        DepthStencilState = SpriteBatchParametersAccessor.GetDepthStencilState(spriteBatch);
        RasterizerState = SpriteBatchParametersAccessor.GetRasterizerState(spriteBatch);
        Effect = SpriteBatchParametersAccessor.GetEffect(spriteBatch);
        TransformMatrix = SpriteBatchParametersAccessor.GetTransformMatrix(spriteBatch);
    }
}

public static class SpriteBatchParametersExtensions
{
    extension(SpriteBatch spriteBatch)
    {
        public SpriteBatchParameters Parameters => new SpriteBatchParameters(spriteBatch);
        
        public void Begin(in SpriteBatchParameters parameters) => spriteBatch.Begin
        (
            parameters.SpriteSortMode, 
            parameters.BlendState, 
            parameters.SamplerState, 
            parameters.DepthStencilState,
            parameters.RasterizerState, 
            parameters.Effect,
            parameters.TransformMatrix
        );

        public void End(out SpriteBatchParameters parameters)
        {
            parameters = spriteBatch.Parameters;
        
            spriteBatch.End();
        }
    }
}