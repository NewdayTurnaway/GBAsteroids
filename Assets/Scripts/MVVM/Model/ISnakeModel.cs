using UnityEngine;

namespace GBSnakeMVVM
{
    public interface ISnakeModel : IModel
    {
        GameObject SnakeSegment { get; }
        float Speed { get; set; }
        float RotationSpeed { get; }
        float OffsetTail { get; }
    } 
}
