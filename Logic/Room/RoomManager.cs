using Dapper;
using MySqlConnector;

// dotnet add package dapper
// dotnet add package mysqlconnector
class RoomManager
{
    private List<Room> rooms;
     Database newDatabase = new Database();

    public RoomManager()
    {
        // get list from database?
    }

    public List<Room> ShowAvailableRoom()
    {
        List<Room> availableRooms = new();
        foreach (Room room in newDatabase.GetRoomList())
        {
            if (room.roomStatus_name == "CheckOut")// this Available need to be changed to Enum later
            {
                availableRooms.Add(room);
            }
        }
        return availableRooms;
    }

    public void AddRoom(Room newRoom)   //needs to update DB directly /j
    {
        rooms.Add(newRoom);
    }

    public void RemoveRoom(Room removeRoom)     //needs to update DB directly /j
    {
        rooms.Remove(removeRoom);
    }
}