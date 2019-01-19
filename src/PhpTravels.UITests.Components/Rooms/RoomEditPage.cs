using Atata;

namespace PhpTravels.UITests.Components.Rooms
{
	using _ = RoomEditPage;

	public class RoomEditPage : Page<_>
	{
		[FindById("s2id_autogen1")]
		public AutoCompleteSelect<_> RoomType { get; private set; }

		[FindById("s2id_autogen3")]
		public AutoCompleteSelect<_> Hotel { get; private set; }

		[FindByName("basicprice")]
		public NumberInput<_> Price { get; private set; }

		public ButtonDelegate<RoomsPage, _> Submit { get; private set; }
	}
}
