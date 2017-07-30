namespace Pet_Clinic.Entities
{
    using System;
    using System.Text;

    public class Clinic
    {
        private int roomsNumber;
        private RoomsRegister roomsRegister;
        private int occupiedRooms;

        public Clinic(string name, int roomsNumber)
        {
            this.Name = name;
            this.RoomsNumber = roomsNumber;
            this.roomsRegister = new RoomsRegister(roomsNumber);
            this.occupiedRooms = 0;
        }

        public string Name { get; set; }

        public int RoomsNumber {
            get { return this.roomsNumber; }
            set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }

                this.roomsNumber = value;
            }
        }

        public bool TryAddPet(Pet currentPet)
        {
            foreach (var roomIndex in this.roomsRegister)
            {
                if (this.roomsRegister[roomIndex] == null)
                {
                    this.roomsRegister[roomIndex] = currentPet;
                    this.occupiedRooms++;
                    return true;
                }
            }

            return false;
        }

        public bool TryReleasePet()
        {
            int centralRoomIndex = this.RoomsNumber / 2;
            for (int i = 0; i < this.RoomsNumber; i++)
            {
                int currentIndex = (centralRoomIndex + i) % this.RoomsNumber;
                if (this.roomsRegister[currentIndex] != null)
                {
                    this.roomsRegister[currentIndex] = null;
                    this.occupiedRooms--;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.occupiedRooms < this.RoomsNumber;
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.RoomsNumber; i++)
            {
                sb.AppendLine(this.Print(i));
            }

            return sb.ToString().TrimEnd();
        }

        public string Print(int roomIndex)
        {
            return this.roomsRegister[roomIndex]?.ToString() ?? "Room empty";
        }
    }
}
