namespace Geekbrains
{
	public interface IInitialization
	{
        Weapon[] Weapons { get; }

        void Initialization();
	}
}