using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Functions
{
    public class AppEnum
    {
        public static string SiteName = "My App";
        public static string LeftMenuHeader = "My App Management";
    }

    enum RoleEnum
    {
        Admin,
        Booking,
        Booking_Create
    }

    public class Role
    {
        public static string Admin = "Admin";

        public static string Report = "Report";

        public static string Booking = "Booking";
        public static string Booking_Create = "Booking_Create";
        public static string Booking_Update = "Booking_Update";
        public static string Booking_Delete = "Booking_Delete";

        public static string User = "User";
        public static string User_Create = "User_Create";
        public static string User_Update = "User_Update";
        public static string User_Delete = "User_Delete";

        public static string Product = "Product";
        public static string Product_Create = "Product_Create";
        public static string Product_Update = "Product_Update";
        public static string Product_Delete = "Product_Delete";

        public static string Supplier = "Supplier";
        public static string Supplier_Create = "Supplier_Create";
        public static string Supplier_Update = "Supplier_Update";
        public static string Supplier_Delete = "Supplier_Delete";

        public static string Customer = "Customer";
        public static string Customer_Create = "Customer_Create";
        public static string Customer_Update = "Customer_Update";
        public static string Customer_Delete = "Customer_Delete";
    }
}