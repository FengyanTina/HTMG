using Dapper;
using MySqlConnector;
class CustomerData
{
   
    MySqlConnection connection;


    // public CustomerData()
    // {
    //     connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    // }

    // // public int InsertCustomer(string customer_fname, string customer_lname, int customer_phone, string customer_email, string customer_city, string customer_country, string customer_address)
    // // {
    // //      var r = new DynamicParameters();
    // //     r.Add("@roomType_id", typeID);
    // //     r.Add("@roomStatus_id", statusID);
    // //     r.Add("@room_price", price);
    // //     string sql = $@"INSERT INTO rooms (roomType_id, roomStatus_id, room_price) VALUES (@roomType_id,@roomStatus_id,@room_price); SELECT LAST_INSERT_ID() ";
    // //     int Id = connection.Query<int>(sql, r).First();

    //     return Id;
    
    // }
}