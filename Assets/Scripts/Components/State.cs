namespace GBAsteroids
{
    internal abstract class State
    {
        public abstract void Handle(Situation situation);
    }

}