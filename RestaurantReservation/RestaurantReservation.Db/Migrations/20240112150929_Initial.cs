using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<int>(type: "int", nullable: false),
                    opening_hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.restaurant_id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Employees_Restaurants_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "restaurant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "int", nullable: false),
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.item_id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Restaurants_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "restaurant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    table_id = table.Column<int>(type: "int", nullable: false),
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.table_id);
                    table.ForeignKey(
                        name: "FK_Tables_Restaurants_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "restaurant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    reservation_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    table_id = table.Column<int>(type: "int", nullable: false),
                    reservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    party_size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.reservation_id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Restaurants_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "restaurant_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_table_id",
                        column: x => x.table_id,
                        principalTable: "Tables",
                        principalColumn: "table_id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    reservation_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Reservations_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "Reservations",
                        principalColumn: "reservation_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    order_item_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.order_item_id);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_item_id",
                        column: x => x.item_id,
                        principalTable: "MenuItems",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customer_id", "email", "first_name", "last_name", "phone_number" },
                values: new object[,]
                {
                    { 1111, "john.doe@example.com", "John", "Doe", "+1234567890" },
                    { 2222, "jane.smith@example.com", "Jane", "Smith", "+1987654321" },
                    { 3333, "alice.johnson@example.com", "Alice", "Johnson", "+1122334455" },
                    { 4444, "bob.williams@example.com", "Bob", "Williams", "+1555666777" },
                    { 5555, "eva.anderson@example.com", "Eva", "Anderson", "+1444333222" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "restaurant_id", "address", "name", "opening_hours", "phone_number" },
                values: new object[,]
                {
                    { 111, "123 Main St", "Doe's Diner", 8, 5551657 },
                    { 222, "456 Oak Ave", "Smith's Bistro", 9, 555543 },
                    { 333, "789 Elm Blvd", "Johnson's Grill", 7, 555490 },
                    { 444, "567 Pine Dr", "Williams' Pizzeria", 10, 5544478 },
                    { 555, "890 Cedar Ln", "Anderson's Sushi House", 11, 555432 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employee_id", "first_name", "last_name", "position", "restaurant_id" },
                values: new object[,]
                {
                    { 4321, "John", "Doe", "Server", 111 },
                    { 5432, "Jane", "Smith", "Chef", 222 },
                    { 6543, "Alice", "Johnson", "Waiter", 333 },
                    { 7654, "Bob", "Williams", "Bartender", 444 },
                    { 8765, "Eva", "Anderson", "Manager", 555 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "item_id", "description", "name", "price", "restaurant_id" },
                values: new object[,]
                {
                    { 11, "Juicy beef burger with cheese and veggies", "Burger", 10, 111 },
                    { 22, "Spaghetti with tomato sauce and meatballs", "Pasta", 15, 222 },
                    { 33, "Fresh garden salad with mixed greens", "Salad", 8, 333 },
                    { 44, "Margherita pizza with tomato, mozzarella, and basil", "Pizza", 12, 444 },
                    { 55, "Assorted sushi rolls with wasabi and soy sauce", "Sushi", 18, 555 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "table_id", "capacity", "restaurant_id" },
                values: new object[,]
                {
                    { 1122, 4, 111 },
                    { 2233, 6, 222 },
                    { 3344, 2, 333 },
                    { 4455, 8, 444 },
                    { 5566, 5, 555 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "reservation_id", "customer_id", "party_size", "reservation", "restaurant_id", "table_id" },
                values: new object[,]
                {
                    { 1234, 1111, 4, new DateTime(2024, 1, 13, 17, 9, 28, 929, DateTimeKind.Local).AddTicks(6675), 111, 1122 },
                    { 2345, 2222, 2, new DateTime(2024, 1, 14, 17, 9, 28, 929, DateTimeKind.Local).AddTicks(6741), 222, 2233 },
                    { 3456, 3333, 6, new DateTime(2024, 1, 15, 17, 9, 28, 929, DateTimeKind.Local).AddTicks(6745), 333, 3344 },
                    { 4567, 4444, 3, new DateTime(2024, 1, 16, 17, 9, 28, 929, DateTimeKind.Local).AddTicks(6749), 444, 4455 },
                    { 5678, 5555, 5, new DateTime(2024, 1, 17, 17, 9, 28, 929, DateTimeKind.Local).AddTicks(6753), 555, 5566 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "order_id", "employee_id", "order_date", "reservation_id", "total_amount" },
                values: new object[,]
                {
                    { 1112, 4321, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234, 85 },
                    { 2223, 5432, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2345, 120 },
                    { 3334, 6543, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3456, 45 },
                    { 4445, 7654, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4567, 100 },
                    { 5556, 8765, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5678, 150 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "order_item_id", "item_id", "order_id", "quantity" },
                values: new object[,]
                {
                    { 101, 11, 1112, 2 },
                    { 202, 22, 2223, 1 },
                    { 303, 33, 3334, 3 },
                    { 404, 44, 4445, 2 },
                    { 505, 55, 5556, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_restaurant_id",
                table: "Employees",
                column: "restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_restaurant_id",
                table: "MenuItems",
                column: "restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_item_id",
                table: "OrderItems",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_order_id",
                table: "OrderItems",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_employee_id",
                table: "Orders",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_reservation_id",
                table: "Orders",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_customer_id",
                table: "Reservations",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_restaurant_id",
                table: "Reservations",
                column: "restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_table_id",
                table: "Reservations",
                column: "table_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_restaurant_id",
                table: "Tables",
                column: "restaurant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
