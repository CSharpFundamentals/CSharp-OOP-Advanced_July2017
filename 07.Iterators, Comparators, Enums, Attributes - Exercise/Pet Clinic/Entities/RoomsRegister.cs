namespace Pet_Clinic.Entities
{
    using System.Collections;
    using System.Collections.Generic;

    public class RoomsRegister : IEnumerable<int>
    {
        private readonly List<Pet> rooms;
        private readonly int centerRoomIndex;

        public RoomsRegister(int roomsNumber)
        {
            this.centerRoomIndex = roomsNumber / 2;
            this.rooms = new List<Pet>(new Pet[roomsNumber]);
        }

        public Pet this[int index]
        {
            get => this.rooms[index];
            set => this.rooms[index] = value;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int step = 1;

            yield return this.centerRoomIndex;

            while (step <= this.centerRoomIndex)
            {
                yield return this.centerRoomIndex - step;

                yield return this.centerRoomIndex + step++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
