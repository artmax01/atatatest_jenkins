using Atata;
using NUnit.Framework;
using PhpTravels.UITests.Components;
using PhpTravels.UITests.Components.Rooms;

namespace PhpTravels.UITests
{
    public class HotelTests : UITestFixture
    {
        [Test]
        public void Hotel_Add()
        {
            LoginAsAdmin();

            Go.To<HotelsPage>().
                Add.ClickAndGo().
                    HotelName.SetRandom(out string name).
                    HotelDescription.SetRandom(out string description).
					Stars.Set(3).
					Type.Set("Hotel").
					From.Set("25").
					To.Set("26").
					Location.Set("London").
                    Submit().
                Hotels.Rows[x => x.Name == name].Should.BeVisible();
        }

		[Test]
		public void Hotel_Edit()
		{
			LoginAsAdmin();

			Go.To<HotelsPage>().
				Add.ClickAndGo().
					HotelName.SetRandom(out string name).
					HotelDescription.SetRandom(out string description).
					Stars.Set(3).
					Type.Set("Hotel").
					From.Set("25/01/2019").
					To.Set("26/01/2019").
					Location.Set("London").
					Submit().
				Hotels.Rows[x => x.Name == name].Edit.ClickAndGo<HotelEditPage>().
					Location.Set("Washington").
					Submit().
				Hotels.Rows[x => x.Name == name].Location.Should.Contain("Washington");
					
		}

		[Test]
		public void Hotel_Room_Add()
		{
			LoginAsAdmin();

			Go.To<HotelsPage>().
				Add.ClickAndGo().
					HotelName.SetRandom(out string name).
					HotelDescription.SetRandom(out string description).
					Stars.Set(4).
					Type.Set("Hotel").
					From.Set("26/01/2019").
					To.Set("27/01/2019").
					Location.Set("Los Angeles").
					Submit();

			Go.To<RoomsPage>().
				Add.ClickAndGo().
					RoomType.Set("Superior Double").
					Hotel.Set(name).
					Price.Set(200).
					Submit().
				Rooms.Rows[x => x.Hotel == name].Hotel.Should.Equal(name).
				Rooms.Rows[x => x.Hotel == name].Price.Should.Equal("200");


		}
    }
}
