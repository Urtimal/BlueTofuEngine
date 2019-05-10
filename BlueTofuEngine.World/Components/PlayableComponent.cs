using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public class PlayableComponent : IComponent
    {
        public string Name => "playable";

        public int BreedId { get; set; }
        public bool Gender { get; set; }
    }

    public static class PlayableComponentExtensions
    {
        public static PlayableComponent Playable(this IEntity entity)
        {
            return entity.GetComponent<PlayableComponent>();
        }
    }
}
